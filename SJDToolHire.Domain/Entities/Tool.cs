using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJDToolHire.Domain.Entities
{
    class Tool
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public string Weight { get; set; }
        public string Power { get; set; }
    }
}
