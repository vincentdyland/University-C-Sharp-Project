using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRA_Web_Application.Model {
    public class Student {
        public string Roll { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Student(string roll, string name, string gender, string address, string email, string phone) {
            Roll = roll;
            Name = name;
            Gender = gender;
            Address = address;
            Email = email;
            Phone = phone;
        }
    }
}