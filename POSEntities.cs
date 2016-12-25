using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public static class POSEntities
    {

        private static List<Product> _products;
       

        public static List<Product> GetAvailableProducts()
        {
            try
            {
                if (_products == null)
                {
                    _products = new List<Product>()
                {
                    new Product(){ID=1, Name="apple", Description="Apple", HasOffer=true,OfferName="1Plus1", Price=0.45},
                    new Product(){ID=2, Name="orange", Description="Orange", HasOffer=true,OfferName="3For2", Price=0.65}

                };


                }
            }catch(Exception exp)
            {
                throw exp;
            }

            return _products;

        }

        public static Product ValidateProduct(string itemName)
        {
          return   GetAvailableProducts().Where(x => x.Name == itemName.ToLower()).FirstOrDefault();

        }

       
    }
}
