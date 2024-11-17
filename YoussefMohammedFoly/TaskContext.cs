using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace YoussefMohammedFoly
{
    public class TaskContext: DbContext
    {
        //TaskContext
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
