using System;
using System.Collections.Generic;
using System.Linq;
namespace QuickReach.Ecommerce
{
    public class LoginManager
    {
        public bool Validate(string username, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            if (password.Length < 8)
            {
                return false;
            }

            if(!password.ToCharArray()
                .Any((c) => char.IsSymbol(c)))
            {
                return false;
            }

            if (!password.ToCharArray()
                .Any((c) => char.IsDigit(c)))
            {
                return false;
            }

            //if (!password.ToCharArray()
            //    .Any((c) => char.IsUpper(c)))
            //{
            //    return false;
            //}

            //if (!password.ToCharArray()
            //    .Any((c) => char.IsLower(c)))
            //{
            //    return false;
            //}

            return true;
        }

    }
}
