using ApplicationDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.ProductRef.Bindings
{
    public class AllProductBinding
    {
        public Category Category { set; get; }
        public string CategoryName { set; get; }
        public List<SubCategoryBinding> SubCategoryItems { set; get; }
        public AllProductBinding()
        {
            this.SubCategoryItems = new List<SubCategoryBinding>();
        }
    }

    public class SubCategoryBinding
    {
        public SubCategory SubCategory { set; get; }
        public string SubCategoryName { set; get; }
        public List<ProductBinding> Products { set; get; }
        public SubCategoryBinding()
        {
            this.Products = new List<ProductBinding>();
        }

    }
}
