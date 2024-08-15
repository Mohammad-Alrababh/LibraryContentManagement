using Library;
using System.Data;

namespace LibraryTests
{

    public class ContentEngineTests
    {
        [Fact]
        public void CreatePost_ShouldReturnPost_WithValidDetails()
        {
            // Arrange
            Author author = UserEngine.CreateAuthor("Test Author");
            string title = "Test Post";
            string contentText = "This is a test post.";
            PostType type = PostType.Article;
            PostStatus status = PostStatus.Draft;

            // Act
            Post post = ContentEngine.CreatePost(author, title, contentText, type, status);

            // Assert
            Assert.NotNull(post);
            Assert.Equal(title, post.Title);
            Assert.Equal(contentText, post.Content);
            Assert.Equal(type, post.Type);
            Assert.Equal(status, post.Status);
            Assert.Equal(author, post.Author);
        }

        [Fact]
        public void GetPostByID_ShouldReturnPost_WithValidId()
        {
            // Arrange
            Author author = UserEngine.CreateAuthor("Test Author");
            Post post = ContentEngine.CreatePost(author, "Test Post", "Content", PostType.Article, PostStatus.Draft);

            // Act
            Post retrievedPost = ContentEngine.GetPostbyID(post.Id);

            // Assert
            Assert.NotNull(retrievedPost);
            Assert.Equal(post.Id, retrievedPost.Id);
        }

        [Fact]
        public void GetPosts_ShouldReturnListOfPosts()
        {
            // Arrange
            Author author = UserEngine.CreateAuthor("Test Author");
            ContentEngine.CreatePost(author, "Test Post 1", "Content 1", PostType.Article, PostStatus.Draft);
            ContentEngine.CreatePost(author, "Test Post 2", "Content 2", PostType.Article, PostStatus.Draft);

            // Act
            List<Post> posts = ContentEngine.GetPosts();

            // Assert
            Assert.NotNull(posts);
            Assert.True(posts.Count >= 2);
        }

        [Fact]
        public void GetTags_ShouldReturnListOfTags()
        {
            // Arrange
            ContentEngine.CreateTag("Test Tag 1", "Description 1");
            ContentEngine.CreateTag("Test Tag 2", "Description 2");

            // Act
            List<Tag> tags = ContentEngine.GetTags();

            // Assert
            Assert.NotNull(tags);
            Assert.True(tags.Count >= 2);
        }

        [Fact]
        public void UpdatePost_ShouldUpdatePostDetails()
        {
            // Arrange
            Author author = UserEngine.CreateAuthor("Test Author");
            Post post = ContentEngine.CreatePost(author, "Old Title", "Old Content", PostType.Article, PostStatus.Draft);
            post.Title = "New Title";
            post.Content = "New Content";

            // Act
            Post updatedPost = ContentEngine.UpdatePost(author, post);

            // Assert
            Assert.NotNull(updatedPost);
            Assert.Equal("New Title", updatedPost.Title);
            Assert.Equal("New Content", updatedPost.Content);
        }


        [Fact]
        public void DeletePost_ShouldRemovePost()
        {
            // Arrange
            Author author = UserEngine.CreateAuthor("Test Author");
            Post post = ContentEngine.CreatePost(author, "Old Title", "Old Content", PostType.Article, PostStatus.Draft);
            post.Title = "New Title";
            post.Content = "New Content";

            // Act
            ContentEngine.DeletePost(author,post);

            // Assert
            Assert.Throws<DataException>(() => ContentEngine.GetPostbyID(post.Id));
        }
        [Fact]
        public void DeleteTag_ShouldRemoveTag()
        {
            // Arrange
            Tag tag = ContentEngine.CreateTag("Test Tag", "Description");

            // Act
            ContentEngine.DeleteTag(tag);

            // Assert
            Assert.Throws<DataException>(() => ContentEngine.GetTagbyID(tag.Id));
        }

        [Fact]
        public void FollowTag_ShouldAddTagToReader()
        {
            // Arrange
            Reader reader = UserEngine.CreateReader("Test Reader");
            Tag tag = ContentEngine.CreateTag("Test Tag", "Description");

            // Act
            ContentEngine.FollowTag(reader, tag);

            // Assert
            Assert.Contains(tag, reader.FollowedTags);
        }

        [Fact]
        public void FollowAuthor_ShouldAddAuthorToReader()
        {
            // Arrange
            Reader reader = UserEngine.CreateReader("Test Reader");
            Author author = UserEngine.CreateAuthor("Test Author");

            // Act
            ContentEngine.FollowAuthor(reader, author);

            // Assert
            Assert.Contains(author, reader.FollowedAuthors);
        }

        [Fact]
        public void GetFollowedAuthorsPosts_ShouldReturnPostsFromFollowedAuthors()
        {
            // Arrange
            Author author = UserEngine.CreateAuthor("Test Author");
            Reader reader = UserEngine.CreateReader("Test Reader");
            ContentEngine.FollowAuthor(reader, author);
            ContentEngine.CreatePost(author, "Title 1", "Content 1", PostType.Article, PostStatus.Published);

            // Act
            List<Post> posts = ContentEngine.GetFollowedAuthorsPosts(reader);

            // Assert
            Assert.Single(posts);
            Assert.Equal("Title 1", posts[0].Title);
        }

        


    }
}