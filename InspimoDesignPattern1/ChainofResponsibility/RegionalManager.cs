using InspimoDesignPattern1.DAL;
using InspimoDesignPattern1.Models;

namespace InspimoDesignPattern1.ChainofResponsibility
{
    public class RegionalManager:Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            var context = new Context();
            if (req.Amount <= 350000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Serkan Kaya";
                customerProcess.EmployeeDescription = "Müşterinin talep ettiği tutar müşteriye bölge müdürü tarafından ödendi. işlem kapatıldı.";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Serkan Kaya";
                customerProcess.EmployeeDescription = "Müşterinin talep ettiği tutar müşteriye bölge müdürü tarafından ödenemedi, işlem yapılamadı.";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                
            }
        }
    }
}
