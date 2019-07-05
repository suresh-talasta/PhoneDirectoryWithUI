using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomerPhoneNumber_2.Models
{
    public class PhoneNumber
    {
        public int ID { get; set; }
        public string customerPhoneNumber { get; set; }
        public string customerName { get; set; }
        public string customerId { get; set; }
        public bool active { get; set; }

    }

    public class CustomerDbContext : DbContext
    {
              public DbSet<PhoneNumber> phoneNumbers { get; set; }
    }
}