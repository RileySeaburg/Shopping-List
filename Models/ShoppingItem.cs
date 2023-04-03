using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_List.Models
{
  public class ShoppingItem
  {
    [Required]
    [DisplayName("ID")]
    public int ID { get; set; }
    [Required]
    [DisplayName("Name")]
    public string Name { get; set; }
        [Required]
        [DisplayName("Item In Cart")]
        public bool IsChecked { get; set; } = false;

    public float? Price { get; set; }
  }
}
