using InspimoDesignPattern1.Models;

namespace InspimoDesignPattern1.ChainofResponsibility
{
    public abstract class Employee
    {
        protected Employee NextApprover;

        public void SetNextApprover(Employee supervisor)
        {
            this.NextApprover = supervisor;
        }

        public abstract void ProcessRequest(CustomerProcessViewModel req);
    }
}
