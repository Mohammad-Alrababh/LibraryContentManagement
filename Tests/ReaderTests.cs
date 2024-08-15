using Library;

namespace LibraryTests
{

    public class ReaderTests
    {

        [Fact]
        public void DisplayFollowedAuthors_ShouldReturnAuthorsNames()
        {
            // Arrange
            var reader = new Reader("Alice");

            var author1 = new Author("Author 1");
            var author2 = new Author("Author 2");

            reader.FollowedAuthors.Add(author1);
            reader.FollowedAuthors.Add(author2);

            // Act
            var result = reader.DisplayFollowedAuthors();

            // Assert
            Assert.Contains("Author 1", result);
            Assert.Contains("Author 2", result);
        }

        [Fact]
        public void DisplayFollowedTags_ShouldReturnTagsNames()
        {
            // Arrange
            var reader = new Reader("Bob");

            var tag1 = new Tag("Tag1", "Tag 1 description");
            var tag2 = new Tag("Tag2", "Tag 2 description");

            reader.FollowedTags.Add(tag1);
            reader.FollowedTags.Add(tag2);

            // Act
            var result = reader.DisplayFollowedTags();

            // Assert
            Assert.Contains("Tag1", result);
            Assert.Contains("Tag2", result);
        }


    }
}