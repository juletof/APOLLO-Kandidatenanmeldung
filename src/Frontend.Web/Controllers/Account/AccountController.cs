using System;
using System.Globalization;
using System.Web.Mvc;
using ApolloDb;

namespace Frontend.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly Registrieren _registrieren;
        private readonly Anmelden _anmelden;
        private readonly KandidatRepository _kandidatRepository;
        private readonly IsEmailAddressInUse _emailAddressInUse;
        private readonly SessionUser _sessionUser;

        public AccountController(Registrieren registrieren, 
                                 Anmelden anmelden,
                                 KandidatRepository kandidatRepository, 
                                 IsEmailAddressInUse emailAddressInUse, 
                                 SessionUser sessionUser)
        {
            _registrieren = registrieren;
            _anmelden = anmelden;
            _kandidatRepository = kandidatRepository;
            _emailAddressInUse = emailAddressInUse;
            _sessionUser = sessionUser;
        }

        public ActionResult Registrierung()
        {
            return View(new RegistrierungModel());
        }

        [HttpPost]
        public ActionResult Registrierung(RegistrierungModel model)
        {
            if(!ModelState.IsValid){
                return View(model);
            }

            if(_emailAddressInUse.Yes(model.Emailadresse))
            {
                model.Message = new ErrorMessage("Die Emailadresse ist bereits in Verwendung | Этот электронный адрес уже используется другим пользователем.");
                return View(model);
            }

            var kandidat = _registrieren.Run(RegistrierungModel2Entity.Run(model));

            _sessionUser.Login(kandidat);
            return Redirect("Dashboard/registrierungErfolgreich");
        }

        public ActionResult Login(){ return View(new LoginModel());}

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
                return View(loginModel);

            var loginResult = Sl.Resolve<Login>().Run(loginModel.Emailadresse, loginModel.Password);
            if (loginResult.Success)
            {
                _sessionUser.Login(loginResult.Kandidat);
                return Redirect("Dashboard");
            }
            
            loginModel.Message = new ErrorMessage("Die Anmeldedaten sind nicht korrekt. | Пожалуйста, проверьте правильность написания логина и пароля.");
            return View(loginModel);
        }

        public ActionResult LogOff()
        {
            _sessionUser.Logout();
            return View();
        }

        [AuthorizedKandidatOnly]
        public ActionResult Dashboard()
        {
            return View(new DashboardModel(_sessionUser.GetKandidat()));
        }

        [AuthorizedKandidatOnly][HttpGet]
        public ActionResult Dashboard(string id)
        {
            var dashboardModel = new DashboardModel(_sessionUser.GetKandidat());
            if (id == "registrierungErfolgreich")
                dashboardModel.ZeigeRegistrierungErfolgreich = true;
            
            if (id == "anmeldungErfolgreich")
                dashboardModel.Message = new SuccessMessage("Danke, Sie haben alle erforderlichen Daten für die Anmeldung eingegeben.<br/><br/>" +
                                   @"Спасибо, вы задали все неодходимые данные для регистрации.<br/><br/>Когда мы будем в вашем городе, где и в какое время состоится собеседование вы можете узнать в международном отделе или у ответственного за программу АПОЛЛО в вашем университет. 
                                    Наш маршрут освещен также в группе в Вконтакте, там же вы можете задать вопрос координатору программы Анне Товкаленко.<br/>
                                    Заполнение формы регистрации на портале не осовобождает от заполнения документов для отбора. Это значит, что с собой на собеседовании необходимо иметь:<br/>
                                    - анкету с вклеенной фотографией<br/>
                                    - дополнительные фотографии формата 3х4 (пожалуйста, актуальную)<br/>
                                    - автобиографию.<br/><br/>

                                    Желаем удачи и с нетерпением ждем личной встречи!");

            if (id == "passwortGeaendert")
                dashboardModel.Message = new SuccessMessage("Sie haben Ihr Passwort erfolgreich geändert. | " +
                       "Вы успешно изменили пароль");
            
            return View(dashboardModel);
        }

        [AuthorizedKandidatOnly][HttpGet]
        public ActionResult Anmeldung(string id)
        {
            if(_sessionUser.IsLoggedInAdmin)
                if(!String.IsNullOrEmpty(id))
                    _sessionUser.KandidatId = Convert.ToInt32(id);

            return View(new AnmeldungModel(_sessionUser.GetKandidat(), _sessionUser));
        }


        [AuthorizedKandidatOnly] [HttpPost]
        public ActionResult Anmeldung(AnmeldungModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            DateTime outParseTest;
            if (!DateTime.TryParse(model.Geburtsdatum, CultureInfo.GetCultureInfo("de-DE"), DateTimeStyles.None,  out outParseTest))
            {
                model.Message = new ErrorMessage("Das Geburtstdatum kann nicht verarbeitet werden. Bitte achten Sie auf das Eingabeformat: dd-mm-yyyy | Указанная Вами дата рождения неправильна. Пожалуйста обратите внимание на формат: дд-мм-гггг.");
                return View(model);
            }

            _anmelden.Run(AnmeldungModelFillFromUi.Run(model, _sessionUser.GetKandidat()));
            return Redirect("/Account/Dashboard/anmeldungErfolgreich");
        }

        [AuthorizedKandidatOnly]
        public ActionResult Benutzerdaten()
        {
            return View(new BenutzerDatenModel(_sessionUser.GetKandidat()));
        }

        [AuthorizedKandidatOnly] [HttpPost]
        public ActionResult Benutzerdaten(BenutzerDatenModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _kandidatRepository.Update(BenutzerDatenModellFillFromUi.Run(model, _sessionUser.GetKandidat()));
            model.Message = new SuccessMessage("Die Daten wurden gespeichert | Данные были удачно сохранены.");

            return View(model);
        }

        public ActionResult Passwort_vergessen()
        {
            return View(new PasswortVergessenModel());
        }

        [HttpPost]
        public ActionResult Passwort_vergessen(PasswortVergessenModel model)
        {
            var result = Sl.Resolve<PasswortVergessen>().Run(model.Emailadresse);
            if(result.DieEmailExisitertNicht)
                model.Message = new ErrorMessage("Diese Email-Adresse ist nicht im System registriert. | Этот электронный адрес не зарегистрирован в системе.");
            else if(result.Success)
                model.Message = new SuccessMessage("Eine Benachrichtigung wird verschickt. | Вам было отправлено сообщение на указанный электронный адрес.");

            return View(model);
        }

        [AuthorizedKandidatOnly]
        public ActionResult Passwort_aendern()
        {
            return View(new PasswortAendernModel());
        }

        [AuthorizedKandidatOnly] [HttpPost]
        public ActionResult Passwort_aendern(PasswortAendernModel passwortAendernModel)
        {
            var kandidat = _sessionUser.GetKandidat();
            var loginResult = Sl.Resolve<Login>().Run(kandidat.EmailAdresse, passwortAendernModel.AltesPasswort);

            if(loginResult.Success)
            {
                kandidat.Passwort = HashPassword.Run(passwortAendernModel.NeuesPasswort1);
                _kandidatRepository.Update(kandidat);
                return Redirect("/Account/Dashboard/passwortGeaendert");
            }
            
            passwortAendernModel.Message = new ErrorMessage("Das alte Passwort ist nicht korrekt. | Ваш старый пароль, который Вы ввели, неправильный.");

            return View(passwortAendernModel);
        }

        public ActionResult AutoLogin()
        {
            if (!Request.IsLocal)
                return Redirect("/");

            _sessionUser.Login(_kandidatRepository.GetById(1));
            return RedirectToAction("Dashboard");
        }
    }
}