using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Good
    {
        public int Id { get; set; }
        [Display(Name = "Название товара")]
        public string Name { get; set; }
        [Display(Name = "Цена")]
        public double Price { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }

    }
}
