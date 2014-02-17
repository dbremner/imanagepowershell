using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using iml = IManage;

namespace iManageWrapper
{
    
    abstract public class iManObject
    {
        internal iml.IManObject Me;

        public iManObject(iml.IManObject meObject)
        {
            Me = meObject;
        }

        public virtual string Name { get { return "name not implemented for " + this.GetType().Name; } }

        public bool HasObjectID { get { return Me.HasObjectID; } }

        public string ObjectID { get { return Me.ObjectID; } }

        public override string ToString()
        {
            return HasObjectID ? Me.ObjectID : Name;
        }

        public imObjectType ObjectType { get { return (imObjectType) Me.ObjectType.ObjectType; } }

        public IEnumerable<MemberInfo> GetCoverage(string typeName = null)
        {
            Type wrapperType = (typeName == null) ? this.GetType() : this.GetType().Assembly.GetType("iManageWrapper." + typeName);
            var wrapperMembers = new HashSet<string>(wrapperType.GetMembers().Select(wm => wm.Name));

            Type nativeType =
                typeof (iml.IManObject).Assembly.GetType("IManage." + wrapperType.Name.CapitalizeFirstLetter());
            var unimplementedMembers = nativeType.GetMembers().Where(um => !wrapperMembers.Contains(um.Name) && !um.Name.StartsWith("get_") && !um.Name.StartsWith("set_")).OrderBy(um => um.Name);

            return unimplementedMembers;
        }

        public static string GetImlEnums()
        {
            var result = new StringBuilder();
            var assembly = Assembly.GetAssembly(typeof (iml.IManObject));
            foreach (var member in assembly.GetTypes().Where(t => t.IsEnum))
            {
                result.AppendFormat("public enum {0} {{", member.Name).AppendLine();
                result.AppendLine(string.Join(",",
                    Enum.GetNames(member).Select(n => string.Format("{0} = iml.{1}.{0}", n, member.Name)).ToArray()));
                result.AppendLine("}").AppendLine();
            }
            return result.ToString();
        }

    }

    abstract public class iManObjectDatabase : iManObject
    {
        public iManDatabase Database { get; private set; }

        public iManObjectDatabase(iml.IManObject meObject, iManDatabase database)
            : base(meObject)
        {
            Database = database;
        }

    }

}
