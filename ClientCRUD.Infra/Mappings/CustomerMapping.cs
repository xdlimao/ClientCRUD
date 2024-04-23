using ClientCRUD.Domain.Entities;
using ClientCRUD.Shared.ComplexTypes;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Infra.Mappings
{
    public static class CustomerMapping
    {
        public static void CustomerMappingSet()
        {
            //Entity
            BsonClassMap.RegisterClassMap<Customer>(classMap =>
            {
                //classMap.AutoMap(); <- só funciona com camelCase e não com PascalCase
                classMap.MapMember(c => c.Id).SetElementName("_id");
                classMap.MapMember(c => c.Code).SetElementName("code");
                classMap.MapMember(c => c.Type).SetElementName("type");
                classMap.MapMember(c => c.Name).SetElementName("name");
                classMap.MapMember(c => c.Nickname).SetElementName("nickname");
                classMap.MapMember(c => c.Description).SetElementName("description");
                classMap.MapMember(c => c.PersonType).SetElementName("person_type");
                classMap.MapMember(c => c.IdentityType).SetElementName("identity_type");
                classMap.MapMember(c => c.Identity).SetElementName("identity");
                classMap.MapMember(c => c.Birthdate).SetElementName("birthdate");
                classMap.MapMember(c => c.Enabled).SetElementName("enabled");
                classMap.MapMember(c => c.Addresses).SetElementName("addresses");
                classMap.MapMember(c => c.Phones).SetElementName("phones");
                classMap.MapMember(c => c.Emails).SetElementName("emails");
                classMap.MapMember(c => c.Avatar).SetElementName("avatar");
                classMap.MapMember(c => c.Image).SetElementName("image");
                classMap.MapMember(c => c.Color).SetElementName("color");
                classMap.MapMember(c => c.ReferenceCode).SetElementName("reference_code");
                classMap.MapMember(c => c.Note).SetElementName("Note");
            });
        }
    }
}
