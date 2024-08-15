using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Tag :Entity
    {
        public string TagName { get; set; }
        public string TagDescription { get; set; }
        

        //Hide default constructor
        private Tag() { }
        public Tag(string tagName, string tagDescription)
        {
            TagName = tagName;
            
            TagDescription = tagDescription;
        }

        public override string ToString()
        {
            return $"Tag Id: {Id}, Tag Name {TagName}, Tag Description: {TagDescription}";
        }

        public Tag UpdateTag(Tag tag)
        {
            TagName = tag.TagName;
            TagDescription = tag.TagDescription;
            return this;
        }
    }
}
