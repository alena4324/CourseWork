using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileSystem.Models
{
    public class NewItemModel
    {
        public string Path { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Extension")]
        public string Type { get; set; }

    }
}