using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Provider;
using System.Text;

namespace iManagePowerShell
{
    public static class ExtensionMethods
    {
        public static IEnumerable<TSource> ConcatAll<TSource>(
    this IEnumerable<TSource> first,
    params IEnumerable<TSource>[] second)
        {
            return ConcatAllImpl(first, second);
        }

        private static IEnumerable<TSource> ConcatAllImpl<TSource>(
            IEnumerable<TSource> first,
            params IEnumerable<TSource>[] second)
        {
            if (first != null)
                foreach (var item in first)
                    yield return item;
            if (second != null)
                foreach (var item in second)
                    if (item != null)
                        foreach (var nestedItem in item)
                            yield return nestedItem;
        } 
    }
}
