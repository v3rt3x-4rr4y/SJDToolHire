using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SJDToolHire.Domain.Entities;

namespace SJDToolHire.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Tool> Tools { get; set; }
    }
}
