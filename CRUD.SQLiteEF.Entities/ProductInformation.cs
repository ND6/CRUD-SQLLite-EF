using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.SQLiteEF.Entities
{
    public class ProductInformation
    {
        public ProductInformation()
        {
            PriceRange = new List<PriceRange>();
            SupportDocuments = new List<ProductSupportDocuments>();
            ProductSpecification = new List<ProductSpecificationChannel>();
            ProductRelatedItem = new List<ProductRelatedItem>();
            //RelatedAccessories = new List<ProductRelatedItem>();
            //RelatedInstruments = new List<ProductRelatedItem>();
            //RelatedServices = new List<ProductRelatedItem>();
            //RelatedWarranties = new List<ProductRelatedItem>();
            Applications = new List<ProductApplication>();
            ProductMedia = new List<ProductMedia>();
        }

        public int Id { get; set; }
        public string StockId { get; set; }
        public string Model { get; set; }
        public string ProductCategory { get; set; }
        public string ProductSubcategory { get; set; }
        public string ListPrice { get; set; }
        public string Price { get; set; }
        public virtual List<PriceRange> PriceRange { get; set; }
        public string ProductDescription { get; set; }
        public List<ProductSpecificationChannel> ProductSpecification { get; set; }
        public string ProductDefinition { get; set; }
        public ProductDimensions ProductDimensions { get; set; }
        public string ProductSeries { get; set; }
        public string ProductType { get; set; }
        public string ProductTypeTitle { get; set; }
        public string LearnMoreLink { get; set; }
        public decimal? PriceUnformatted { get; set; }
        public string Capacity { get; set; }
        public string LoadDirection { get; set; }
        public string Material { get; set; }
        public string OuterDiameter { get; set; }
        public decimal? InStock { get; set; }
        public List<ProductSupportDocuments> SupportDocuments { get; set; }
        public List<ProductRelatedItem> ProductRelatedItem { get; set; }
        //public List<ProductRelatedItem> RelatedAccessories { get; set; }
        //public List<ProductRelatedItem> RelatedInstruments { get; set; }
        //public List<ProductRelatedItem> RelatedServices { get; set; }
        //public List<ProductRelatedItem> RelatedWarranties { get; set; }
        public List<ProductApplication> Applications { get; set; }
        public List<ProductMedia> ProductMedia { get; set; }
        public string WebEnable { get; set; }
        public string Status { get; set; }
        public string CustomFlag { get; set; }
        public ProductModelSize ProductModelSize { get; set; }
        public int Aging1 { get; set; }
        public int Aging2 { get; set; }
        public int Aging3 { get; set; }
        public int Aging4 { get; set; }
        public int Aging5 { get; set; }
        public int Aging6 { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }

    public class ProductMedia
    {
        public int Id { get; set; }
        public string MediaType { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        public virtual ProductInformation ProductInformation { get; set; }
    }

    public class ProductApplication
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Priority { get; set; }

        public virtual ProductInformation ProductInformation { get; set; }
    }

    public class PriceRange
    {
        public int Id { get; set; }
        public string StockId { get; set; }
        public decimal? OriginalPrice { get; set; }
        public string QtyFrom { get; set; }
        public string QtyTo { get; set; }
        public decimal? Price { get; set; }
        public string DiscountedPrice { get; set; }

        public virtual ProductInformation ProductInformation { get; set; }
    }

    public class ProductSupportDocuments
    {
        public int Id { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentUrl { get; set; }

        public virtual ProductInformation ProductInformation { get; set; }
    }

    public class ProductSpecificationChannel
    {
        public int Id { get; set; }
        public string Channel { get; set; }
        public List<ProductSpecification> Specifications { get; set; }

        public virtual ProductInformation ProductInformation { get; set; }
    }

    public class ProductSpecification
    {
        public int Id { get; set; }
        public string Specification { get; set; }
        public string Min { get; set; }
        public string Typ { get; set; }
        public string Max { get; set; }
        public string Unit { get; set; }
        public string Channel { get; set; }
        public string ToolTip { get; set; }

        public virtual ProductSpecificationChannel ProductSpecificationChannel { get; set; }
    }

    public class ProductRelatedItem
    {
        public int ParentId { get; set; }
        public int Id { get; set; }
        public string Model { get; set; }
        public string StockId { get; set; }
        public string Definition { get; set; }
        public string Price { get; set; }
        public decimal? InStock { get; set; }
        public decimal? Rate { get; set; }
        public string Category { get; set; }
        public string CategoryDefinition { get; set; }
        public string Capacity { get; set; }
        public string ProductCode { get; set; }
        //public List<ProductRelatedItem> RelatedServices { get; set; }

        public virtual ProductInformation ProductInformation { get; set; }
    }

    public class ProductDimensions
    {
        //[Key, ForeignKey("ProductInformation")]
        public int ProductInformation_Id { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string WeightLb { get; set; }
        public string WeightOz { get; set; }

        public virtual ProductInformation ProductInformation { get; set; }
    }

    public class ProductModelSize
    {
        //[Key, ForeignKey("ProductInformation")]
        public int ProductInformation_Id { get; set; }
        public string Id { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }

        public virtual ProductInformation ProductInformation { get; set; }
    }
}
