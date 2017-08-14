using System;

namespace CustomerSolution.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public EyesColor EyesColor { get; set; }
        public int EyesColorId { get; set; }
        public string PassportId { get; set; }
    }
}