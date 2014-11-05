using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SJDToolHire.Domain.Abstract;
using SJDToolHire.Domain.Entities;

namespace SJDToolHire.Domain.Concrete
{
    public class EFToolRepository : IToolRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Tool> Tools
        {
            get { return context.Tools; }
        }
    }
}
