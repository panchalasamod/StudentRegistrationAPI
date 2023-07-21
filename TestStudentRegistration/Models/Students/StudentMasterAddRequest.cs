using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestStudentRegistration.Models
{
    public class StudentMasterAddRequest
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string NIC { get; set; }
        public string Base64Image { get; set; }

        //public byte[] Image { get; set; }
        public bool? IsDeleted { get; set; }
    }
}