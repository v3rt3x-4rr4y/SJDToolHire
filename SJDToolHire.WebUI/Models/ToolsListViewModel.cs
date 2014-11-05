using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SJDToolHire.Domain.Entities;

namespace SJDToolHire.WebUI.Models
{
    public class ToolsListViewModel
    {
        public IEnumerable<Tool> Tools { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}