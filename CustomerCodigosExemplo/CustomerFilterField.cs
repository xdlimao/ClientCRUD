// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29


namespace Ajinsoft
{
public class CustomerFilterField : FilterFieldType
{
public static FilterFieldType Id = new("id", "Id", Words.Id, "guid", FilterFieldOperator.Eq, true);
public static FilterFieldType Code = new("code", "Code", Words.Code, "int", FilterFieldOperator.Eq, true);
public static FilterFieldType FeatureCode = new("feature.code", "FeatureCode", Words.Feature, "int", FilterFieldOperator.Eq, true);
public static FilterFieldType FeatureName = new("feature.name", "FeatureName", Words.Feature, "string", FilterFieldOperator.Regex, false);
public static FilterFieldType TypeCode = new("type.code", "TypeCode", Words.Type, "int", FilterFieldOperator.Eq, true);
public static FilterFieldType TypeName = new("type.name", "TypeName", Words.Type, "string", FilterFieldOperator.Regex, false);
public static FilterFieldType Name = new("name", "Name", Words.Name, "string", FilterFieldOperator.Regex, true);
public static FilterFieldType Nickname = new("nickname", "Nickname", Words.Nickname, "string", FilterFieldOperator.Regex, true);
public static FilterFieldType Description = new("description", "Description", Words.Description, "string", FilterFieldOperator.Regex, true);
public static FilterFieldType PersonTypeCode = new("person_type.code", "PersonTypeCode", Words.PersonType, "int", FilterFieldOperator.Eq, true);
public static FilterFieldType PersonTypeName = new("person_type.name", "PersonTypeName", Words.PersonType, "string", FilterFieldOperator.Regex, false);
public static FilterFieldType IdentityTypeCode = new("identity_type.code", "IdentityTypeCode", Words.IdentityType, "int", FilterFieldOperator.Eq, true);
public static FilterFieldType IdentityTypeName = new("identity_type.name", "IdentityTypeName", Words.IdentityType, "string", FilterFieldOperator.Regex, false);
public static FilterFieldType Identity = new("identity", "Identity", Words.Identity, "string", FilterFieldOperator.Regex, true);
public static FilterFieldType BirthDate = new("birth_date", "BirthDate", Words.BirthDate, "date", FilterFieldOperator.Eq, true);
public static FilterFieldType StatusId = new("status.id", "StatusId", Words.Status, "guid", FilterFieldOperator.Eq, true);
public static FilterFieldType StatusCode = new("status.code", "StatusCode", Words.Status, "int", FilterFieldOperator.Eq, false);
public static FilterFieldType StatusName = new("status.name", "StatusName", Words.Status, "string", FilterFieldOperator.Regex, false);
public static FilterFieldType StatusDate = new("status.date", "StatusDate", Words.StatusDate, "date", FilterFieldOperator.Eq, true);
public static FilterFieldType StatusColor = new("status.color", "StatusColor", Words.StatusColor, "string", FilterFieldOperator.Regex, false);
public static FilterFieldType StatusNote = new("status.note", "StatusNote", Words.StatusNote, "string", FilterFieldOperator.Regex, true);
public static FilterFieldType Enabled = new("enabled", "Enabled", Words.Enabled, "bool", FilterFieldOperator.Eq, true);
//!Validar
//public static FilterFieldType Addresses = new("addresses", "Addresses", Words.Addresses, "list<address>", FilterFieldOperator.Regex, true);
//!Validar
//public static FilterFieldType Phones = new("phones", "Phones", Words.Phones, "list<phone>", FilterFieldOperator.Regex, true);
//!Validar
//public static FilterFieldType Emails = new("emails", "Emails", Words.Emails, "list<email>", FilterFieldOperator.Regex, true);
//!Validar
//public static FilterFieldType Documents = new("documents", "Documents", Words.Documents, "list<persondocument>", FilterFieldOperator.Regex, true);
//!Validar
//public static FilterFieldType BankAccounts = new("bank_accounts", "BankAccounts", Words.BankAccounts, "list<bankaccount>", FilterFieldOperator.Regex, true);
//!Validar
//public static FilterFieldType Fields = new("fields", "Fields", Words.Fields, "list<datafield>", FilterFieldOperator.Regex, true);
//!Validar
//public static FilterFieldType Tags = new("tags", "Tags", Words.Tags, "list<statusfield>", FilterFieldOperator.Regex, true);
public static FilterFieldType TagCodes = new("tag_codes", "TagCodes", Words.TagCodes, "list<int>", FilterFieldOperator.In, true);
//!Validar
//public static FilterFieldType Alerts = new("alerts", "Alerts", Words.Alerts, "list<statusfield>", FilterFieldOperator.Regex, true);
//!Validar
//public static FilterFieldType Relationships = new("relationships", "Relationships", Words.Relationships, "list<relationshipfield>", FilterFieldOperator.Regex, true);
public static FilterFieldType ParentId = new("parent.id", "ParentId", Words.Parent, "guid", FilterFieldOperator.Eq, true);
public static FilterFieldType ParentCode = new("parent.code", "ParentCode", Words.Parent, "int", FilterFieldOperator.Eq, false);
public static FilterFieldType ParentName = new("parent.name", "ParentName", Words.Parent, "string", FilterFieldOperator.Regex, false);
public static FilterFieldType TimeZoneId = new("time_zone.id", "TimeZoneId", Words.TimeZone, "string", FilterFieldOperator.Regex, true);
public static FilterFieldType TimeZoneName = new("time_zone.name", "TimeZoneName", Words.TimeZone, "string", FilterFieldOperator.Regex, false);
public static FilterFieldType Avatar = new("avatar", "Avatar", Words.Avatar, "string", FilterFieldOperator.Regex, true);
public static FilterFieldType Image = new("image", "Image", Words.Image, "string", FilterFieldOperator.Regex, true);
public static FilterFieldType Color = new("color", "Color", Words.Color, "string", FilterFieldOperator.Regex, true);
public static FilterFieldType ReferenceCode = new("reference_code", "ReferenceCode", Words.ReferenceCode, "string", FilterFieldOperator.Regex, true);
public static FilterFieldType ExternalCode = new("external_code", "ExternalCode", Words.ExternalCode, "string", FilterFieldOperator.Regex, true);
public static FilterFieldType Ids = new("ids", "Ids", Words.Ids, "list<guid>", FilterFieldOperator.In, true);
public static FilterFieldType Note = new("note", "Note", Words.Note, "string", FilterFieldOperator.Regex, true);
public static FilterFieldType DealerId = new("dealer.id", "DealerId", Words.Dealer, "guid", FilterFieldOperator.Eq, true);
public static FilterFieldType DealerCode = new("dealer.code", "DealerCode", Words.Dealer, "int", FilterFieldOperator.Eq, false);
public static FilterFieldType DealerName = new("dealer.name", "DealerName", Words.Dealer, "string", FilterFieldOperator.Regex, false);
public static FilterFieldType CompanyId = new("company.id", "CompanyId", Words.Company, "guid", FilterFieldOperator.Eq, true);
public static FilterFieldType CompanyCode = new("company.code", "CompanyCode", Words.Company, "int", FilterFieldOperator.Eq, false);
public static FilterFieldType CompanyName = new("company.name", "CompanyName", Words.Company, "string", FilterFieldOperator.Regex, false);
public static FilterFieldType AccountId = new("account.id", "AccountId", Words.Account, "guid", FilterFieldOperator.Eq, true);
public static FilterFieldType AccountCode = new("account.code", "AccountCode", Words.Account, "int", FilterFieldOperator.Eq, false);
public static FilterFieldType AccountName = new("account.name", "AccountName", Words.Account, "string", FilterFieldOperator.Regex, false);
public static FilterFieldType PartnerId = new("partner.id", "PartnerId", Words.Partner, "guid", FilterFieldOperator.Eq, true);
public static FilterFieldType PartnerCode = new("partner.code", "PartnerCode", Words.Partner, "int", FilterFieldOperator.Eq, false);
public static FilterFieldType PartnerName = new("partner.name", "PartnerName", Words.Partner, "string", FilterFieldOperator.Regex, false);
public static FilterFieldType StoreId = new("store.id", "StoreId", Words.Store, "guid", FilterFieldOperator.Eq, true);
public static FilterFieldType StoreCode = new("store.code", "StoreCode", Words.Store, "int", FilterFieldOperator.Eq, false);
public static FilterFieldType StoreName = new("store.name", "StoreName", Words.Store, "string", FilterFieldOperator.Regex, false);
public static FilterFieldType BrokerId = new("broker.id", "BrokerId", Words.Broker, "guid", FilterFieldOperator.Eq, true);
public static FilterFieldType BrokerCode = new("broker.code", "BrokerCode", Words.Broker, "int", FilterFieldOperator.Eq, false);
public static FilterFieldType BrokerName = new("broker.name", "BrokerName", Words.Broker, "string", FilterFieldOperator.Regex, false);
public static FilterFieldType CreationDate = new("creation_date", "CreationDate", Words.CreationDate, "date", FilterFieldOperator.Eq, true);
public static FilterFieldType CreationUserId = new("creation_user.id", "CreationUserId", Words.CreationUser, "guid", FilterFieldOperator.Eq, true);
public static FilterFieldType CreationUserCode = new("creation_user.code", "CreationUserCode", Words.CreationUser, "int", FilterFieldOperator.Eq, false);
public static FilterFieldType CreationUserName = new("creation_user.name", "CreationUserCode", Words.CreationUser, "string", FilterFieldOperator.Regex, false);
public static FilterFieldType ChangeDate = new("change_date", "ChangeDate", Words.ChangeDate, "date", FilterFieldOperator.Eq, true);
public static FilterFieldType ChangeUserId = new("change_user.id", "ChangeUserId", Words.ChangeUser, "guid", FilterFieldOperator.Eq, true);
public static FilterFieldType ChangeUserCode = new("change_user.code", "ChangeUserCode", Words.ChangeUser, "int", FilterFieldOperator.Eq, false);
public static FilterFieldType ChangeUserName = new("change_user.name", "ChangeUserCode", Words.ChangeUser, "string", FilterFieldOperator.Regex, false);
public static FilterFieldType ExclusionDate = new("exclusion_date", "ExclusionDate", Words.ExclusionDate, "date", FilterFieldOperator.Eq, false);
public static FilterFieldType ExclusionUserId = new("exclusion_user.id", "ExclusionUserId", Words.ExclusionUser, "guid", FilterFieldOperator.Eq, false);
public static FilterFieldType ExclusionUserCode = new("exclusion_user.code", "ExclusionUserCode", Words.ExclusionUser, "int", FilterFieldOperator.Eq, false);
public static FilterFieldType ExclusionUserName = new("exclusion_user.name", "ExclusionUserCode", Words.ExclusionUser, "string", FilterFieldOperator.Regex, false);
public static FilterFieldType PreviousId = new("previous_id", "PreviousId", Words.PreviousId, "guid", FilterFieldOperator.Eq, true);
public static FilterFieldType VersionId = new("version_id", "VersionId", Words.VersionId, "guid", FilterFieldOperator.Eq, true);
public static FilterFieldType VersionDate = new("version_date", "VersionDate", Words.VersionDate, "date", FilterFieldOperator.Eq, true);

public static FilterFieldType SearchText = new("search_text", "SearchText", Words.SearchText, "string", FilterFieldOperator.Regex, true);

public CustomerFilterField(string key, string name, string label, string type, string @operator, bool active = false) : base(key, name, label, type, @operator, active) { }
}
}
