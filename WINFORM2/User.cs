using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WINFORM2
{
    public class User
    {
        public User(string name, string surname, string parentName, string phone, string country, string city, string gender, DateTime birthDate)
        {
            Name = name;
            Surname = surname;
            ParentName = parentName;
            this.phone = phone;
            Country = country;
            City = city;
            Gender = gender;
            BirthDate = birthDate;
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string ParentName { get; set; }

        public string phone { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
