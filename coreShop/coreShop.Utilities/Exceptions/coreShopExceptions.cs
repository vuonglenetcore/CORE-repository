using System;
using System.Collections.Generic;
using System.Text;

namespace coreShop.Utilities.Exceptions
{
    public class coreShopExceptions : Exception
    {
        public coreShopExceptions()
        {

        }

        public coreShopExceptions(string message)
        {

        }

        public coreShopExceptions(string message, Exception inner): base(message, inner)
        {

        }
    }
}
