using System;
using System.Net.NetworkInformation;

namespace ProgrammingTest.Models {
    /// <summary>
    /// Class to define a company
    /// </summary>
    public class Company : BaseObject<Company> {

        #region Properties

        public string Name { get; set; }
        public Address Address { get; set; }

        #endregion //Properties

        #region Constructors

        public Company()
        {
        }

        public Company(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        #endregion //Constructors

        public override bool Equals(object obj)
        {
            if (obj is Company b) {
                return Id == b.Id
                       && Name.Equals(b.Name, StringComparison.CurrentCulture)
                       && Address.Equals(b.Address);
            }
            return false;
        }
    }
}
