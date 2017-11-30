using CRUD.SQLiteEF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CRUD.SQLiteEF.DAL
{
    public class ProductInformationRepository : BaseRepository
    {
        ProductInformationContext _context;

        public ProductInformationRepository()
        {
            _context = new ProductInformationContext(conStringName);
        }

        public int Create(ProductInformation productInfo)
        {
            _context.Set<ProductInformation>().Add(productInfo);
            return _context.SaveChanges();
        }

        public List<ProductInformation> Read()
        {
            return _context.Set<ProductInformation>()
                .Include(x => x.PriceRange)
                .Include(x => x.SupportDocuments)
                .Include(x => x.ProductSpecification)
                .Include(x => x.ProductRelatedItem)
                //.Include(x => x.RelatedAccessories)
                //.Include(x => x.RelatedInstruments)
                //.Include(x => x.RelatedServices)
                //.Include(x => x.RelatedWarranties)
                .Include(x => x.ProductDimensions)
                .Include(x => x.ProductModelSize)
                .Include(x => x.Applications)
                .ToList();
        }

        public int Update(ProductInformation productInfo)
        {
            var prodInfoUpdate = _context.Set<ProductInformation>().SingleOrDefault(x => x.Id == productInfo.Id);
            prodInfoUpdate.Model = productInfo.Model;
            prodInfoUpdate.StockId = productInfo.StockId;

            //product dimensions
            prodInfoUpdate.ProductDimensions = new ProductDimensions()
            {
                Height = productInfo.ProductDimensions.Height,
                Length = productInfo.ProductDimensions.Length,
                WeightLb = productInfo.ProductDimensions.WeightLb,
                WeightOz = productInfo.ProductDimensions.WeightOz,
                Width = productInfo.ProductDimensions.Width
            };

            prodInfoUpdate.ProductModelSize = new ProductModelSize()
            {
                Description = productInfo.ProductModelSize.Description,
                Model = productInfo.ProductModelSize.Model,
                Id = productInfo.ProductModelSize.Id
            };

            var priceRangeTemp = UpdatePriceRange(productInfo);
            var supportDocTemp = UpdateSupportDoc(productInfo);
            var specChannelTemp = UpdateProductSpecChannel(productInfo);
            var alternativeModelsTemp = UpdateProductRelatedItem(productInfo, "ProductRelatedItem");
            //var relatedAccessoriesTemp = UpdateProductRelatedItem(productInfo.RelatedAccessories);
            //var relatedInstrumentsTemp = UpdateProductRelatedItem(productInfo.RelatedInstruments);
            //var relatedServicesTemp = UpdateProductRelatedItem(productInfo.RelatedServices);
            //var relatedWarrantiesTemp = UpdateProductRelatedItem(productInfo.RelatedWarranties);
            var applicationTemp = UpdateProductApplication(productInfo);
            var mediaTemp = UpdateProductMedia(productInfo);

            prodInfoUpdate.PriceRange.Clear();
            prodInfoUpdate.SupportDocuments.Clear();
            prodInfoUpdate.ProductSpecification.Clear();
            prodInfoUpdate.ProductRelatedItem.Clear();
            //prodInfoUpdate.RelatedAccessories.Clear();
            //prodInfoUpdate.RelatedInstruments.Clear();
            //prodInfoUpdate.RelatedServices.Clear();
            //prodInfoUpdate.RelatedWarranties.Clear();
            prodInfoUpdate.Applications.Clear();
            prodInfoUpdate.ProductMedia.Clear();

            prodInfoUpdate.PriceRange.AddRange(priceRangeTemp);
            prodInfoUpdate.SupportDocuments.AddRange(supportDocTemp);
            prodInfoUpdate.ProductSpecification.AddRange(specChannelTemp);
            prodInfoUpdate.ProductRelatedItem.AddRange(alternativeModelsTemp);
            //prodInfoUpdate.RelatedAccessories.AddRange(relatedAccessoriesTemp);
            //prodInfoUpdate.RelatedInstruments.AddRange(relatedInstrumentsTemp);
            //prodInfoUpdate.RelatedServices.AddRange(relatedServicesTemp);
            //prodInfoUpdate.RelatedWarranties.AddRange(relatedWarrantiesTemp);
            prodInfoUpdate.Applications.AddRange(applicationTemp);
            prodInfoUpdate.ProductMedia.AddRange(mediaTemp);

            _context.Set<ProductInformation>().Attach(prodInfoUpdate);
            _context.Entry(prodInfoUpdate).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        public int Delete(ProductInformation productInfo)
        {
            var prodInfoTemp = Read().SingleOrDefault(x => x.Id == productInfo.Id);
            _context.Set<ProductInformation>().Remove(prodInfoTemp);
            return _context.SaveChanges();
        }

        private List<ProductRelatedItem> UpdateProductRelatedItem(ProductInformation productInfo, string modelName)
        {
            var temp = new List<ProductRelatedItem>();
            var prodRelatedItems = (List<ProductRelatedItem>)productInfo.GetType().GetProperty(modelName).GetValue(productInfo, null);
            foreach (var item in prodRelatedItems)
            {
                var existingProd = Read().SingleOrDefault(x => x.Id == productInfo.Id);
                var existingRi = (List<ProductRelatedItem>)existingProd.GetType().GetProperty(modelName).GetValue(existingProd, null);
                var existingSpecificRi = existingRi.SingleOrDefault(x => x.Id.Equals(item.Id));

                existingSpecificRi.Capacity = item.Capacity;
                existingSpecificRi.Category = item.Category;
                existingSpecificRi.CategoryDefinition = item.CategoryDefinition;
                existingSpecificRi.Definition = item.Definition;
                existingSpecificRi.InStock = item.InStock;
                existingSpecificRi.Model = item.Model;
                existingSpecificRi.ParentId = item.ParentId;
                existingSpecificRi.Price = item.Price;
                existingSpecificRi.ProductCode = item.ProductCode;
                existingSpecificRi.Rate = item.Rate;
                existingSpecificRi.StockId = item.StockId;

                temp.Add(existingSpecificRi);
            }

            return temp;
        }

        private List<ProductApplication> UpdateProductApplication(ProductInformation productInfo)
        {
            var temp = new List<ProductApplication>();
            foreach (var item in productInfo.Applications)
            {
                var existingProd = Read().SingleOrDefault(x => x.Id == productInfo.Id);
                var existingPi = existingProd.Applications.SingleOrDefault(x => x.Id.Equals(item.Id));

                existingPi.Image = item.Image;
                existingPi.Name = item.Name;
                existingPi.Priority = item.Priority;
                existingPi.Title = item.Title;
                existingPi.Type = item.Type;

                temp.Add(existingPi);
            }

            return temp;
        }

        private List<ProductMedia> UpdateProductMedia(ProductInformation productInfo)
        {
            var temp = new List<ProductMedia>();
            foreach (var item in productInfo.ProductMedia)
            {
                var existingProd = Read().SingleOrDefault(x => x.Id == productInfo.Id);
                var existingPm = existingProd.ProductMedia.SingleOrDefault(x => x.Id.Equals(item.Id));

                existingPm.MediaType = item.MediaType;
                existingPm.Title = item.Title;
                existingPm.Url = item.Url;

                temp.Add(existingPm);
            }

            return temp;
        }

        private List<ProductSpecificationChannel> UpdateProductSpecChannel(ProductInformation productInfo)
        {
            var objTemp = new List<ProductSpecificationChannel>();
            foreach (var item in productInfo.ProductSpecification)
            {
                var existingProd = Read().SingleOrDefault(x => x.Id == productInfo.Id);
                var existingRecord = existingProd.ProductSpecification.SingleOrDefault(x => x.Id.Equals(item.Id));

                existingRecord.Channel = item.Channel;

                //existingRecord.Specifications.Clear();
                var objTemp2 = new List<ProductSpecification>();
                foreach (var item2 in item.Specifications)
                {
                    var existingSpec = existingRecord.Specifications.SingleOrDefault(x => x.Id.Equals(item2.Id));

                    existingSpec.Channel = item2.Channel;
                    existingSpec.Max = item2.Max;
                    existingSpec.Min = item2.Min;
                    existingSpec.Specification = item2.Specification;
                    existingSpec.ToolTip = item2.ToolTip;
                    existingSpec.Typ = item2.Typ;
                    existingSpec.Unit = item2.Unit;

                    objTemp2.Add(existingSpec);
                }

                existingRecord.Specifications = objTemp2;
                objTemp.Add(existingRecord);
            }

            return objTemp;
        }


        private List<ProductSupportDocuments> UpdateSupportDoc(ProductInformation productInfo)
        {
            var supportDocTemp = new List<ProductSupportDocuments>();
            foreach (var item in productInfo.SupportDocuments)
            {
                var existingProd = Read().SingleOrDefault(x => x.Id == productInfo.Id);
                var existingSd = existingProd.SupportDocuments.SingleOrDefault(x => x.Id.Equals(item.Id));

                existingSd.DocumentTitle = item.DocumentTitle;
                existingSd.DocumentUrl = item.DocumentUrl;

                supportDocTemp.Add(existingSd);
            }

            return supportDocTemp;
        }

        private List<PriceRange> UpdatePriceRange(ProductInformation productInfo)
        {
            var priceRangeTemp = new List<PriceRange>();
            foreach (var priceRange in productInfo.PriceRange)
            {
                var existingProd = Read().SingleOrDefault(x => x.Id == productInfo.Id);
                var existingPr = existingProd.PriceRange.SingleOrDefault(x => x.Id.Equals(priceRange.Id));

                existingPr.OriginalPrice = priceRange.OriginalPrice;
                existingPr.DiscountedPrice = priceRange.DiscountedPrice;
                existingPr.Price = priceRange.Price;
                existingPr.QtyFrom = priceRange.QtyFrom;
                existingPr.QtyTo = priceRange.QtyTo;
                existingPr.StockId = priceRange.StockId;

                priceRangeTemp.Add(existingPr);
            }

            return priceRangeTemp;
        }
    }
}
