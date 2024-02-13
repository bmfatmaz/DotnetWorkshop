using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PassportNumber { get; set; }
        public string TelNumber { get; set; }
        public string EmailAddress { get; set; }
        public ICollection<Flight> Flights { get; set; }
        public override string ToString()
        {
            return "FirstName=" + FirstName + " LastName=" + LastName;
        }
        //public bool CheckProfile(string firstname,string lastname)
        //{
        //    return this.FirstName.Equals(firstname)
        //        && this.LastName.Equals(lastname);
               

        //}
        //public bool CheckProfile(string firstname, string lastname,string email)
        //{
        //    return this.FirstName==firstname 
        //        && this.LastName==lastname 
        //        && this.EmailAddress==email;


        //}
        public bool CheckProfile(string firstname, string lastname,string? email=null)
        {
             if (email != null)
            
                return this.FirstName == firstname
                && this.LastName == lastname
                && this.EmailAddress == email;
            
            else
            
                return this.FirstName == firstname
               && this.LastName == lastname;

        }
        public virtual string PassengerType()
        {
            return "I'm a passenger";
        }

    }
}
