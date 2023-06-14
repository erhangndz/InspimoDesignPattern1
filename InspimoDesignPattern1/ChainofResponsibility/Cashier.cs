using InspimoDesignPattern1.DAL;
using InspimoDesignPattern1.Models;

namespace InspimoDesignPattern1.ChainofResponsibility
{
    public class Cashier : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            var context = new Context();
            if (req.Amount <= 100000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName= req.CustomerName;
                customerProcess.ProcessDate= Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Ali Yıldız";
                customerProcess.EmployeeDescription = "Müşterinin talep ettiği tutar ödendi. işlem kapatıldı";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if(NextApprover != null)
            {
                CustomerProcess customerProcess= new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Ali Yıldız";
                customerProcess.EmployeeDescription = "Müşterinin talep ettiği tutar veznedar tarafından ödenemedi, işlem şube müdür yardımcısına yönlendirildi.";
                context.CustomerProcesses.Add(customerProcess); 
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
