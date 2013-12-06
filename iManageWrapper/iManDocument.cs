using System;
using System.Collections.Generic;
using iml = IManage;

namespace iManageWrapper
{
    // ReSharper disable once InconsistentNaming
    public class iManDocument : iManProfiledContent
    {
        public iManDocument(iml.IManDocument document, iManDatabase database)
            : base(document, database)
        {
        }

        internal new iml.IManDocument Me { get { return (iml.IManDocument)base.Me; } }

        public int Number
        {
            get { return Me.Number; }
        }

        public int Version
        {
            get { return Me.Version; }
        }

        public bool CheckedOut
        {
            get { return Me.CheckedOut; }
        }

        public string Comment
        {
            get { return Me.Comment; }
            set { Me.Comment = value; }
        }

        public string Description
        {
            get { return Me.Description; }
            set { Me.Description = value; }
        }

        public string ClientCode
        {
            get { return Me.GetAttributeValueByID(Database.ClientCustomField).ToString(); }
            set { Me.SetAttributeByID(Database.ClientCustomField, value); }
        }

        public string MatterCode
        {
            get { return Me.GetAttributeValueByID(Database.MatterCustomField).ToString(); }
            set { Me.SetAttributeByID(Database.MatterCustomField, value); }
        }

        public string Extension
        {
            get { return Me.Extension; }
        }

        /// <summary>
        ///     The folders that contain this document, a.k.a. "Where Used".
        /// </summary>
        public IEnumerable<iManFolder> Folders
        {
            get { foreach (iml.IManFolder f in Me.Folders) yield return new iManFolder(f, Database); }
        }

        public IEnumerable<iManDocumentHistory> History
        {
            get
            {
                foreach (iml.IManDocumentHistory h in Me.HistoryList) yield return new iManDocumentHistory(h, Database);
            }
        }

        public iManUser Author
        {
            get { return new iManUser(Me.Author, Database); }
        }

        /// <summary>
        ///     The value entered in the Comment field when checking out a document.
        /// </summary>
        public string CheckoutComment
        {
            get { return Me.CheckoutComment; }
        }

        /// <summary>
        ///     The designated date when the document is due to be checked in and unlocked.
        /// </summary>
        public DateTime CheckoutDueDate
        {
            get { return Me.CheckoutDueDate; }
        }

        /// <summary>
        ///     The name of the machine from which the document has been checked out.
        /// </summary>
        public string CheckoutLocation
        {
            get { return Me.CheckoutLocation; }
        }

        public string CheckoutPath
        {
            get { return Me.CheckoutPath; }
        }

        public DateTime CheckoutTime
        {
            get { return Me.CheckoutTime; }
        }

        public DateTime CreationDate
        {
            get { return Me.CreationDate; }
        }

        public IEnumerable<iManCustomAttribute> CustomAttributes
        {
            get
            {
                foreach (iml.IManCustomAttribute c in Me.CustomAttributes)
                {
                    yield return new iManCustomAttribute(c, Database);
                }
            }
        }

        public DateTime EditDate
        {
            get { return Me.EditDate; }
        }

        public DateTime EditProfileTime
        {
            get { return Me.EditProfileTime; }
        }

        public bool Indexable
        {
            get { return Me.Indexable; }
            set { Me.Indexable = value; }
        }

        public bool IsAnyVersionCheckedOut
        {
            get { return Me.IsAnyVersionCheckedOut; }
        }

        public bool IsLatestVersion
        {
            get { return Me.IsLatestVersion; }
        }

        public iManUser LastUser
        {
            get { return new iManUser(Me.LastUser, Database); }
        }

        public string Name
        {
            get { return Me.Name; }
            set { Me.Name = value; }
        }

        public iManUser Operator
        {
            get { return new iManUser(Me.Operator, Database); }
            set { Me.Operator = value.Me; }
        }

        public IEnumerable<iManDocument> RelatedDocuments
        {
            get
            {
                foreach (iml.IManDocument d in Me.RelatedDocuments)
                {
                    yield return new iManDocument(d, Database);
                }
            }
        }

        public int Size
        {
            get { return Me.Size; }
        }

        public iml.imDocumentSubType SubType
        {
            get { return Me.SubType; }
        }

        public long RetentionDays { get { return Me.RetentionDays; } }

        public void AddRelatedDocument(iManDocument document, string comment = "")
        {
            if (!Me.RelatedDocuments.AddRelation(document.Number, comment))
                throw new ApplicationException();
        }

        public void AddRelatedDocument(int documentNumber, string comment = "")
        {
            if (!Me.RelatedDocuments.AddRelation(documentNumber, comment))
                throw new ApplicationException();
        }

        public void RemoveRelatedDocument(iManDocument document)
        {
            Me.RelatedDocuments.RemoveRelation(document.Number);
        }

        public void RemoveRelatedDocument(int documentNumber)
        {
            Me.RelatedDocuments.RemoveRelation(documentNumber);
        }

        /// <summary>
        /// The CheckOut method marks a document in the database as checked out, locks it so that it is unavailable to other users, and copies it to the specified location on a local drive.
        /// </summary>
        /// <param name="filename">the local file to write to</param>
        /// <param name="overwrite">if true, overwrite an existing file</param>
        /// <param name="dueDate"></param>
        /// <param name="comments"></param>
        public void CheckOut(string filename, bool overwrite = false, DateTime? dueDate = null, string comments = null)
        {
            if (Me.CheckedOut)
                throw new ApplicationException(String.Format("Document {0}.{1} already checked out by {2} to {3}",
                    Me.Number, Me.Version, Me.InUseBy, Me.CheckoutLocation));
            Me.CheckOut(filename,
                overwrite ? iml.imCheckOutOptions.imReplaceExistingFile : iml.imCheckOutOptions.imDontReplaceExistingFile,
                dueDate ?? DateTime.Now.AddDays(1),
                comments);
        }

        /// <summary>
        /// The CheckOut method marks a document in the database as checked out, locks it so that it is unavailable to other users, and copies it to the specified location on a local drive.
        /// </summary>
        /// <param name="filename">the local file to write to</param>
        /// <param name="overwrite">if true, overwrite an existing file</param>
        /// <param name="dueDate"></param>
        /// <param name="comments"></param>
        /// <param name="currentActivity"></param>
        /// <param name="generatingApplication"></param>
        /// <param name="location"></param>
        public void CheckOutEx(string filename, bool overwrite = false, DateTime? dueDate = null, string comments = null, iml.imHistEvent currentActivity = iml.imHistEvent.imHistoryCheckout, string generatingApplication = "", string location = "")
        {
            if (Me.CheckedOut)
                throw new ApplicationException(String.Format("Document {0}.{1} already checked out by {2} to {3}",
                    Me.Number, Me.Version, Me.InUseBy, Me.CheckoutLocation));
            Me.CheckOutEx(filename,
                overwrite ? iml.imCheckOutOptions.imReplaceExistingFile : iml.imCheckOutOptions.imDontReplaceExistingFile,
                dueDate ?? DateTime.Now.AddDays(1),
                comments,
                currentActivity,
                generatingApplication,
                location);
        }

        /// <summary>
        ///     If run from the same machine as CheckOut(), uploads the checked out local copy of the document and removes the
        ///     checked out status.
        /// </summary>
        public void CheckIn(string filename = null)
        {
            var errorObject = new object();
            if (Me.CheckedOut)
                Me.CheckIn(filename ?? Me.CheckoutLocation, iml.imCheckinDisposition.imCheckinReplaceOriginal,
                    iml.imCheckinOptions.imDontKeepCheckedOut, ref errorObject);
        }

        /// <summary>
        ///     Removes the checked out status of a checked out document.
        /// </summary>
        public void Unlock()
        {
            if (Me.CheckedOut)
                Me.UnlockContent();
            else
                throw new ApplicationException(String.Format("Document {0}.{1} not checked out", Me.Number, Me.Version));
        }

        /// <summary>
        ///     Saves a copy of the document to the specified file without checking it out.
        /// </summary>
        /// <param name="filename">The path to the file to save to.</param>
        /// <param name="convertToHtml">If true, converts the document to HTML during the copy.</param>
        public void GetCopy(string filename, bool convertToHtml = false)
        {
            Me.GetCopy(filename, convertToHtml ? iml.imGetCopyOptions.imHTMLFormat : iml.imGetCopyOptions.imNativeFormat);
        }

        public override string ToString()
        {
            return string.Format(Me.ObjectID);
        }
    }
}