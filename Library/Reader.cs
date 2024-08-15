using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Reader : SystemUser
    {
        
        // I connected lists of followed tags and authors Id, however the correct way of connecting them is by using a list of tags and authors,
        // because using Ids to connect is a logic that is more suitable if I used an actual database unlike the current implementation.

        public List<Tag> FollowedTags { get; set; }
        public List<Author> FollowedAuthors { get; set; }

        

        public Reader(string name)
        {
            Name = name;
            
            FollowedAuthors = new List<Author>();
            FollowedTags    = new List<Tag>();

            
        }

        public override string ToString()
        {

            return $"Reader ID: {Id} \tName: {Name} \tFollowed Authors: {DisplayFollowedAuthors()}\tFollowed Tags: {DisplayFollowedTags()}";
        }

        public string DisplayFollowedAuthors()
        {
            if (FollowedAuthors.Count == 0)
            {
                string message = "No authors followed yet";
                return message;
            }
            else
            {
                string authorsNames = "";
                foreach (Author author in FollowedAuthors)
                {
                    authorsNames += author.Name + "  ";

                }
                authorsNames += "\n";
                return authorsNames;
            }
        }

        public string DisplayFollowedTags()
        {
            if (FollowedTags.Count == 0)
            {
                string message = "No Tags followed yet";                
                return message;
            }
            else
            {
                string tagsNames = "";
                int count = 1;
                foreach (Tag tag in FollowedTags)
                {
                    tagsNames += count + ". " + tag.TagName + "  ";
                    count++;
                }
                tagsNames += "\n";
                return tagsNames;
            }
            
        }

        public void ReadPost(Post post)
        {
            try
            {
                post.CheckIfDraft();
                Console.WriteLine(post.ToString());
            }
            catch
            {
                Console.WriteLine("Post not published yet");
            }

        }

        public void DisplayTagPosts(Tag tag)
        {
            //Getting all posts of a specific tag
            List<Post> unfiltererd = ContentEngine.GetTagPosts(tag);
            List <Post> filtered = new List<Post>();

            //Making sure to only include published posts
            foreach (var post in unfiltererd)
            {
                if (post.Status == PostStatus.Published)
                {
                    filtered.Add(post);
                }
            }

            //Displaying only filtered posts
            if (filtered.Count == 0)
            {
                Console.WriteLine("No posts found with this tag");
            }
            else
            {
                UtilityFunctions.PrintPosts(filtered);
            }
        }


    }
}
