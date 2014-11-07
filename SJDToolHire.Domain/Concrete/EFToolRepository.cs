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

        public void SaveTool(Tool tool)
        {
            if (tool.ProductID == 0)
            {
                context.Tools.Add(tool);
            }
            else
            {
                Tool dbEntry = context.Tools.Find(tool.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = tool.Name;
                    dbEntry.ImageUrl = tool.ImageUrl;
                    dbEntry.Power = tool.Power;
                    dbEntry.Rate = tool.Rate;
                    dbEntry.Category = tool.Category;
                    dbEntry.Description = tool.Description;
                    dbEntry.Weight = tool.Weight;
                }
            }
            context.SaveChanges();
        }
    }
}
