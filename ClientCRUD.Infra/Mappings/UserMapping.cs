using ClientCRUD.Domain.Entities;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Infra.Mappings
{
    public static class UserMapping
    {
        public static void UserMappingSet()
        {
            BsonClassMap.RegisterClassMap<User>(classMap =>
            {
                classMap.MapIdMember(c => c.Id);
                classMap.MapMember(c => c.Login).SetElementName("login");
                classMap.MapMember(c => c.Password).SetElementName("password");
                classMap.MapMember(c => c.Type).SetElementName("type");
            });
        }
    }
}
