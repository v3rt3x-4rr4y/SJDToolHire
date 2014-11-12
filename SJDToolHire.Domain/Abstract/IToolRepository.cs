using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SJDToolHire.Domain.Entities;

namespace SJDToolHire.Domain.Abstract
{
    public interface IToolRepository
    {
        IEnumerable<Tool> Tools { get; }
        void SaveTool(Tool tool);
        Tool DeleteTool(int productId);
    }
}
