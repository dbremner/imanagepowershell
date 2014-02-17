using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iml = IManage;

namespace iManageWrapper
{
    public class iManProfiledContent : iManContent
    {
        internal new iml.IManProfiledContent Me { get { return (iml.IManProfiledContent)base.Me; } }

        public iManProfiledContent(iml.IManProfiledContent content, iManDatabase database) : base(content, database) { }

        /// <summary>
        ///     Returns TRUE when the document has been moved to near-line storage. An archived document is accessible but the
        ///     allowable operations are restricted.
        /// </summary>
        public bool Archived
        {
            get { return Me.Archived; }
        }

        public bool HasAttachments
        {
            get { return Me.HasAttachments; }
        }

        public IEnumerable<iml.IManAttachment> Attachments
        {
            get
            {
                if (Me.HasAttachments)
                {
                    foreach (iml.IManAttachment a in Me.Attachments)
                    {
                        yield return a;
                    }
                }
                else
                {
                    yield break;
                }
            }
        }

        public iManDocumentClass Class
        {
            get { return new iManDocumentClass(Me.Class, Database); }
            set { Me.Class = value.Me; }
        }

        public iml.imAccessRight EffectiveAccess
        {
            get { return Me.EffectiveAccess; }
        }

        public iManUser InUseBy
        {
            get { return new iManUser(Me.InUseBy, Database); }
        }

        public bool Locked
        {
            get { return Me.Locked; }
        }

        public bool MarkedForArchive
        {
            get { return Me.MarkedForArchive; }
            set { Me.MarkedForArchive = value; }
        }

        public iManProfile Profile
        {
            get { return new iManProfile(Me.Profile, Database); }
        }

        //public iManRules Rules { get { throw new NotImplementedException(); } } // not implemented

        public iManSecurity Security { get { return new iManSecurity(Me.Security, this); } }

        public iManDocumentClass SubClass
        {
            get { return new iManDocumentClass(Me.SubClass, Database); }
        }

        public iManDocumentType Type
        {
            get { return new iManDocumentType(Me.Type, Database); }
            set { Me.Type = value.Me; }
        }

        public bool LockContent(bool refreshProfile)
        {
            return Me.LockContent(refreshProfile);
        }

        public void LogEvent(iml.IManRuleEventType evntType, string customData)
        {
            Me.LogEvent(evntType, customData);
        }

        public bool UnlockContent()
        {
            return Me.UnlockContent();
        }

        public iml.IManProfileUpdateResult UpdateWithResuls()
        {
            return Me.UpdateWithResults();
        }

    }
}
