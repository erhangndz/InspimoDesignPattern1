namespace InspimoDesignPattern1.Models
{
    public class CustomerProcessViewModel
    {
        public int CustomerProcessID { get; set; }
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeDescription { get; set; }
        public DateTime ProcessDate { get; set; }
    }
}
