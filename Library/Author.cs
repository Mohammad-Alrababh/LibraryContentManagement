using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Author : SystemUser
    {
        public List<Post> Posts = new List<Post>();


        //Hide default constructor
        private Author() { }
        public Author(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            
            return $"Author ID: {Id} \tName: {Name}";
        }

        public Post CreatePost( string title, string contentText, PostType type, PostStatus status)
        {
            Post post = new Post(this, title, contentText, type, status);
            Posts.Add(post);
            return post;
        }

        public void DeletePost(Post post)
        {
            try
            {
                post.CheckAuthor(this);
                Posts.Remove(post);
                Console.WriteLine($"Post {post.Id} Deleted");
            }
            catch
            {
                Console.WriteLine("You are not the author, you can't delete the post!");
            }
        }

        public Post UpdatePost(Post updatedPost)
        {
            Post existingPost = Posts.FirstOrDefault(p => p.Id == updatedPost.Id);
            try
            {
                
                existingPost.CheckIfPublished();                
                try
                {
                    existingPost.CheckAuthor(this);
                    if (existingPost != null)
                    {
                        existingPost = updatedPost;
                    }
                    Console.WriteLine($"Post {existingPost.Id} Updated");
                    return existingPost;
                }
                catch
                {
                    Console.WriteLine("You are not the author, you can't update the post!");
                    return existingPost;
                }
            }
            catch
            {
                Console.WriteLine("Post is published you can't update it!");
                return existingPost;
            }


        }


        public void AssignTagToPost(Post post, Tag tag)
        {
            try
            {
                post.CheckAuthor(this);
                post.AssignTags(tag);
            }
            catch
            {
                Console.WriteLine("You are not the author, you can't assign tags to the post!");
            }
        }



        public Post PublishPost(Post post)
        {
            try
            {
                post.CheckIfPublished();
                try
                {
                    post.CheckAuthor(this);
                    post.Status = PostStatus.Published;
                    post.PublishDate = DateTime.Now.Date;
                    return post;
                }
                catch
                {
                    Console.WriteLine("You are not the author, you can't publish the post!");
                    return post;
                }

            }
            catch
            {
                Console.WriteLine("Post is already published!");
                return post;
            }
        }

        public void DisplayPost(Post post)
        {
            if (post.Status == PostStatus.Published)
            {
                Console.WriteLine(post.ToString());
               
            }else 
            {
                try
                {
                    post.CheckAuthor(this);
                    Console.WriteLine(post.ToString());

                }
                catch
                {
                    Console.WriteLine("You are not the author, you can't display a draft post!");
                }
            }

        }

        

    }
}
