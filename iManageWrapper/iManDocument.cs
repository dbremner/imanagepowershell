using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Data.SqlClient;
using iml = IManage;

namespace iManageWrapper
{

    public class iManDocument
    {
        internal iml.IManDocument me;
        public iManDatabase Database { get; private set; }

        public iManDocument(iml.IManDocument Document, iManDatabase Database)
        {
            me = Document;
            this.Database = Database;
        }

        public int Number { get { return me.Number; } }

        public int Version { get { return me.Version; } }

        public bool CheckedOut { get { return me.CheckedOut; } }

        public string Comment { get { return me.Comment; } set { me.Comment = value; } }

        public string Description { get { return me.Description; } set { me.Description = value; } }

        public string ClientCode { get { return me.CustomAttributes.ToList().Where(a => a.Type == Database.ClientCustomField).Single().Name; } }

        public string MatterCode { get { return me.CustomAttributes.ToList().Where(a => a.Type == Database.MatterCustomField).Single().Name; } }

        public string Extension { get { return me.Extension; } }

        public void CheckOut(string Filename)
        {
            if (me.CheckedOut)
                throw new ApplicationException(String.Format("Document {0}.{1} already checked out by {2} to {3}", me.Number, me.Version, me.InUseBy, me.CheckoutLocation));
            me.CheckOut(Filename, iml.imCheckOutOptions.imDontReplaceExistingFile, DateTime.Now.AddDays(1), "");
        }

        /// <summary>
        /// If run from the same machine as CheckOut(), uploads the checked out local copy of the document and removes the checked out status.
        /// </summary>
        public void CheckIn(string Filename = null)
        {
            object errorObject = new object();
            if (me.CheckedOut)
                me.CheckIn((Filename == null) ? me.CheckoutLocation : Filename, iml.imCheckinDisposition.imCheckinReplaceOriginal, iml.imCheckinOptions.imDontKeepCheckedOut, ref errorObject);
        }

        /// <summary>
        /// Removes the checked out status of a checked out document.
        /// </summary>
        public void Unlock()
        {
            if (me.CheckedOut)
                ((iml.IManDocument)me).UnlockContent();
            else
                throw new ApplicationException(String.Format("Document {0}.{1} not checked out", me.Number, me.Version));

        }

        /// <summary>
        /// Saves a copy of the document to the specified file without checking it out.
        /// </summary>
        /// <param name="filename">The path to the file to save to.</param>
        /// <param name="ConvertToHTML">If true, converts the document to HTML during the copy.</param>
        public void GetCopy(string filename, bool ConvertToHTML = false)
        {
            me.GetCopy(filename, ConvertToHTML ? iml.imGetCopyOptions.imHTMLFormat : iml.imGetCopyOptions.imNativeFormat);
        }

        public void Update() { me.Update(); }

        /// <summary>
        /// The folders that contain this document, a.k.a. "Where Used".
        /// </summary>
        public List<iManFolder> Folders { get { return me.Folders.ToList(Database); } }

        public List<iManDocumentHistory> History { get { return me.HistoryList.ToList(Database); } }

        public override string ToString()
        {
            return string.Format(me.ObjectID);
        }

    }

}