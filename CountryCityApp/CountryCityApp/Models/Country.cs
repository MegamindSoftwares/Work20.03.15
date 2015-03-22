using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountryCityApp.Models
{
    public class Country
    {
        [Key]
        public int Id { set; get; }
        [Required(ErrorMessage = "Name is required")]
        [Remote("CheckName","Country",ErrorMessage = "This name is already exists")]
        public string Name { set; get; }
        [Required(ErrorMessage = "About is required")]
        [AllowHtml]
        public string About { set; get; }
        [Required(ErrorMessage = "Picture is required")]
        public string Picture { set; get; }
    }
}