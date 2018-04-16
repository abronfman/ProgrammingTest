
using System;
using System.Runtime.InteropServices;

namespace ProgrammingTest.Models {
    /// <summary>
    /// CLass to define a customer
    /// </summary>
    public class Customer : BaseObject<Customer> {
        
        #region Properties

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }

        #endregion //Properties

        #region Constructors

        private Customer()
        {
        }

        public Customer(string fName, string lName, Address address)
        {
            FirstName = fName;
            LastName = lName;
            Address = address;
        }

        #endregion //Constructors

        public override bool Equals(object obj)
        {
            if (obj is Customer b)
            {
                return Id == b.Id 
                    && FirstName.Equals(b.FirstName, StringComparison.CurrentCulture)
                    && LastName.Equals(b.LastName, StringComparison.CurrentCulture)
                    && Address.Equals(b.Address);
            }
            return false;
        }
    }

}
