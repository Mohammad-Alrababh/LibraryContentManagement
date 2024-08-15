
namespace Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Initialized Database Data Conenction
            DataContext dataContext = new DataContext();

            UtilityFunctions.PrintInBox("Welcome to the Library Management System");

            //Creating a 2 author and 2 readers
            UtilityFunctions.PrintGreen("Creating 2 authors");
            Author waleed = UserEngine.CreateAuthor("Waleed");
            Author anna = UserEngine.CreateAuthor("Anna");
            Console.WriteLine(waleed.ToString());
            Console.WriteLine(anna.ToString());
            Console.WriteLine();

            //Creating 2 readers
            UtilityFunctions.PrintGreen("Creating 2 readers");
            Reader lara = UserEngine.CreateReader("Lara");
            Reader moh = UserEngine.CreateReader("Moh");
            Console.WriteLine(lara.ToString());
            Console.WriteLine(moh.ToString());
            Console.WriteLine();

            UtilityFunctions.PrintGreen("Creating new Posts");
            Post post1 = ContentEngine.CreatePost(waleed, "AI Impact", "Ai is super cool", PostType.Article, PostStatus.Published);
            Post post2 = ContentEngine.CreatePost(anna, "Distributed System Functionality","This talks about the implimentation of distributed system", PostType.Survey, PostStatus.Draft);
            Post post3 = ContentEngine.CreatePost(anna, "Servers", "A dive deep into servers' concepts", PostType.Article, PostStatus.Draft);
            Console.WriteLine(post1.ToString());
            Console.WriteLine(post2.ToString());
            Console.WriteLine();


            UtilityFunctions.PrintGreen("Creating new Tags");
            Tag tag1 = ContentEngine.CreateTag("Google Colab", "This shows how Google Colab is used with ML Training");
            Tag tag2 = ContentEngine.CreateTag("CloudTechnology", "Cloud Technology explanation tag");
            Tag tag3 = ContentEngine.CreateTag("ASP.NET", "Further discusses how to implement ASP.NET");
            Console.WriteLine(tag1.ToString());
            Console.WriteLine(tag2.ToString());
            Console.WriteLine(tag3.ToString());
            Console.WriteLine();

            //Assigning Tags to Posts
            UtilityFunctions.PrintGreen("Assigning tags to posts");
            post1.AssignTags(tag1);
            post2.AssignTags(tag2);
            post2.AssignTags(tag3);
            Console.WriteLine();

            //Users Follow Tags
            UtilityFunctions.PrintGreen("Readers following tags");
            ContentEngine.FollowTag(lara, tag1);
            ContentEngine.FollowTag(moh, tag2);
            ContentEngine.FollowTag(moh, tag3);
            Console.WriteLine();

            //Users Follow Authors
            UtilityFunctions.PrintGreen("Readers following authors");
            ContentEngine.FollowAuthor(lara, waleed);
            ContentEngine.FollowAuthor(moh, anna);
            Console.WriteLine();

            //Get Post by Id
            UtilityFunctions.PrintGreen("Printing the Post with Id: 1");
            Console.WriteLine(ContentEngine.GetPostbyID(1).ToString());

            //Updating the post
            UtilityFunctions.PrintGreen("Updatind Post with Id: 2");
            post2.Content = "Distributed systems are very powerful";
            ContentEngine.UpdatePost(anna, post2);
            Console.WriteLine(post2.ToString());

            UtilityFunctions.PrintGreen("Printing all posts by authors followed by Lara to the system");
            var laraAuthorPosts = ContentEngine.GetFollowedAuthorsPosts(lara);
            UtilityFunctions.PrintPosts(laraAuthorPosts);
            Console.WriteLine();

            UtilityFunctions.PrintGreen("Printing Lara's followed Tags");
            Console.WriteLine(lara.DisplayFollowedTags()); 

            UtilityFunctions.PrintGreen("Printing all posts in tags followed by Moh to the system");
            var mohTagsPosts = ContentEngine.GetFollowedTagsPosts(moh);
            UtilityFunctions.PrintPosts(mohTagsPosts);
            Console.WriteLine();

            UtilityFunctions.PrintGreen("Printing all posts by authors followed by Moh to the system");
            var mohAuthorPosts = ContentEngine.GetFollowedAuthorsPosts(moh);
            UtilityFunctions.PrintPosts(mohTagsPosts);
            Console.WriteLine();

            UtilityFunctions.PrintGreen("Lara Reading Post 2");
            lara.ReadPost(post2);

            UtilityFunctions.PrintGreen($"Displaying all posts tagged by {tag1.TagName}");
            UtilityFunctions.PrintPosts(ContentEngine.GetTagPosts(tag1));
            Console.WriteLine();

            UtilityFunctions.PrintGreen($"Waleed trying to delete Anna's post {post3.Title}");
            ContentEngine.DeletePost(waleed, post3);
            Console.WriteLine();
            
            UtilityFunctions.PrintGreen($"Anna trying to delete her own post {post3.Title}");
            ContentEngine.DeletePost(anna, post3);
            Console.WriteLine();





            Console.ReadKey();
        }
    }
}
