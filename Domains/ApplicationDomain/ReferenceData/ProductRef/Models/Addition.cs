using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.ProductRef.Models
{
    public class Addition
    {
        public bool IsMultipleSelect { set; get; }

        public bool IsRequired { set; get; }
        public string Title { set; get; }
        public List<AdditionItem> Items { set; get; }
    }
}
