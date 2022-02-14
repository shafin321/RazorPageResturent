using System;
using System.Collections.Generic;
using System.Text;

namespace ResturentWebRazor.Core
{
  public  class CartItem
    {
        public int Id { get; set; }
        public Resturant Resturant { get; set; }
        public int Amount { get; set; }
    }
}
