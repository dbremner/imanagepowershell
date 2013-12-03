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

        public static List<iManSession> ToList(this iml.IManSessions source)
        {
            var results = new List<iManSession>(source.Count);
            foreach (var s in source) results.Add(new iManSession((iml.IManSession)s));
            return results;
        }

        public static List<iManDocument> ToList(this iml.IManDocuments source, iManDatabase database)
        {
            var results = new List<iManDocument>(source.Count);
            foreach (var s in source) results.Add(new iManDocument((iml.IManDocument)s, database));
            return results;
        }

        public static List<iManDatabase> ToList(this iml.IManDatabases source)
        {
            var results = new List<iManDatabase>(source.Count);
            foreach (var s in source) results.Add(new iManDatabase((iml.IManDatabase)s));
            return results;
        }

        public static List<iManWorkspace> ToList(this iml.IManWorkspaces source, iManDatabase database)
        {
            var results = new List<iManWorkspace>(source.Count);
            foreach (var s in source) results.Add(new iManWorkspace((iml.IManWorkspace)s, database));
            return results;
        }

        public static List<iManFolder> ToList(this iml.IManFolders source, iManDatabase database)
        {
            var results = new List<iManFolder>(source.Count);
            foreach (var s in source) results.Add(new iManFolder((iml.IManFolder)s, database));
            return results;
        }

        public static List<iManWorkspace> ToWorkspaceList(this iml.IManFolders source, iManDatabase database)
        {
            var results = new List<iManWorkspace>(source.Count);
            foreach (var s in source) results.Add(new iManWorkspace((iml.IManWorkspace)s, database));
            return results;
        }

        public static List<iml.IManCustomAttribute> ToList(this iml.IManCustomAttributes source)
        {
            var results = new List<iml.IManCustomAttribute>(source.Count);
            foreach (var s in source) results.Add((iml.IManCustomAttribute)s);
            return results;
        }

        public static List<iManDocument> ToDocumentList(this iml.IManContents source, iManDatabase database)
        {
            var results = new List<iManDocument>(source.Count);
            foreach (var s in source) results.Add(new iManDocument((iml.IManDocument)s, database));
            return results;
        }

        public static List<iManDocumentHistory> ToList(this iml.IManHistoryList source, iManDatabase database)
        {
            var results = new List<iManDocumentHistory>(source.Count);
            foreach (var s in source) results.Add(new iManDocumentHistory((iml.IManDocumentHistory)s, database));
            return results;
        }

        public static List<iManUser> ToList(this iml.IManUsers source, iManDatabase database)
        {
            var results = new List<iManUser>(source.Count);
            foreach (var s in source) results.Add(new iManUser((iml.IManUser)s, database));
            return results;
        }

    }

}