using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ApolloDb
{
    public static class MessageHtml
    {
        public static HtmlString Message(this HtmlHelper html, Message message)
        {
            if (message == null)
                return new MvcHtmlString("");

            var newViewContext =
                new ViewContext(html.ViewContext,
                html.ViewContext.View,
                new ViewDataDictionary(message),
                html.ViewContext.TempData,
                html.ViewContext.Writer);


            ViewEngineResult result = ViewEngines.Engines.FindPartialView(
                html.ViewContext, "~/Views/Shared/_UserMessage.cshtml");

            var stringBuilder = new StringBuilder();
            var stringWriter = new StringWriter(stringBuilder);
            result.View.Render(newViewContext, stringWriter);
            stringWriter.Flush();

            return new HtmlString(stringBuilder.ToString());
        }
    }
}
