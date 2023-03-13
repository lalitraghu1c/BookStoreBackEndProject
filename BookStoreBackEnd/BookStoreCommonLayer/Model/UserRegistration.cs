using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStoreCommonLayer.Modal
{
    public class UserRegistration
    {
        public string Full_Name { get; set; }
        public string Email_Id { get; set; }
        public string Password { get; set; }
        public string Mobile_Number { get; set; }

    }
}
