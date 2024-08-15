using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library
{
    public enum PostType
    {
        BlogEntry,
        Article,
        Survey
    }
    public enum PostStatus
    {
        Draft,
        Published
        
    }
    public class Post :Entity
    {
        
        //Connection Properties
        public Author Author { get; set; }
        public List<Tag> Tags { get; set; }

        // Post Properties
        public string Content { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime PublishDate { get; set; } //Only set when the post is published
        public PostType Type { get; set; }
        public PostStatus Status { get; set; }

        //Hide default constructor
        private Post() { }
        public Post (Author author,string title,string content, PostType type, PostStatus status)
        {
            Title = title;
            Content = content;
            Type = type;
            //Always start the project as a draft
            Status = status;
            CreationDate = DateTime.Now.Date;
            Author = author;
            Tags = new List<Tag>(); //Create an empty list of tags
        }

        public override string ToString()
        {
            return $"Post ID: {Id}    Author: {Author.Name}    Title: {Title}    \nContent: {Content}    Tags: {DisplayTags()} Type: {Type}    Status: {Status}    \nCreation Date: {CreationDate.ToShortDateString()}";
        }

         public void AssignTags(Tag tag) //To Be Updated
        {
            Tags.Add(tag);
            Console.WriteLine($"Tag {tag.TagName} has been assigned to the post {Title}");
            
        }
        public string DisplayTags()
        {
            if (Tags.Count == 0)
            {
                string message = "No Tags yet";
                return message;
            }
            else
            {
                string tagsNames = "";
                foreach (Tag tag in Tags)
                {
                    tagsNames += tag.TagName + "  ";

                }
                
                return tagsNames;
            }
        }

        public bool CheckIfPublished()
        {
            if (Status == PostStatus.Published)
            {                
                throw new InvalidOperationException("Cannot assign tags to published posts");
            }
            return false;
        }

        public bool CheckIfDraft()
        {
            if (Status == PostStatus.Draft)
            {
                throw new InvalidOperationException("Post not published yet and cannot be displayed");
            }
            return false;
        }
        public bool CheckAuthor(Author author)
        {
            if (Author != author)
            {
                throw new InvalidOperationException("Author can only assign tags to his own posts");
            }
            return false;
        }
    }
}
