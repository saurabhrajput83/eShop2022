using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Entities
{
    public partial class SelectedItemVariation : BaseEntity
    {
        public SelectedItemVariation()
        { }

        public double Modifier { get; set; }
        public int? SelectedItemId { get; set; }
        public int? VariationId { get; set; }
        public virtual SelectedItem? SelectedItem { get; set; }
        public virtual Variation? Variation { get; set; }
    }
}
