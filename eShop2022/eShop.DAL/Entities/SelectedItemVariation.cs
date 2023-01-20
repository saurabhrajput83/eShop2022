using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Entities
{
    public class SelectedItemVariation : BaseEntity
    {
        public decimal Modifier { get; set; }
        public int? SelectedItemId { get; set; }
        public int? VariationId { get; set; }
        public SelectedItem? SelectedItem { get; set; }
        public Variation? Variation { get; set; }
    }
}
