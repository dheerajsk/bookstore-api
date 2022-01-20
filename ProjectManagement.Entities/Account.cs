using EHealthcare.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ehealthcare.Entities
{
    public class Account : BaseEntity
    {
        public int AccNumber { get; set; }

        public int Amount { get; set; }

        public string Email { get; set; }
    }
}
