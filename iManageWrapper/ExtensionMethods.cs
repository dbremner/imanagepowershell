using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iml = IManage;

namespace iManageWrapper
{

    public static class ExtensionMethods
    {

        public static string Replace(this string source, char[] find, string replacewith)
        {
            StringBuilder sb = new StringBuilder(source);
            foreach (var f in find)
                sb.Replace(f.ToString(), replacewith);
            return sb.ToString();
        }

        public static List<iManSession> ToList(this iml.IManSessions source)
        {
            List<iManSession> results = new List<iManSession>(source.Count);
            foreach (var s in source) results.Add(new iManSession((iml.IManSession)s));
            return results;
        }

        public static List<iManDocument> ToList(this iml.IManDocuments source, iManDatabase Database)
        {
            List<iManDocument> results = new List<iManDocument>(source.Count);
            foreach (var s in source) results.Add(new iManDocument((iml.IManDocument)s, Database));
            return results;
        }

        public static List<iManDatabase> ToList(this iml.IManDatabases source)
        {
            List<iManDatabase> results = new List<iManDatabase>(source.Count);
            foreach (var s in source) results.Add(new iManDatabase((iml.IManDatabase)s));
            return results;
        }

        public static List<iManWorkspace> ToList(this iml.IManWorkspaces source, iManDatabase Database)
        {
            List<iManWorkspace> results = new List<iManWorkspace>(source.Count);
            foreach (var s in source) results.Add(new iManWorkspace((iml.IManWorkspace)s, Database));
            return results;
        }

        public static List<iManFolder> ToList(this iml.IManFolders source, iManDatabase Database)
        {
            List<iManFolder> results = new List<iManFolder>(source.Count);
            foreach (var s in source) results.Add(new iManFolder((iml.IManFolder)s, Database));
            return results;
        }

        public static List<iManWorkspace> ToWorkspaceList(this iml.IManFolders source, iManDatabase Database)
        {
            List<iManWorkspace> results = new List<iManWorkspace>(source.Count);
            foreach (var s in source) results.Add(new iManWorkspace((iml.IManWorkspace)s, Database));
            return results;
        }

        public static List<iml.IManCustomAttribute> ToList(this iml.IManCustomAttributes source)
        {
            List<iml.IManCustomAttribute> results = new List<iml.IManCustomAttribute>(source.Count);
            foreach (var s in source) results.Add((iml.IManCustomAttribute)s);
            return results;
        }

        public static List<iManDocument> ToDocumentList(this iml.IManContents source, iManDatabase Database)
        {
            List<iManDocument> results = new List<iManDocument>(source.Count);
            foreach (var s in source) results.Add(new iManDocument((iml.IManDocument)s, Database));
            return results;
        }

        public static List<iManDocumentHistory> ToList(this iml.IManHistoryList source, iManDatabase Database)
        {
            List<iManDocumentHistory> results = new List<iManDocumentHistory>(source.Count);
            foreach (var s in source) results.Add(new iManDocumentHistory((iml.IManDocumentHistory)s, Database));
            return results;
        }

        public static List<iManUser> ToList(this iml.IManUsers source, iManDatabase Database)
        {
            List<iManUser> results = new List<iManUser>(source.Count);
            foreach (var s in source) results.Add(new iManUser((iml.IManUser)s, Database));
            return results;
        }

    }

}