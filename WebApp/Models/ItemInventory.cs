using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ItemInventory
    {
        [Key]
        public int item_id { get; set; }
        [Display(Name ="Item Name")]
        [Required(ErrorMessage ="Name is required")]
        public string item_name { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Quantity is required")]
        public int quantity { get; set; }

        [Display(Name = "Min price")]
        [Required(ErrorMessage = "Min level is required")]
        public int min_price { get; set; }



        [Display(Name = "Max price")]
        [Required(ErrorMessage = "Max level is required")]
        public int max_price { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is required")]
        public int cat_id { get; set; }
        [NotMapped]
        [Display(Name = "Category")]
        public string category_name { get; set; }

    }
}
