﻿using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ApolloDb
{
    public class PasswortResetModel
    {
        public Message Message;

        [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
        public string NeuesPasswort1 { get; set; }
        
        [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
        [System.Web.Mvc.Compare("NeuesPasswort1", ErrorMessage = "Die Passwörter stimmen nicht über ein. | Введённые Вами пароли не совпадают.")]
        public string NeuesPasswort2 { get; set; }

        public string Token { get; set; }

        public bool TokenFound;
    }
}