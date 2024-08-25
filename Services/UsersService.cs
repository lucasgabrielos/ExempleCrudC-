using MongoDB.Bson;
using MongoDB.Driver;
using PetShop.Database;
using PetShop.Models;

namespace PetShop.Services
{
    public class UsersService
    {
        public static MongoConfiguration Configuration = new MongoConfiguration();
        public static IMongoCollection<UsersModel> UserDataBase = Configuration._usersCollection;

        public static UsersModel GetUserById(string id)
        {
            var user =  UserDataBase.AsQueryable().FirstOrDefault(user => user.Id == id);
            return user?? new UsersModel();
        }

        public static UsersModel GetUserByEmailAndPassword(string mail, string password)
        {
            var user = UserDataBase.AsQueryable().FirstOrDefault(x => x.Email == mail && x.Password == password);
            return user?? new UsersModel();
        }

        public static bool InsertNewUser(UsersModel user)
        {
            try
            {
                UserDataBase.InsertOne(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UpdateUser(UsersModel user)
        {
            try
            {
                var filterBuilder = Builders<UsersModel>.Filter;
                var query = filterBuilder.Eq(obj => obj.Id, user.Id);

                var updateOptions = new UpdateOptions { IsUpsert = true };

                var updateBuilder = Builders<UsersModel>.Update;
                var update = updateBuilder
                    .Set(obj => obj.Name, user.Name)
                    .Set(obj => obj.Password, user.Password)
                    .Set(obj => obj.Email, user.Email);

                var updateResult =  UserDataBase.UpdateOne(query, update, updateOptions);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
