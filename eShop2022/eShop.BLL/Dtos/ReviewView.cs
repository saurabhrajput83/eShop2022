using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Dtos
{
    public class ReviewView : BaseFullView
    {
        public bool IsHidden { get; set; }
        public string? Headline { get; set; }
        public bool IsApproved { get; set; }
        public int? ContactId { get; set; }
        public int Rating { get; set; }
        public string? Comments { get; set; }
        public int? ProductId { get; set; }

    }
}
