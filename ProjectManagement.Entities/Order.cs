using System;
using System.Collections.Generic;
using System.Text;

namespace EHealthcare.Entities
{
    public class Order : BaseEntity
    {
        public long UserID { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime PlacedOn { get; set; }

        public virtual User User { get; set; }
    }
}
