using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace QuickReach.Ecommerce
{
    public class LoginManager : ILoginManager
    {
        public bool Validate(string username, string password)
        {
            #region Validate Password 
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            if (password.Length < 8)
            {
                return false;
            }

            if (!password.Contains("@") || !password.ToCharArray().Any((c) => char.IsDigit(c)) || !password.ToCharArray().Any((c) => char.IsPunctuation(c)))
            {
                return false;
            }

            if (!password.ToCharArray().Any((c) => char.IsDigit(c)))
            {
                return false;
            }

            if (!password.ToCharArray().Any((c) => char.IsUpper(c)))
            {
                return false;
            }

            if (!password.ToCharArray().Any((c) => char.IsLower(c)))
            {
                return false;
            }
            #endregion

            #region Validate Username
            if (string.IsNullOrEmpty(username))
            {
                return false;
            }

            if (username.Length < 7)
            {
                return false;
            }

            //if (!Regex.IsMatch(username, @"\w{1,}@\w{1,}\.\w{2,}"))
            //{
            //    return false;
            //}

            var isValidPatten = Regex.Match(username, @"\w{1,}@\w{1,}\.\w{2,}");
            if (!isValidPatten.Success)
            {
                return false;
            }
            #endregion

            return true;
        }

    }
}
