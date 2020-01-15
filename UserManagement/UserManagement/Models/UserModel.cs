using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Models
{
    //This is our Model class
    public class UserModel
    {
       
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")][Required]
        public string Name { get; set; }

        [BsonElement("City")][Required]
        public string City { get; set; }

        [BsonElement("Email")] [EmailAddress] [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email Field Is Required")]
        public string Email { get; set; }

    }
}
