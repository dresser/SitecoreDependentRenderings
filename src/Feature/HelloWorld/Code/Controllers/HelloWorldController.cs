using System.Web.Mvc;
using Sitecore.Mvc.Presentation;

namespace Sitecore.Feature.HelloWorld.Controllers
{
    public class HelloWorldController : Controller
    {
        public ActionResult HelloWorld()
        {
            var model = new RenderingModel();
            model.Initialize(Sitecore.Mvc.Presentation.RenderingContext.Current.Rendering);
            return View(model);
        }
    }
}