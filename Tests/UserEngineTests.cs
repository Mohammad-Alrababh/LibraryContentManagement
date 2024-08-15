

using Library;
using System.Data;

namespace LibraryTests
{

    public class UserEngineTests
    {


        [Fact]
        public void CreateReader_ShouldReturnReader_WithValidName()
        {
            // Arrange
            string name = "Test Reader";

            // Act
            Reader reader = UserEngine.CreateReader(name);

            // Assert
            Assert.NotNull(reader);
            Assert.Equal(name, reader.Name);
        }

        [Fact]

        public void DeleteReader_ShouldRemoveReader_WithValidId()
        {
            // Arrange
            Reader reader = UserEngine.CreateReader("Reader to Delete");

            // Act
            UserEngine.DeleteReader(reader.Id);

            // Assert
            Assert.Throws<DataException>(() => UserEngine.GetReaderbyID(reader.Id));
        }


        [Fact]
        public void DeleteAuthor_ShouldRemoveAuthor_WithValidId()
        {
            // Arrange
            Author author = UserEngine.CreateAuthor("Author to Delete");

            // Act
            UserEngine.DeleteAuthor(author.Id);

            // Assert
            Assert.Throws<DataException>(() => UserEngine.GetAuthorbyID(author.Id));
        }

        [Fact]
        public void GetAuthorByID_ShouldReturnAuthor_WithValidId()
        {
            // Arrange
            Author author = UserEngine.CreateAuthor("Author to Retrieve");

            // Act
            Author retrievedAuthor = UserEngine.GetAuthorbyID(author.Id);

            // Assert
            Assert.NotNull(retrievedAuthor);
            Assert.Equal(author.Id, retrievedAuthor.Id);
        }


        [Fact]
        public void GetAuthors_ShouldReturnListOfAuthors()
        {
            // Arrange
            UserEngine.CreateAuthor("Author 1");
            UserEngine.CreateAuthor("Author 2");

            // Act
            List<Author> authors = UserEngine.GetAuthors();

            // Assert
            Assert.NotNull(authors);
            Assert.True(authors.Count >= 2);
        }

        [Fact]
        public void UpdateAuthor_ShouldUpdateAuthorDetails()
        {
            //Arrange
            Author author = UserEngine.CreateAuthor("Author to Update");
            author.Name = "Updated Author Name";

            // Act 
            Author updatedAuthor = UserEngine.UpdateAuthor(author);

            //Assert
            Assert.NotNull(updatedAuthor);
            Assert.Equal(updatedAuthor.Name, author.Name);
        }

        [Fact]
        public void UpdateReader_ShouldUpdateReaderDetails()
        {
            // Arrange
            Reader reader = UserEngine.CreateReader("Reader to Update");
            reader.Name = "Updated Reader Name";

            // Act
            Reader updatedReader = UserEngine.UpdateReader(reader);

            // Assert
            Assert.NotNull(updatedReader);
            Assert.Equal("Updated Reader Name", updatedReader.Name);
        }

    }
}