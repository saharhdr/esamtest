using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Esam.Models.ViewModel
{
    public class CustomRegModel
    {
        public VerifyAccountType VerifyAccount { get; set; }

        public bool active { get; set; }

        public string fname { get; set; }

        public string lname { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string confirmpassword { get; set; }

        public string answer { get; set; }

        public int userid { get; set; }
        public string confirmemail { get; set; }
    }
}