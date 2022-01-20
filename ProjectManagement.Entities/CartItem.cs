using System;
using System.Collections.Generic;
using System.Text;

namespace EHealthcare.Entities
{
    public class CartItem : BaseEntity
    {
        public long CartID { get; set; }

        public long BookID { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual Book Book { get; set; }
    }
}
