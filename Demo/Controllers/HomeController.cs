using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace Fido2NetFrameworkDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult overview() => View();

        public ActionResult mfa() => View();

        public ActionResult passwordless() => View();

        public ActionResult usernameless() => View();

        public ActionResult custom() => View();

        public ActionResult dashboard(string id)
        {
            try
            {
                var DemoStorage = MyController.DemoStorage;

                // 1. Get user from DB
                var user = DemoStorage.GetUser(id);

                // 2. Get registered credentials from database
                var existingCredentials = DemoStorage.GetCredentialsByUser(user).ToArray();
                return View((user, existingCredentials));
            }
            catch
            {
                return RedirectToAction(nameof(overview));
            }
        }
    }
}