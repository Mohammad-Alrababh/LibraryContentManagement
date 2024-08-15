using Library;

namespace LibraryTests
{
    public class PostTests
    {
        [Fact]
        public void Post_Constructor_ShouldInitializeProperties()
        {
            // Arrange
            Author author = new Author("Test Author");
            string title = "Test Title";
            string content = "Test Content";
            PostType type = PostType.Article;
            PostStatus status = PostStatus.Draft;

            // Act
            Post post = new Post(author, title, content, type, status);

            // Assert
            Assert.Equal(author, post.Author);
            Assert.Equal(title, post.Title);
            Assert.Equal(content, post.Content);
            Assert.Equal(type, post.Type);
            Assert.Equal(status, post.Status);
            Assert.Equal(DateTime.Now.Date, post.CreationDate.Date);
            Assert.NotNull(post.Tags);
            Assert.Empty(post.Tags);
        }

        [Fact]
        public void AssignTags_ShouldAddTagToPost()
        {
            // Arrange
            Author author = new Author("Test Author");
            Post post = new Post(author, "Test Title", "Test Content", PostType.Article, PostStatus.Draft);
            Tag tag = new Tag("Tag1", "Tag Description");

            // Act
            post.AssignTags(tag);

            // Assert
            Assert.Single(post.Tags);
            Assert.Contains(tag, post.Tags);
        }


        [Fact]
        public void CheckIfPublished_ShouldReturnFalse_WhenPostIsDraft()
        {
            // Arrange
            Author author = new Author("Test Author");
            Post post = new Post(author, "Test Title", "Test Content", PostType.Article, PostStatus.Draft);

            // Act
            bool IsPublished = post.CheckIfPublished();
                
            //Assert
            Assert.False(IsPublished);


        }

        [Fact]
        public void CheckIfPublished_ShouldThrowException_WhenPostIsPublished()
        {
            // Arrange
            Author author = new Author("Test Author");
            Post post = new Post(author, "Test Title", "Test Content", PostType.Article, PostStatus.Published);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => post.CheckIfPublished());
        }

        [Fact]
        public void CheckIfDraft_ShouldReturnF_WhenPostIsPublsihed()
        {
            // Arrange
            Author author = new Author("Test Author");
            Post post = new Post(author, "Test Title", "Test Content", PostType.Article, PostStatus.Published);

            // Act
            bool IsDraft = post.CheckIfDraft();

            // Assert
            Assert.False(IsDraft);
        }

        [Fact]
        public void CheckIfDraft_ShouldThrowException_WhenPostIsDraft()
        {
            // Arrange
            Author author = new Author("Test Author");
            Post post = new Post(author, "Test Title", "Test Content", PostType.Article, PostStatus.Draft);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => post.CheckIfDraft());
        }

        [Fact]
        public void CheckAuthor_ShouldThrowException_WhenAuthorDoesNotMatch()
        {
            // Arrange
            Author author = new Author("Test Author");
            Author anotherAuthor = new Author("Another Author");
            Post post = new Post(author, "Test Title", "Test Content", PostType.Article, PostStatus.Draft);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => post.CheckAuthor(anotherAuthor));
            Assert.Equal("Author can only assign tags to his own posts", exception.Message);
        }

    }
}