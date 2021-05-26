using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OpenOrderFramework.Models
{
    public class Catagorie
    {
        [Key]
        [DisplayName("ID категории")]
        public int ID { get; set; }

        [DisplayName("Категория")]
        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}