using CRUD.SQLiteEF.Entities;
using System.Data.Entity;

namespace CRUD.SQLiteEF.DAL
{
    public class ProductInformationModelConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            ConfigureProductInformationEntity(modelBuilder);
            ConfigureProductDimensions(modelBuilder);
            ConfigureProductModelSize(modelBuilder);
            ConfigurePriceRangeModel(modelBuilder);
            ConfigureProductDimension(modelBuilder);
            ConfigureProductSupportDocuments(modelBuilder);
            ConfigureProductSpecificationChannel(modelBuilder);
            ConfigureProductSpecification(modelBuilder);
            ConfigureProductRelatedItem(modelBuilder);
            //ConfigureRelatedAccessories(modelBuilder);
            //ConfigureRelatedInstruments(modelBuilder);
            //ConfigureRelatedServices(modelBuilder);
            //ConfigureRelatedWaranties(modelBuilder);
            ConfigureProductApplication(modelBuilder);
            ConfigureProductMedia(modelBuilder);
        }

        private static void ConfigureProductInformationEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductInformation>().HasKey(x => x.Id);

            modelBuilder.Entity<ProductInformation>()
                        .HasRequired(s => s.ProductDimensions)
                        .WithRequiredPrincipal(ad => ad.ProductInformation)
                        .WillCascadeOnDelete(true);

            modelBuilder.Entity<ProductInformation>()
                       .HasRequired(s => s.ProductModelSize)
                       .WithRequiredPrincipal(ad => ad.ProductInformation)
                       .WillCascadeOnDelete(true);

            //modelBuilder.Entity<ProductInformation>()
            //    .HasRequired(t => t.PriceRange)
            //    .WithMany()
            //    .WillCascadeOnDelete(true);

            //modelBuilder.Entity<ProductInformation>()
            //   .HasRequired(t => t.ProductDimensions)
            //   .WithRequiredPrincipal(x => x.ProductInformation)
            //   .WillCascadeOnDelete(true);
        }
        private static void ConfigureProductDimensions(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDimensions>()
                .HasKey(e => e.ProductInformation_Id);
           
        }
        private static void ConfigureProductModelSize(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModelSize>()
                .HasKey(e => e.ProductInformation_Id);

        }
        private static void ConfigurePriceRangeModel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PriceRange>().HasKey(x => x.Id);

            modelBuilder.Entity<PriceRange>()
                .HasRequired(t => t.ProductInformation)
                .WithMany(t => t.PriceRange)
                .WillCascadeOnDelete(true);
        }

        private static void ConfigureProductSupportDocuments(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSupportDocuments>().HasKey(x => x.Id);

            modelBuilder.Entity<ProductSupportDocuments>()
                .HasRequired(t => t.ProductInformation)
                .WithMany(t => t.SupportDocuments)
                .WillCascadeOnDelete(true);
        }

        private static void ConfigureProductSpecificationChannel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSpecificationChannel>().HasKey(x => x.Id);

            modelBuilder.Entity<ProductSpecificationChannel>()
                .HasRequired(t => t.ProductInformation)
                .WithMany(t => t.ProductSpecification)
                .WillCascadeOnDelete(true);
        }

        private static void ConfigureProductSpecification(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSpecification>().HasKey(x => x.Id);

            modelBuilder.Entity<ProductSpecification>()
                .HasRequired(t => t.ProductSpecificationChannel)
                .WithMany(t => t.Specifications)
                .WillCascadeOnDelete(true);
        }

        private static void ConfigureProductRelatedItem(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductRelatedItem>().HasKey(x => x.Id);

            modelBuilder.Entity<ProductRelatedItem>()
                .HasRequired(t => t.ProductInformation)
                .WithMany(t => t.ProductRelatedItem)
                .WillCascadeOnDelete(true);
        }

        private static void ConfigureProductApplication(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductApplication>().HasKey(x => x.Id);

            modelBuilder.Entity<ProductApplication>()
                .HasRequired(t => t.ProductInformation)
                .WithMany(t => t.Applications)
                .WillCascadeOnDelete(true);
        }

        private static void ConfigureProductMedia(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductMedia>().HasKey(x => x.Id);

            modelBuilder.Entity<ProductMedia>()
                .HasRequired(t => t.ProductInformation)
                .WithMany(t => t.ProductMedia)
                .WillCascadeOnDelete(true);
        }

        //private static void ConfigureRelatedAccessories(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ProductRelatedItem>().HasKey(x => x.Id);

        //    modelBuilder.Entity<ProductRelatedItem>()
        //        .HasRequired(t => t.ProductInformation)
        //        .WithMany(t => t.RelatedAccessories)
        //        .WillCascadeOnDelete(true);
        //}

        //private static void ConfigureRelatedInstruments(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ProductRelatedItem>().HasKey(x => x.Id);

        //    modelBuilder.Entity<ProductRelatedItem>()
        //        .HasRequired(t => t.ProductInformation)
        //        .WithMany(t => t.RelatedInstruments)
        //        .WillCascadeOnDelete(true);
        //}

        //private static void ConfigureRelatedServices(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ProductRelatedItem>().HasKey(x => x.Id);

        //    modelBuilder.Entity<ProductRelatedItem>()
        //        .HasRequired(t => t.ProductInformation)
        //        .WithMany(t => t.RelatedServices)
        //        .WillCascadeOnDelete(true);
        //}

        //private static void ConfigureRelatedWaranties(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ProductRelatedItem>().HasKey(x => x.Id);

        //    modelBuilder.Entity<ProductRelatedItem>()
        //        .HasRequired(t => t.ProductInformation)
        //        .WithMany(t => t.RelatedWarranties)
        //        .WillCascadeOnDelete(true);
        //}

        private static void ConfigureProductDimension(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ProductDimensions>()
            //    .HasRequired(x => x.ProductInformation)
            //    .WithRequiredPrincipal(x => x.ProductDimensions)
            //    .WillCascadeOnDelete(true);
        }
    }

   
}
