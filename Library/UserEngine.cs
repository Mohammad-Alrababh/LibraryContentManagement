using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class UserEngine
    {

        //Users Registration methods
        public static Author CreateAuthor(string name)
        {
            Author author = new Author(name);
            return (Author)DataContext.Create(author);
        }
        public static Reader CreateReader(string name)
        {
            Reader reader = new Reader(name);
            return (Reader)DataContext.Create(reader);
        }

        //Users Deletion methods
        public static void DeleteAuthor(int id)
        {
            DataContext.Delete<Author>(id);
        }
        public static void DeleteReader(int id)
        {
            DataContext.Delete<Reader>(id);
        }

        // Users Single Retrieval Methods
        public static Author GetAuthorbyID(int id)
        {
            Author author = (Author)DataContext.GetById<Author>(id);
            Console.WriteLine("In GetAuthorByID Author's Id is: " + author.Id);
            return author;
        }
        public static Reader GetReaderbyID(int id)
        {
            return (Reader)DataContext.GetById<Reader>(id);
        }

        // Users List Retrieval Methods
        public static List<Author> GetAuthors()
        {
            var list = DataContext.GetItems<Author>();
            List<Author> authors = new List<Author>();
            //Each item needed to be casted separately as the list as a whole couldn't be directly casted
            foreach (var item in list)
            {
                authors.Add((Author)item);
            }
            return authors;
        }
        public static List<Reader> GetReaders()
        {
            var list = DataContext.GetItems<Reader>();
            List<Reader> readers = new List<Reader>();
            //Each item needed to be casted separately as the list as a whole couldn't be directly casted
            foreach (var item in list)
            {
                readers.Add((Reader)item);
            }
            return readers;
        }
              

        // Users Update Methods
        public static Author UpdateAuthor(Author author)
        {            
           return (Author)DataContext.Update<Author>(author);
        }

        public static Reader UpdateReader(Reader reader)
        {
            return (Reader)DataContext.Update<Reader>(reader);
        }
        
    }
}
