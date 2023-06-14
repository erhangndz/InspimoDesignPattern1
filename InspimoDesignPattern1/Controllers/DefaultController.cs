using InspimoDesignPattern1.ChainofResponsibility;
using InspimoDesignPattern1.Models;
using Microsoft.AspNetCore.Mvc;

namespace InspimoDesignPattern1.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {
            Employee cashier= new Cashier();
            Employee assistantManager = new AssistantManager();
            Employee manager = new Manager();
            Employee regionalManager= new RegionalManager();


            cashier.SetNextApprover(assistantManager);
            assistantManager.SetNextApprover(manager);
            manager.SetNextApprover(regionalManager);


            cashier.ProcessRequest(model);
            return View();
        }
    }
}
