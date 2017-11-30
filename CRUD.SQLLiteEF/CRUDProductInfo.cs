using CRUD.SQLite.BLL;
using CRUD.SQLiteEF.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace CRUD.SQLLiteEF
{
    public class CRUDProductInfo
    {
        public static void Run()
        {
            File.Delete(@".\Database\SQLLIteWithEF.db");
            ProductInformationService prodInfoService;
            ProductInformation prodInfoData = new ProductInformation()
            {
                Id = 2,
                Model = "K33",
                StockId = "STK001",
            };

            prodInfoData.PriceRange.Add(new PriceRange()
            {
                Id = 1,
                DiscountedPrice = "DiscountPRice",
                OriginalPrice = 120,
                Price = 100,
                QtyFrom = "QtyFrom",
                QtyTo = "QtyTo",
                StockId = "STK001"
            });

            prodInfoData.SupportDocuments.Add(new ProductSupportDocuments()
            {
                Id = 1,
                DocumentTitle = "Title",
                DocumentUrl = "DocUrl"
            });


            prodInfoData.ProductSpecification.Add(new ProductSpecificationChannel()
            {
                Id = 1,
                Channel = "Channel",
                Specifications = new List<ProductSpecification>() { new ProductSpecification
                    {
                        Channel = "Channel",
                        Id = 1,
                        Max = "Max",
                        Min = "Min",
                        Specification = "Specification",
                        ToolTip = "ToolTip",
                        Typ = "Typ",
                        Unit = "Unit"
                    }
                }
            });

            var prodRelatedItem = new ProductRelatedItem()
            {
                Id = 1,
                Category = "Category",
                Capacity = "Capacity",
                CategoryDefinition = "CategoryDefinition",
                Definition = "Definition",
                InStock = 1,
                Model = "Model",
                ParentId = 1,
                Price = "1",
                ProductCode = "ProductCode",
                Rate = 1,
                StockId = "1"
            };


            prodInfoData.ProductRelatedItem.Add(prodRelatedItem);
            //prodInfoData.RelatedAccessories.Add(prodRelatedItem);
            //prodInfoData.RelatedInstruments.Add(prodRelatedItem);
            //prodInfoData.RelatedServices.Add(prodRelatedItem);
            //prodInfoData.RelatedWarranties.Add(prodRelatedItem);
            prodInfoData.Applications.Add(new ProductApplication()
            {
                Id = 1,
                Image = "Image",
                Name = "Name",
                Priority = 1,
                Title = "Title",
                Type = "Type"
            });

            prodInfoData.ProductMedia.Add(new ProductMedia()
            {
                Id = 1,
                MediaType = "MediaType",
                Title = "Title",
                Url = "Url"
            });

            prodInfoData.ProductDimensions = new ProductDimensions()
            {
                Height = "1",
                Length = "1",
                WeightLb = "1",
                WeightOz = "1",
                Width = "1",
            };

            prodInfoData.ProductModelSize = new ProductModelSize()
            {
                Id = "PMZ1",
                Description = "Desc",
                Model = "Model"
            };

            //Create
            prodInfoService = new ProductInformationService();
            prodInfoService.Create(prodInfoData);

            Console.WriteLine("Record After Insert :");
            var data = prodInfoService.Read();
            DisplayData(data);

            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();

            ProductInformation prodInfoDataUpdate = new ProductInformation()
            {
                Id = 1,
                Model = "K34",
                StockId = "STK002"
            };

            prodInfoDataUpdate.PriceRange.Add(new PriceRange()
            {
                Id = 1,
                DiscountedPrice = "DiscountPRice2",
                OriginalPrice = 121,
                Price = 101,
                QtyFrom = "QtyFrom2",
                QtyTo = "QtyTo2",
                StockId = "STK002"
            });

            prodInfoDataUpdate.SupportDocuments.Add(new ProductSupportDocuments()
            {
                Id = 1,
                DocumentTitle = "Title2",
                DocumentUrl = "DocUrl2"
            });

            prodInfoDataUpdate.ProductSpecification.Add(new ProductSpecificationChannel()
            {
                Id = 1,
                Channel = "Channel2",
                Specifications = new List<ProductSpecification>() { new ProductSpecification
                    {
                        Channel = "Channel2",
                        Id = 1,
                        Max = "Max2",
                        Min = "Min2",
                        Specification = "Specification2",
                        ToolTip = "ToolTip2",
                        Typ = "Typ2",
                        Unit = "Unit2"
                    }
                }
            });

            var prodRelatedItemUpdate = new ProductRelatedItem()
            {
                Id = 1,
                Category = "Category2",
                Capacity = "Capacity2",
                CategoryDefinition = "CategoryDefinition2",
                Definition = "Definition2",
                InStock = 2,
                Model = "Model2",
                ParentId = 2,
                Price = "2",
                ProductCode = "ProductCode2",
                Rate = 1,
                StockId = "2"
            };

            prodInfoDataUpdate.ProductRelatedItem.Add(prodRelatedItemUpdate);
            //prodInfoData.RelatedAccessories.Add(prodRelatedItemUpdate);
            //prodInfoData.RelatedInstruments.Add(prodRelatedItemUpdate);
            //prodInfoData.RelatedServices.Add(prodRelatedItemUpdate);
            //prodInfoData.RelatedWarranties.Add(prodRelatedItemUpdate);
            prodInfoDataUpdate.Applications.Add(new ProductApplication()
            {
                Id = 1,
                Image = "Image2",
                Name = "Name2",
                Priority = 2,
                Title = "Title2",
                Type = "Type2"
            });
            prodInfoDataUpdate.ProductMedia.Add(new ProductMedia()
            {
                Id = 1,
                MediaType = "MediaType2",
                Title = "Title2",
                Url = "Url2"
            });
            prodInfoDataUpdate.ProductDimensions = new ProductDimensions()
            {
                ProductInformation_Id = 1,
                Height = "2",
                Length = "2",
                WeightLb = "2",
                WeightOz = "2",
                Width = "2",
            };
            prodInfoDataUpdate.ProductModelSize = new ProductModelSize()
            {
                Id = "PMZ2",
                Description = "Desc",
                Model = "Model"
            };
            //Update
            prodInfoService.Update(prodInfoDataUpdate);

            Console.WriteLine("See Record After Update in database,  press Enter to continue to delete");
            Console.ReadLine();

            //data = prodInfoService.Read();
            //DisplayData(data);

            //Delete
            ProductInformation prodInfoDataDelete= new ProductInformation()
            {
                Id = 1,
            };
            prodInfoService.Delete(prodInfoDataDelete);

            Console.WriteLine("See Record After Delete in database");
            Console.ReadLine();
            //data = prodInfoService.Read();
            //DisplayData(data);
        }

        private static void DisplayData(List<ProductInformation> data)
        {
            foreach (var item in data)
            {
                //dynamic
                //Type t = item.GetType();
                //PropertyInfo[] pi = t.GetProperties();
                //foreach (PropertyInfo p in pi)
                //{
                //    Console.WriteLine(p.Name + "                   :" + p.GetValue(item));
                //}

                //Static
                Console.Write(string.Format("ID : {0}  Model : {1} StockId : {2} {3}", item.Id, item.Model,item.StockId,Environment.NewLine));
            }

        }
    }
}
