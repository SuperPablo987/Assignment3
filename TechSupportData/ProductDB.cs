using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSupportData
{
    /*
    * The purpose of this application is to interface with the product table in the connected database.
    * The application will control product code, name, version, release date and will handled pulling data from, adding data to and deleting from the database.
    * Created on Apr 7, 2023
    * Author: Peter Thiel
    */
    /// <summary>
    /// repository of methods to work  with Products table
    /// </summary>
    public class ProductDB
    {
        public static List<ProductDTO> GetProducts()
        {
            List<ProductDTO> products = new List<ProductDTO>(); // empty list
            using (TechSupportContext dB = new TechSupportContext())
            {
                products = dB.Products.
                    Select(p => new ProductDTO()
                    {
                        ProductCode = p.ProductCode,
                        Name = p.Name,
                        Version = p.Version,
                        ReleaseDate = p.ReleaseDate
                    }).ToList();
                
            }
            return products;
        }
        /// <summary>
        /// get a list of product codes
        /// </summary>
        /// <returns>list of product codes</returns>
        public static List<string> GetProductCodes()
        {
            List<string> codes = new List<string>();
            using (TechSupportContext dB = new TechSupportContext())
            {
                codes = dB.Products.Select(p => p.ProductCode).ToList();
            }
            return codes;
        }

        /// <summary>
        /// adds new product to the database
        /// </summary>
        /// <param name="newProd">new product to add</param>
        public static void AddProduct(Product newProd)
        {
            if (newProd != null)
            {
                using (TechSupportContext dB = new TechSupportContext())
                {
                    dB.Products.Add(newProd);
                    dB.SaveChanges();
                }
            }
        }
        /// <summary>
        /// update existing product with new data
        /// </summary>
        /// <param name="newProdData">new product data</param>
        public static void UpdateProduct(Product newProdData)
        {
            if (newProdData != null)
            {
                using (TechSupportContext dB = new TechSupportContext())
                {
                    // find the product to update in this context
                    Product prod = dB.Products.Find(newProdData.ProductCode);
                    if (prod != null) // it still exists
                    {
                        // code does not  change
                        prod.Name = newProdData.Name;
                        prod.Version = newProdData.Version;
                        prod.ReleaseDate = newProdData.ReleaseDate;
                        dB.SaveChanges();
                    }
                }
            }
        }
        /// <summary>
        /// delete product
        /// </summary>
        /// <param name="productCode">code of the product to delete</param>
        public static void DeleteProduct(string productCode)
        {
            using (TechSupportContext dB = new TechSupportContext())
            {
                Product prod = dB.Products.Find(productCode);
                if (prod != null)
                {
                    dB.Products.Remove(prod);
                    dB.SaveChanges();
                }
            }
        }

        public static Product FindProduct(string productCode)
        {
            Product product = null;
            using (TechSupportContext dB = new TechSupportContext())
            {
                product = dB.Products.Find(productCode);
            }
            return product;
        }
    }
}
