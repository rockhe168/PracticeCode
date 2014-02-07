using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

using CQRS.Sample.Commands;
using CQRS.Commanding;

namespace CQRS.Sample.Web.Controllers
{
    public class AccountController : Controller
    {
        public ICommandBus CommandBus { get; private set; }

        public AccountController()
            : this(ObjectContainer.Resolve<ICommandBus>())
        {
        }

        public AccountController(ICommandBus bus)
        {
            CommandBus = bus;
        }

        public ActionResult LogOn()
        {
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterCommand command)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CommandBus.Send(command);
                    FormsAuthentication.SetAuthCookie(command.Email, false);

                    return Redirect("/");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }

                return View(command);
            }

            return View(command);
        }
    }
}
