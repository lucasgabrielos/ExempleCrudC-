using MongoDB.Driver;
using PetShop.Models;

namespace PetShop.Database
{
    public class MongoConfiguration
    {
        public IMongoCollection<UsersModel> _usersCollection;
        public MongoConfiguration()
        {
            var client = new MongoClient("mongodb+srv://LucasGabriel:ilB1CXQuMfjL072t@petshop.sg87o.mongodb.net/?retryWrites=true&w=majority&appName=PetShop");
            var database = client.GetDatabase("PetShop"); 
            _usersCollection = database.GetCollection<UsersModel>("Users"); 
        }
    }
}
 