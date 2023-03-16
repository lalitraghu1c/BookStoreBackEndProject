using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStoreCommonLayer.Model
{
    public class ResetPasswordModel
    {
        [Required]
        public string New_Password { get; set; }
        [Required]
        public string Confirm_Password { get; set; }
    }
}
