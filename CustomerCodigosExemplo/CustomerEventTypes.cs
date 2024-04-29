// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29


using Ajinsoft.Commons.Entities;
using Ajinsoft.Features;

namespace Ajinsoft.Tools.Customers
{
public class CustomerEventTypes
{
public static readonly EventType Query = new(1006001, "Consulta", Feature.Customer );
public static readonly EventType Selection = new(1006002, "Seleção", Feature.Customer );
public static readonly EventType Creation = new(1006003, "Cadastro", Feature.Customer );
public static readonly EventType Update = new(1006004, "Atualização", Feature.Customer );
public static readonly EventType Exclusion = new(1006005, "Exclusão", Feature.Customer );
public static readonly EventType Restoration = new(1006006, "Restauração", Feature.Customer );
public static readonly EventType Listing = new(1006007, "Listagem", Feature.Customer );
public static readonly EventType UpdateStatus = new (1006008, "Atualização de Status", Feature.Customer );
public static readonly EventType SupportLoading = new(1006009, "Carregamento de Suporte", Feature.Customer );
public static readonly EventType AggregationByStatus = new(1006010, "Agregação por Status", Feature.Customer );
public static readonly EventType FilterFieldsLoading = new(1006011, "Carregamento de Campos de Filtros", Feature.Customer);
public static readonly EventType SettingLoading = new(1006012, "Carregamento de Configurações", Feature.Customer);
public static readonly EventType QueryBasic = new(1006013, "Consulta Básica", Feature.Customer );
}
}
