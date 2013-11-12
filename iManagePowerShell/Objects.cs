using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Management.Automation;
using iml = IManage;

namespace iManagePowerShell
{
    public class iManServer
    {
        private iml.IManDMS me;

        private static Dictionary<string, iml.IManDMS> ServerList = new Dictionary<string, iml.IManDMS>();

        public iManServer(string Server)
        {
            iml.IManDMS SingletonServer;
            ServerList.TryGetValue(Server, out SingletonServer);
            if (SingletonServer == null)
            {
                me = new iml.ManDMS();
                ServerList.Add(Server, me);
                iml.IManSession s = me.Sessions.Add(Server);
                s.TrustedLogin();
            }
            else
            {
                me = SingletonServer;
            }
        }

        public iManServer(string Server, string Username, string Password)
        {
            iml.IManDMS SingletonServer;
            ServerList.TryGetValue(Server, out SingletonServer);
            if (SingletonServer == null)
            {
                me = new iml.ManDMS();
                ServerList.Add(Server, me);
                iml.IManSession s = me.Sessions.Add(Server);
                s.Login(Username, Password);
            }
            else
            {
                me = SingletonServer;
            }
        }

        public List<iManSession> Sessions
        {
            get { return me.Sessions.ToList(); }
        }

    }

    public class iManSession
    {
        private iml.IManSession me;

        public iManSession(iml.IManSession Session)
        {
            me = Session;
        }

        public List<iManDatabase> Databases
        {
            get
            {
                return me.Databases.ToList();
            }
        }

        public string ServerName
        {
            get
            {
                return me.ServerName;
            }
        }
    }


    public class iManDatabase
    {
        private iml.IManDatabase me;

        public iManDatabase(iml.IManDatabase database)
        {
            me = database;
        }

        public string Name
        {
            get
            {
                return me.Name;
            }
        }

        public List<iManWorkspace> SearchWorkspaces()
        {
            return ((iml.IManWorkspaces)me.SearchWorkspaces(me.Session.DMS.CreateProfileSearchParameters(), me.Session.DMS.CreateWorkspaceSearchParameters())).ToList();
        }

        public List<iManDocument> SearchDocuments()
        {
            return ((iml.IManDocuments)me.SearchDocuments(me.Session.DMS.CreateProfileSearchParameters(), false)).ToList();
        }
    }

    public class iManWorkspace
    {
        private iml.IManWorkspace me;

        public iManWorkspace(iml.IManWorkspace workspace)
        {
            me = workspace;
        }
    }

    public class iManDocument
    {
        private iml.IManDocument me;

        public iManDocument(iml.IManDocument document)
        {
            me = document;
        }

        public void CheckOut(string Filename)
        {
            if (me.CheckedOut)
                throw new ApplicationException(String.Format("Document {0}.{1} already checked out by {3} to {4}", me.Number, me.Version, me.InUseBy, me.CheckoutLocation));
            me.CheckOut(Filename, iml.imCheckOutOptions.imDontReplaceExistingFile, DateTime.Now.AddDays(1), "");
        }

        public void CheckIn()
        {
            object errorObject = new object();
            if (me.CheckedOut)
                me.CheckIn(me.CheckoutLocation, iml.imCheckinDisposition.imCheckinReplaceOriginal, iml.imCheckinOptions.imDontKeepCheckedOut, ref errorObject);
        }

        public void Unlock()
        {
            if (me.CheckedOut)
                ((iml.IManDocument)me).UnlockContent();
            else
                throw new ApplicationException(String.Format("Document {0}.{1} not checked out", me.Number, me.Version));

        }
    }

    public static class ExtensionMethods
    {
        public static List<iManSession> ToList(this iml.IManSessions ds)
        {
            List<iManSession> results = new List<iManSession>(ds.Count);
            for (int i = 1; i <= ds.Count; i++)
            {
                results.Add(new iManSession((iml.IManSession)ds.ItemByIndex(i)));
            }
            return results;
        }

        public static List<iManDocument> ToList(this iml.IManDocuments ds)
        {
            List<iManDocument> results = new List<iManDocument>(ds.Count);
            for (int i = 1; i <= ds.Count; i++)
            {
                results.Add(new iManDocument((iml.IManDocument)ds.ItemByIndex(i)));
            }
            return results;
        }

        public static List<iManDatabase> ToList(this iml.IManDatabases ds)
        {
            List<iManDatabase> results = new List<iManDatabase>(ds.Count);
            for (int i = 1; i <= ds.Count; i++)
            {
                results.Add(new iManDatabase((iml.IManDatabase)ds.ItemByIndex(i)));
            }
            return results;
        }

        public static List<iManWorkspace> ToList(this iml.IManWorkspaces ws)
        {
            List<iManWorkspace> results = new List<iManWorkspace>(ws.Count);
            for (int i = 1; i <= ws.Count; i++)
            {
                results.Add(new iManWorkspace((iml.IManWorkspace)ws.ItemByIndex(i)));
            }
            return results;
        }

    }

}
