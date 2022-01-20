using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EHealthcare.Entities
{
    public class Cart : BaseEntity
    {
        public long OwnerID { get; set; }

        public virtual User Owner { get; set; }

        public virtual ICollection<CartItem> Items { get; set; }
    }
}
