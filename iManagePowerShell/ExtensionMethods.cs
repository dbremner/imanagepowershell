using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using iml = IManage;

namespace iManagePowerShell
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
            for (int i = 1; i <= source.Count; i++)
            {
                results.Add(new iManSession((iml.IManSession)source.ItemByIndex(i)));
            }
            return results;
        }

        public static List<iManDocument> ToList(this iml.IManDocuments source, iManDatabase Database)
        {
            List<iManDocument> results = new List<iManDocument>(source.Count);
            for (int i = 1; i <= source.Count; i++)
            {
                results.Add(new iManDocument((iml.IManDocument)source.ItemByIndex(i), Database));
            }
            return results;
        }

        public static List<iManDatabase> ToList(this iml.IManDatabases source)
        {
            List<iManDatabase> results = new List<iManDatabase>(source.Count);
            for (int i = 1; i <= source.Count; i++)
            {
                results.Add(new iManDatabase((iml.IManDatabase)source.ItemByIndex(i)));
            }
            return results;
        }

        public static List<iManWorkspace> ToList(this iml.IManWorkspaces source, iManDatabase Database)
        {
            List<iManWorkspace> results = new List<iManWorkspace>(source.Count);
            for (int i = 1; i <= source.Count; i++)
            {
                results.Add(new iManWorkspace((iml.IManWorkspace)source.ItemByIndex(i), Database));
            }
            return results;
        }

        public static List<iManFolder> ToList(this iml.IManFolders source, iManDatabase Database)
        {
            List<iManFolder> results = new List<iManFolder>(source.Count);
            for (int i = 1; i <= source.Count; i++)
            {
                results.Add(new iManFolder((iml.IManFolder)source.ItemByIndex(i), Database));
            }
            return results;
        }

        public static List<iManWorkspace> ToWorkspaceList(this iml.IManFolders source, iManDatabase Database)
        {
            List<iManWorkspace> results = new List<iManWorkspace>(source.Count);
            for (int i = 1; i <= source.Count; i++)
            {
                //if (source.ObjectType.ObjectType == iml.imObjectType.imTypeWorkspace)
                results.Add(new iManWorkspace((iml.IManWorkspace)source.ItemByIndex(i), Database));
            }
            return results;
        }

        public static List<iml.IManCustomAttribute> ToList(this iml.IManCustomAttributes source)
        {
            List<iml.IManCustomAttribute> results = new List<iml.IManCustomAttribute>(source.Count);
            for (int i = 1; i <= source.Count; i++)
            {
                results.Add((iml.IManCustomAttribute)source.ItemByIndex(i));
            }
            return results;
        }

        public static List<iManDocument> ToDocumentList(this iml.IManContents source, iManDatabase Database)
        {
            List<iManDocument> results = new List<iManDocument>(source.Count);
            for (int i = 1; i <= source.Count; i++)
            {
                results.Add(new iManDocument((iml.IManDocument)source.ItemByIndex(i), Database));
            }
            return results;
        }

        public static List<iManDocumentHistory> ToList(this iml.IManHistoryList source, iManDatabase Database)
        {
            List<iManDocumentHistory> results = new List<iManDocumentHistory>(source.Count);
            for (int i = 1; i < source.Count; i++)
            {
                results.Add(new iManDocumentHistory(source.ItemByIndex(i), Database));
            }
            return results;
        }

        public static List<iManUser> ToList(this iml.IManUsers source, iManDatabase Database)
        {
            List<iManUser> results = new List<iManUser>(source.Count);
            for (int i = 1; i <= source.Count; i++)
            {
                results.Add(new iManUser((iml.IManUser)source.ItemByIndex(i), Database));
            }
            return results;
        }

    }

}