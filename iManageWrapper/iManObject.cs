using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iml = IManage;

namespace iManageWrapper
{
// ReSharper disable once InconsistentNaming
    public class iManObject
    {
        internal iml.IManObject Me;

        public iManObject(iml.IManObject meObject)
        {
            Me = meObject;
        }

        public bool HasObjectID { get { return Me.HasObjectID; }}

        public string ObjectID { get { return Me.ObjectID; }}

        public iml.IManObjectType ObjectType { get { return Me.ObjectType; }}
    }

    public class iManObjectDatabase : iManObject
    {
        public iManDatabase Database { get; private set; }

        public iManObjectDatabase(iml.IManObject meObject, iManDatabase database)
            : base(meObject)
        {
            Database = database;
        }
    }
}
