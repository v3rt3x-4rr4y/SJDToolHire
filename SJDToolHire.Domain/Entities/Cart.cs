using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace SJDToolHire.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public void AddItem(Tool tool, int quantity)
        {
            CartLine line = lineCollection
            .Where(p => p.Tool.ProductID == tool.ProductID)
            .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine { Tool = tool, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveItem(Tool tool)
        {
            CartLine line = lineCollection
                            .Where(p => p.Tool.ProductID == tool.ProductID)
                            .FirstOrDefault();
            if (line != null)
            {
                if (line.Quantity > 1)
                {
                    line.Quantity--;
                }
                else
                {
                    RemoveLine(tool);
                }
            }
        }

        public void RemoveLine(Tool tool)
        {
            lineCollection.RemoveAll(l => l.Tool.ProductID == tool.ProductID);
        }

        public int quantityForTool(Tool tool)
        {
            int retVal = 0;
            CartLine line = lineCollection
                            .Where(p => p.Tool.ProductID == tool.ProductID)
                            .FirstOrDefault();

            if (line == null)
            {
                retVal = line.Quantity;
            }
            return retVal;
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Tool.Rate * e.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public bool SetStartDate(Tool tool, DateTime startDate)
        {
            bool retVal = false;
            CartLine line = lineCollection
                            .Where(p => p.Tool.ProductID == tool.ProductID)
                            .FirstOrDefault();
            if (line != null)
            {
                if (line.End.Ticks >= startDate.Ticks)
                {
                    line.Start = startDate;
                    retVal = true;
                }
            }
            return retVal;
        }

        public bool SetEndDate(Tool tool, DateTime endDate)
        {
            bool retVal = false;
            CartLine line = lineCollection
                            .Where(p => p.Tool.ProductID == tool.ProductID)
                            .FirstOrDefault();
            if (line != null)
            {
                if (line.Start.Ticks <= endDate.Ticks)
                {
                    line.End = endDate;
                    retVal = true;
                }
            }
            return retVal;
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public CartLine()
        {
            Start = DateTime.Now;
            End = DateTime.Now;
        }
        public Tool Tool { get; set; }
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Please enter a valid start date")]
        public DateTime Start { get; set; }
        [Required(ErrorMessage = "Please enter a valid end date")]
        public DateTime End{get; set; }
    }
}

