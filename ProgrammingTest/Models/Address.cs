using System;

namespace ProgrammingTest.Models {
    /// <inheritdoc />
    /// <summary>
    /// Class to define an address
    /// </summary>
    public class Address : BaseObject<Address>
    {
        #region Properties

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postal { get; set; }

        #endregion //Properties

        #region Constructors

        public Address()
        {
        }

        public Address(string street, string city, string state, string postal)
        {
            Street = street;
            City = city;
            State = state;
            Postal = postal;
        }

        #endregion //Constructors

        public override bool Equals(object obj)
        {
            if (obj is Address b)
            {
                return Id == b.Id
                       && Street.Equals(b.Street, StringComparison.CurrentCulture)
                       && City.Equals(b.City, StringComparison.CurrentCulture)
                       && State.Equals(b.State, StringComparison.CurrentCulture)
                       && Postal.Equals(b.Postal, StringComparison.CurrentCulture);
            }
            return false;
        }
    }
}
