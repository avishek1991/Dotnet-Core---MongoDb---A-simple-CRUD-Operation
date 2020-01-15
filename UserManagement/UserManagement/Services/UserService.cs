using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Services
{
    //This is our services class 
    public class UserService 
    {
        private IMongoCollection<UserModel> UserData;
        public UserService( IConfiguration config)
        {
            //This is For ConnectionString
            MongoClient client = new MongoClient(config.GetConnectionString("UserConnection"));
            //creat database in MongoDB Data Base
            IMongoDatabase database = client.GetDatabase("UserDB");
            //creat Collection in MongoDB Data Base and Retrive Data
            UserData = database.GetCollection<UserModel>("UserCollection");
        }

        //Get All User Data in List Format
        public IEnumerable<UserModel> AllUsers()
        {
            return UserData.Find(X => true).ToList();
        }

        //Creat User Method 
        public void CreatUser(UserModel model)
        {
            UserData.InsertOne(model);
        }


        //One User Get To the MongoDB Server
        public UserModel GetOneUser(string id)
        {
            return UserData.Find(X => X.Id == id).FirstOrDefault();
        }

        //Edit User Data to MongoDb Server
        public void EditUser(string id, UserModel model)
        {
            UserData.ReplaceOne(X => X.Id == id, model);
        }

        //Delete User Data in MingoDB Sever
        public void DeleteUser(UserModel model)
        {
            UserData.DeleteOne(X => X.Id == model.Id);
        }




    }
}
