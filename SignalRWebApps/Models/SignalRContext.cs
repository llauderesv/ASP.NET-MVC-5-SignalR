using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SignalRWebApps.Models
{
    public class SignalRContext : DbContext
    {
        public DbSet<GroupMessage> GroupMessages { get; set; }
    }

    public class GroupMessage
    {
        [Key]
        public int _id { get; set; }
        public string User { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}