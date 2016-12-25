using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public interface ICalcProvider
    {
         double CalculateCartTotal(List<string> items);
    }

    public class CalcProvider : ICalcProvider
    {
        private double _cartTotal = 0.00;

        /// <summary>
        /// Buy 1 Get 1 Free
        /// </summary>
        /// <param name="saleItem"></param>

        public double Apply2For1Price(List<Product> _shoppingCart, Product saleItem)
        {
            if (_shoppingCart == null)
            {
                return saleItem.Price;
               
            }
            int itemsInCart = _shoppingCart.Where(x => x.Name == saleItem.Name).Count();

            if (itemsInCart % 2 == 0)
            {
                return saleItem.Price;
            }

            return 0.00;


        }


        /// <summary>
        /// 3 for the price of 2 
        /// </summary>
        /// <param name="saleItem"></param>

        public double Apply3For2Price(List<Product> _shoppingCart,Product saleItem)
        {

            if (_shoppingCart == null)
            {
                return saleItem.Price;
              

            }
            int itemsInCart = _shoppingCart.Where(x => x.Name == saleItem.Name).Count();

            if (itemsInCart % 3 != 2)
            {
                return saleItem.Price;
            }

            return 0.00;

        }





        public double CalculateCartTotal(List<string> items)
        {
            throw new NotImplementedException();
        }
    }
}
