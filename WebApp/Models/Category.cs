using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Category
    {
        [Key]
        public int cat_id { get; set; }
        public string category_name { get; set; }
    }
}
