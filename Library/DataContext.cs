using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class DataContext
    {
        // The dataset is a dictionary that stores the type of the object as the key and a list of objects as the value
        // ex (Post, List<Post>)
        public static Dictionary<Type, List<Entity>> dataSets;

        
        public static Dictionary<Type, int> _nextIds; // To track next available ID for each entity type

        static DataContext()
        {
            dataSets = new Dictionary<Type, List<Entity>>();
            _nextIds = new Dictionary<Type, int>();
        }




        public static Entity Create<T>(T entity) where T : Entity
        {
            Type type = typeof(T);
            if (!dataSets.ContainsKey(type))
            {
                dataSets[type] = new List<Entity>();
                _nextIds[type] = 1; // Start with ID 1 for each type
            }


            entity.Id = _nextIds[type]; // Assign the next available ID, this was done to mimic ORM behavior
            dataSets[type].Add(entity);
            _nextIds[type]++; // Increment next ID for this type
            return entity;

        }

        public static void Delete<T>(int id) where T : Entity
        {
            Entity entity = GetById<T>(id);
            Type type = typeof(T);
            if (dataSets.ContainsKey(type))
            {                
                dataSets[type].Remove(entity);
                
            }else
            {
                throw new DataException("Entity not found");
            }


        }
        public static void Delete<T>(Entity entity) where T : Entity
        {
            
            Type type = typeof(T);
            if (dataSets.ContainsKey(type))
            {
                dataSets[type].Remove(entity);

            }
            else
            {
                throw new DataException("Entity not found");
            }


        }


        public static Entity Update<T>(T updatedEntity) where T : Entity
        {
            Type type = typeof(T); // Get the type of the entity
            if (dataSets.ContainsKey(type))
            {
                var dataSet = dataSets[type]; // Get the list of entities for this type
                var existingEntity = dataSet.Cast<Entity>().FirstOrDefault(e => e.Id == updatedEntity.Id); //I've used ChatGPT to help me with the filter here

                if (existingEntity != null)
                {
                    // Remove the existing entity
                    dataSet.Remove(existingEntity);

                    // Add the updated entity
                    dataSet.Add(updatedEntity);

                    return updatedEntity;
                }
                else
                {
                    throw new DataException("Entity not found");
                }
            }
            else
            {
                throw new DataException("Type not found");
            }
        }


        public static Entity GetById<T>(int id) where T : Entity
        {
            Type type = typeof(T);
            if (dataSets.ContainsKey(type))
            {
                // Cast the list to a list of IEntity to access Id property
                List<Entity> entities = dataSets[type].Cast<Entity>().ToList();
                Entity entity = entities.FirstOrDefault(e => e.Id == id);
                if (entity != null)
                {
                    return entity;
                }
                throw new DataException("Entity not found");
            } else
                throw new DataException("Type not found");
        }

        //Get all items of one type
        public static List<Entity> GetItems<T>() where T : Entity
        {

            Type type = typeof(T);
            if (dataSets.ContainsKey(type))
            {
                List<Entity> entities = dataSets[type].Cast<Entity>().Reverse().ToList();//The list was reversed as displaying it showed that this was necessary
                return entities;
            }
            else
                throw new DataException("Type not found");


        
        }
        // Get all posts that match a specific filter
       
    }
}
