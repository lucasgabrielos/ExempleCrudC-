using MongoDB.Driver;
using PetShop.Models;

namespace PetShop.Database
{
    public class MongoConfiguration
    {
        public IMongoCollection<UsersModel> _usersCollection;
        public MongoConfiguration()
        {
            //Pedir a string de conexão a Lucas
            var client = new MongoClient("");
            var database = client.GetDatabase("PetShop"); 
            _usersCollection = database.GetCollection<UsersModel>("Users"); 
        }
    }
}
 