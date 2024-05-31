using ClientCRUD.Shared.ComplexTypes;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Infra.Mappings
{
    public static class ComplexTypesMapping
    {
        public static void ComplexTypesMappingSet()
        {
            //ComplexTypes
            BsonClassMap.RegisterClassMap<Address>(classMap =>
            {
                classMap.MapMember(c => c.Type).SetElementName("type");
                classMap.MapMember(c => c.Street).SetElementName("street");
                classMap.MapMember(c => c.Number).SetElementName("number");
                classMap.MapMember(c => c.Complement).SetElementName("complement");
                classMap.MapMember(c => c.Neighborhood).SetElementName("neighborhood");
                classMap.MapMember(c => c.City).SetElementName("city");
                classMap.MapMember(c => c.State).SetElementName("state");
                classMap.MapMember(c => c.Country).SetElementName("country");
                classMap.MapMember(c => c.PostalCode).SetElementName("postal_code");
            });
            BsonClassMap.RegisterClassMap<Email>(classMap =>
            {
                classMap.MapMember(c => c.Type).SetElementName("type");
                classMap.MapMember(c => c.Address).SetElementName("address");
            });
            BsonClassMap.RegisterClassMap<Phone>(classMap =>
            {
                classMap.MapMember(c => c.Type).SetElementName("type");
                classMap.MapMember(c => c.CountryCode).SetElementName("country_code");
                classMap.MapMember(c => c.DDD).SetElementName("ddd");
                classMap.MapMember(c => c.PhoneNumber).SetElementName("phone_number");
            });
            BsonClassMap.RegisterClassMap<CodeName>(classMap =>
            {
                classMap.MapMember(c => c.Code).SetElementName("code");
                classMap.MapMember(c => c.Name).SetElementName("name");
            });
        }
    }
}
