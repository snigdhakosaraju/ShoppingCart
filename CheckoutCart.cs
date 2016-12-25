using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class CheckoutCart: ICalcProvider
    {
        public List<Product> ShoppingCart;
        private double _cartTotal;

        public double CalculateCartTotal(List<string> items)
        {
            try
            {
                ClearCart();
                CalcProvider calcProvider = new CalcProvider();
                if (items == null || (items != null && items.Count == 0))
                {
                    _cartTotal = 0.00;
                    return _cartTotal;
                }

                foreach (string item in items)
                {
                    Product saleItem = POSEntities.ValidateProduct(item);
                    if (saleItem == null)
                    {
                        _cartTotal += 0.00;
                    }
                    else
                    {

                        switch (saleItem.OfferName)
                        {
                            case "1Plus1":
                                _cartTotal += calcProvider.Apply2For1Price(ShoppingCart, saleItem);
                                break;
                            case "3For2":
                                _cartTotal += calcProvider.Apply3For2Price(ShoppingCart, saleItem);
                                break;

                            default:
                                _cartTotal += saleItem.Price;
                                break;

                        }
                        ShoppingCart.Add(saleItem);
                    }
                }
            }catch(Exception exp)
            {
                ClearCart();
                throw exp;
            }
            finally
            {
                //clean objects which are not required
            }


            return _cartTotal;
        }


        public void PrintRecipt()
        {
            Console.WriteLine("Items in Cart:{0}", String.Join(",", ShoppingCart.Select(x => x.Name).ToArray()));
            Console.WriteLine("Total Amount : {0:N2}", _cartTotal);

        }

        public void ClearCart()
        {
            if (ShoppingCart == null)
                ShoppingCart = new List<Product>();
            else
                ShoppingCart.Clear();

            _cartTotal = 0.00;
        }
    }
}
