using CustomerAPI.DAL.Entities;
using CustomerAPI.DAL.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartup(typeof(CustomerAPI.Startup))]

namespace CustomerAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //CreateDataTableWithExampleRow();
        }

        private void CreateDataTableWithExampleRow()
        {
            using (var db = new CustomerContext())
            {
                db.Customers.Add(new Customer { FirstName = "Aleksandra", LastName = "Snoch", EyesColor = EyesColor.Green, DateOfBirth = new DateTime(1989, 5, 18), PassportId = "ABCD123456789" });
                db.SaveChanges();

                foreach (var customer in db.Customers)
                {
                    Console.WriteLine(customer.FirstName);
                }
            }
        }
    }
}
