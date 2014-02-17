using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using iml = IManage;

namespace iManageWrapper
{

    public static class ExtensionMethods
    {

        public static string Replace(this string source, IEnumerable<char> find, string replacewith)
        {
            var sb = new StringBuilder(source);
            foreach (var f in find)
                sb.Replace(f.ToString(CultureInfo.InvariantCulture), replacewith);
            return sb.ToString();
        }

        public static string CapitalizeFirstLetter(this string str)
        {
            if (str == null) return str;
            if (str.Length > 1)
                str = char.ToUpper(str[0]) + str.Substring(1);
            else
                str = str.ToUpper();
            return str;
        }
    }

}