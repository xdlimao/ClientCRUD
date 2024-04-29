// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29

using Ajinsoft.Generics;
using Ajinsoft.Tools.Shared.Entities.Fields;
using System.Collections.Generic;
using Ajinsoft.Tools.Shared.Data.Supports;

namespace Ajinsoft.Tools.Customers.Supports
{
public class CustomerEntityField: EntityField
{
public static CustomerEntityField Id = new("_id", "Id", Ajinsoft.Commons.Fields.Data.Supports.DataType.Guid, EntityFieldLevel3.All);
public static CustomerEntityField Code = new("code", "Código", Ajinsoft.Commons.Fields.Data.Supports.DataType.Integer, EntityFieldLevel3.All);
public static CustomerEntityField Feature = new("feature", "Recurso", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField Type = new("type", "Tipo", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField Name = new("name", "Nome", Ajinsoft.Commons.Fields.Data.Supports.DataType.String, EntityFieldLevel3.Imported);
public static CustomerEntityField Nickname = new("nickname", "Apelido/Nome Fantasia", Ajinsoft.Commons.Fields.Data.Supports.DataType.String, EntityFieldLevel3.All);
public static CustomerEntityField Description = new("description", "Descrição", Ajinsoft.Commons.Fields.Data.Supports.DataType.String, EntityFieldLevel3.All);
public static CustomerEntityField PersonType = new("person_type", "Tipo de Pessoa", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField IdentityType = new("identity_type", "Tipo de Identidade", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField Identity = new("identity", "Identidade", Ajinsoft.Commons.Fields.Data.Supports.DataType.String, EntityFieldLevel3.All);
public static CustomerEntityField BirthDate = new("birth_date", "Data de Nascimento", Ajinsoft.Commons.Fields.Data.Supports.DataType.DateTime, EntityFieldLevel3.All, new List<KeyLabelValue> { new("format", "Formato", "dd/MM/yyyy") } );
public static CustomerEntityField Status = new("status", "Status", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField Enabled = new("enabled", "Ativo", Ajinsoft.Commons.Fields.Data.Supports.DataType.Boolean, EntityFieldLevel3.All);
public static CustomerEntityField Addresses = new("addresses", "Endereços", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField Phones = new("phones", "Telefones", Ajinsoft.Commons.Fields.Data.Supports.DataType.ListPhones, EntityFieldLevel3.None);
public static CustomerEntityField Emails = new("emails", "Emails", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField Documents = new("documents", "Documentos", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField BankAccounts = new("bank_accounts", "Contas Bancárias", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField Fields = new("fields", "Campos", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField Tags = new("tags", "Marcadores", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField TagCodes = new("tag_codes", "Código de Marcadores", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField Alerts = new("alerts", "Alertas", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField Relationships = new("relationships", "Relacionamentos", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField Parent = new("parent", "Pai", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField TimeZone = new("time_zone", "Fuso Horário", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField Avatar = new("avatar", "Avatar", Ajinsoft.Commons.Fields.Data.Supports.DataType.String, EntityFieldLevel3.All);
public static CustomerEntityField Image = new("image", "Imagem", Ajinsoft.Commons.Fields.Data.Supports.DataType.String, EntityFieldLevel3.All);
public static CustomerEntityField Color = new("color", "Cor", Ajinsoft.Commons.Fields.Data.Supports.DataType.String, EntityFieldLevel3.All);
public static CustomerEntityField ReferenceCode = new("reference_code", "Código de Referência", Ajinsoft.Commons.Fields.Data.Supports.DataType.String, EntityFieldLevel3.All);
public static CustomerEntityField ExternalCode = new("external_code", "Código Externo", Ajinsoft.Commons.Fields.Data.Supports.DataType.String, EntityFieldLevel3.All);
public static CustomerEntityField Ids = new("ids", "Ids", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField Note = new("note", "Observação", Ajinsoft.Commons.Fields.Data.Supports.DataType.String, EntityFieldLevel3.All);
public static CustomerEntityField Dealer = new("dealer", "Revendedor", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField Company = new("company", "Empresa", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField Account = new("account", "Conta", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField Partner = new("partner", "Parceiro", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField Store = new("store", "Loja", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField Broker = new("broker", "Agente", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField Log = new("log", "Log do Registro", Ajinsoft.Commons.Fields.Data.Supports.DataType.Object, EntityFieldLevel3.None);
public static CustomerEntityField RecordStatus = new("record_status", "Status do Registro", Ajinsoft.Commons.Fields.Data.Supports.DataType.Integer, EntityFieldLevel3.All);
public static CustomerEntityField SearchText = new("search_text", "Filtro de Consulta", Ajinsoft.Commons.Fields.Data.Supports.DataType.String, EntityFieldLevel3.None);

public static IEnumerable<CustomerEntityField> GetAll() => GetAll<CustomerEntityField>();
public static CustomerEntityField Get(string key) => Get<CustomerEntityField>(key);
public CustomerEntityField(string key, string name, string dataType, string exportLevel = EntityFieldLevel3.All, IList<KeyLabelValue> settings = null, string dbField = null, int index = 0) : base(key, name, dataType, exportLevel, settings, dbField, index) { }
}
}
