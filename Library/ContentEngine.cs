using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class ContentEngine
    {
        
        //Content Creation Methods
        public static Post CreatePost(Author author, string title,string contentText, PostType type, PostStatus status)
        {
            var post = author.CreatePost(title, contentText, type, status);
            DataContext.Create(post);
            return post;
        }
        public static Tag CreateTag(string tagName, string tagDescription) 
        {
            Tag tag = new Tag(tagName, tagDescription);
            DataContext.Create(tag);
            return tag;
        }

        //Content Single Retrieval Methods
        public static Post GetPostbyID(int id) 
        {
            return (Post)DataContext.GetById<Post>(id);
        }

        public static Tag GetTagbyID(int id) 
        {
            return (Tag)DataContext.GetById<Tag>(id);

        }

        //content list Retrieval methods
        public static List<Post> GetPosts() 
        {
            var list =   DataContext.GetItems<Post>();
            List<Post> posts = new List<Post>();
            foreach (var item in list)
            {
                posts.Add((Post)item);
            }
            return posts;
        }

        public static List<Tag> GetTags()   
        {
            var list = DataContext.GetItems<Tag>();
            List<Tag> tags = new List<Tag>();
            foreach (var item in list)
            {
                tags.Add((Tag)item);
            }
            return tags;
        }
        //update methods
        public static Post UpdatePost(Author author, Post post) 
        {
            
            DataContext.Update(post);
            return author.UpdatePost(post);
        }
        public static Tag UpdateTag(Tag existingTag, Tag updatedTag) 
        {
            DataContext.Update(updatedTag);            
            return existingTag.UpdateTag(updatedTag);
        }

        //Content Deletion Methods
        public static void DeletePost(Author author, Post post)
        {
            // Remove the post from the author's list of posts
            author.DeletePost(post);
            DataContext.Delete<Post>(post);
        }

        public static void DeleteTag(Tag tag)
        {
            DataContext.Delete<Tag>(tag);
        }


        //User follows tag
        public static void FollowTag(Reader reader, Tag tag)
        {
            reader.FollowedTags.Add(tag);
            Console.WriteLine($"{reader.Name} is now following the tag: {tag.TagName}");
        }

        public static void FollowAuthor(Reader reader, Author author)
        {
            reader.FollowedAuthors.Add(author);
            Console.WriteLine($"{reader.Name} is now following the author: {author.Name}");
        }



        // Get all posts that match a specific filter
        public static List<Post> GetFilteredPosts(Func<Post, bool> filter)
        {           
            List<Post> unfiltered = GetPosts();
            List<Post> filtered = unfiltered.Where(filter).ToList();
            return filtered;          
            
        }

        // Get all posts from followed authors
        public static List<Post> GetFollowedAuthorsPosts(Reader reader)
        {
            // Here the relationship between the Post's AuthorId and the list of followed Authors' Ids is one to many
            Func<Post, bool> postFilter = p => reader.FollowedAuthors.Contains(p.Author);
            var posts = GetFilteredPosts(postFilter);
            return posts;
        }
        public static List<Post> GetFollowedTagsPosts(Reader reader)
        {
            // The relationship between tags Ids and Posts ids is many to many therefore we need a foreach loop to itirate through them
            var posts = new List<Post>();
            foreach (var tag in reader.FollowedTags)
            {
                Func<Post, bool> postFilter = p => p.Tags.Contains(tag);
                posts = GetFilteredPosts(postFilter);

            }
            return posts;
        }

        public static List<Post> GetAuthorPosts(Author author)
        {
            // here the relationsip is one to one therefore we use equals
            Func<Post, bool> postFilter = p => p.Author.Equals(author);
            var posts = GetFilteredPosts(postFilter);
            return posts;
        }

        public static List<Post> GetTagPosts(Tag tag)
        {
            // here the relationsip is one to many therefore we use Contains
            Func<Post, bool> postFilter = p => p.Tags.Contains(tag);
            var posts = GetFilteredPosts(postFilter);            
            return posts;
        }

        

    }



}
