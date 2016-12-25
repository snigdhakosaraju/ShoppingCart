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
        private static List<Product> _shoppingCart;
        private static double _cartTotal;

        public static List<Product> GetAvailableProducts()
        {
            if(_products == null)
            {
                _products = new List<Product>()
                {
                    new Product(){ID=1, Name="apple", Description="Apple", HasOffer=true,OfferName="1Plus1", Price=0.45},
                    new Product(){ID=2, Name="orange", Description="Orange", HasOffer=true,OfferName="3For2", Price=0.65}

                };


            }

            return _products;

        }

        public static Product ValidateProduct(string itemName)
        {
          return   GetAvailableProducts().Where(x => x.Name == itemName.ToLower()).FirstOrDefault();

        }

        public static double CalculateCartTotal(List<string> items)
        {
            ClearCart();
            if (items == null || (items != null && items.Count == 0))
            {
                _cartTotal = 0.00;
                return _cartTotal;
            }

            foreach (string item in items)
            {
                Product saleItem = ValidateProduct(item);
                if (saleItem == null)
                {
                    _cartTotal += 0.00;
                }
                else
                {

                    switch (saleItem.OfferName)
                    {
                        case "1Plus1":
                            Apply2For1Price(saleItem);
                            break;
                        case "3For2":
                            Apply3For2Price(saleItem);
                            break;

                        default:
                            _cartTotal += saleItem.Price;
                            break;

                    }
                    _shoppingCart.Add(saleItem);
                }
            }


            return _cartTotal;
        }

        /// <summary>
        /// Buy 1 Get 1 Free
        /// </summary>
        /// <param name="saleItem"></param>

        private static void Apply2For1Price(Product saleItem)
        {
            if(_shoppingCart == null)
            {
                _cartTotal += saleItem.Price;
                return;
            }
            int itemsInCart = _shoppingCart.Where(x=> x.Name == saleItem.Name).Count();
           
            if( itemsInCart % 2 == 0)
            {
                _cartTotal += saleItem.Price;
            }
           


        }


        /// <summary>
        /// 3 for the price of 2 
        /// </summary>
        /// <param name="saleItem"></param>

        private static void Apply3For2Price(Product saleItem)
        {

            if(_shoppingCart == null)
            {
                _cartTotal += saleItem.Price;
                return;

            }
            int itemsInCart = _shoppingCart.Where(x => x.Name == saleItem.Name).Count();

            if (itemsInCart % 3 != 2)
            {
                _cartTotal += saleItem.Price;
            }



        }


        public static void PrintRecipt()
        {
            Console.WriteLine("Items in Cart:{0}", String.Join(",", _shoppingCart.Select(x => x.Name).ToArray()));
            Console.WriteLine("Total Amount : {0:N2}", _cartTotal);

        }


        /// <summary>
        /// Used for NewSale Or Clear Cart to reset cart
        /// </summary>
        public static void ClearCart()
        {
            if (_shoppingCart == null)
                _shoppingCart = new List<Product>();
            else
                _shoppingCart.Clear();

            _cartTotal = 0.00;

        }
    }
}
