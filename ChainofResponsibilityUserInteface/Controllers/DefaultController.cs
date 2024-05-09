using ChainofResponsibilityUserInteface.ChainOfRes.DataAccessLayer.Context;
using ChainofResponsibilityUserInteface.ChainOfResponsibility;
using ChainofResponsibilityUserInteface.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChainofResponsibilityUserInteface.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ChainOfRespDb _chainOfRespDb;

        public DefaultController(ChainOfRespDb chainOfRespDb)
        {
            _chainOfRespDb = chainOfRespDb;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {
            Employee treasurer = new Treasurer(_chainOfRespDb);
            Employee managerAssistant = new ManagerAssistant(_chainOfRespDb);
            Employee manager = new Manager(_chainOfRespDb);
            Employee districtManager = new DistrictManager(_chainOfRespDb);

            treasurer.SetNextAppover(managerAssistant);
            managerAssistant.SetNextAppover(manager);
            manager.SetNextAppover(districtManager);

            treasurer.ProcessRequest(model);
            return View();
        }
    }
}
