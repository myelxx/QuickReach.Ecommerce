using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReach.Ecommerce
{
    public class InvalidFormatPasswordException : ApplicationException // <-- implents this to use exception
    {
        public InvalidFormatPasswordException() : base()
        {
                
        }

        public InvalidFormatPasswordException(string description)
        {
            
        }
    }
}
