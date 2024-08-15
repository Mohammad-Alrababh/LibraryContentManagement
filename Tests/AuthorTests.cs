using Xunit;
using Library;

namespace LibraryTests
{
    public class AuthorTests
    {

        [Fact]
        public void CreatePost_ShouldAddPostToAuthorPosts()
        {
            // Arrange
            var author = new Author("John Doe");

            // Act
            var post = author.CreatePost("Test Title", "Test Content", PostType.BlogEntry, PostStatus.Draft);

            // Assert
            Assert.Contains(post, author.Posts);
        }

        [Fact]
        public void DeletePost_ShouldRemovePostFromAuthorPosts()
        {
            // Arrange
            var author = new Author("Jane Smith");
            var post = author.CreatePost("Test Title", "Test Content", PostType.BlogEntry, PostStatus.Draft);

            // Act
            author.DeletePost(post);

            // Assert
            Assert.DoesNotContain(post, author.Posts);
        }

        [Fact]
        public void UpdatePost_ShouldUpdateExistingPost()
        {
            // Arrange
            var author = new Author("Alice Brown");
            var post = author.CreatePost("Original Title", "Original Content", PostType.Article, PostStatus.Draft);
            var updatedPost = new Post(author, "Updated Title", "Updated Content", PostType.Article, PostStatus.Draft);
            updatedPost.Id = post.Id; // Simulate same ID for updating

            // Act
            var result = author.UpdatePost(updatedPost);

            // Assert
            Assert.Equal("Updated Title", result.Title);
        }

        [Fact]
        public void AssignTagToPost_ShouldAddTagToPost()
        {
            // Arrange
            var author = new Author("Bob Green");
            var post = author.CreatePost("Test Title", "Test Content", PostType.BlogEntry, PostStatus.Draft);
            var tag = new Tag("Technology", "Posts related to technology");

            // Act
            author.AssignTagToPost(post, tag);

            // Assert
            Assert.Contains(tag, post.Tags);
        }

        [Fact]
        public void PublishPost_ShouldChangePostStatusToPublished()
        {
            // Arrange
            var author = new Author("Mary Lee");
            var post = author.CreatePost("Test Title", "Test Content", PostType.BlogEntry, PostStatus.Draft);

            // Act
            var result = author.PublishPost(post);

            // Assert
            Assert.Equal(PostStatus.Published, result.Status);
        }


    }
}