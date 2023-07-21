using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestStudentRegistration.Models
{
    public class StudentMasterDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string NIC { get; set; }
        public byte[] Image { get; set; }
        public bool? IsDeleted { get; set; }


        private string _base64Image;
        public string Base64Image
        {
            get
            {
                if (Image != null)
                {
                    _base64Image = "data:image/png;base64," + Convert.ToBase64String(Image, 0, Image.Length);
                    return _base64Image;
                }
                else
                {
                    return null;
                }

            }
            set
            {
                if (Image != null)
                {
                    _base64Image = "data:image/png;base64," + Convert.ToBase64String(Image, 0, Image.Length);
                }
            }
        }

    }
}