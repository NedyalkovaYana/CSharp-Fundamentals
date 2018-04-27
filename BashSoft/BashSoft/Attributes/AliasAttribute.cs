using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AliasAttribute : Attribute
    {
        private string name;

        public AliasAttribute(string aliasName)
        {
            this.name = aliasName;
        }

        public string Name
        {
            get { return name; }
        }

        public override bool Equals(object obj)
        {
            return this.Name.Equals(obj);
        }
    }
}
