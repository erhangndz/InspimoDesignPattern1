using InspimoDesignPattern1.DAL;
using InspimoDesignPattern1.Models;

namespace InspimoDesignPattern1.ChainofResponsibility
{
    public class Manager:Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            var context = new Context();
            if (req.Amount <= 250000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Zeynep Öztürk";
                customerProcess.EmployeeDescription = "Müşterinin talep ettiği tutar müşteriye şube müdürü tarafından ödendi. işlem kapatıldı.";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Zeynep Öztürk";
                customerProcess.EmployeeDescription = "Müşterinin talep ettiği tutar müşteriye şube müdürü tarafından ödenemedi, , işlem bölge müdürüne yönlendirildi.";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
