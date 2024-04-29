// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29



using Ajinsoft.Features;
using Ajinsoft.Tools.Users.Rules;

namespace Ajinsoft.Tools.Customers
{
public class CustomerRules
{
public static UserRuleModel Query = new(1006001, "Consultar", Feature.Customer, UserRuleType.Authorization);
public static UserRuleModel Access = new(1006002, "Acessar", Feature.Customer, UserRuleType.Authorization);
public static UserRuleModel Create = new(1006003, "Cadastrar", Feature.Customer, UserRuleType.Authorization);
public static UserRuleModel Edit = new(1006004, "Editar", Feature.Customer, UserRuleType.Authorization);
public static UserRuleModel Delete = new(1006005, "Excluir", Feature.Customer, UserRuleType.Authorization);

public static UserRuleModel ViewOwnAccount = new(1006500, "Visualizar clientes da própria conta", Feature.Customer, UserRuleType.AccessLevel);
public static UserRuleModel ViewSelectedAccounts = new(1006501, "Visualizar clientes das contas selecionadas", Feature.Customer, UserRuleType.AccessLevel, "accounts"); 
public static UserRuleModel ViewOwnStore = new(1006502, "Visualizar clientes da própria loja", Feature.Customer, UserRuleType.AccessLevel);
public static UserRuleModel ViewSelectedStores = new(1006503, "Visualizar clientes das lojas selecionadas", Feature.Customer, UserRuleType.AccessLevel, "stores"); 
public static UserRuleModel ViewStoreGroups = new(1006504, "Visualizar clientes dos grupos de lojas", Feature.Customer, UserRuleType.AccessLevel, "store_groups"); 
public static UserRuleModel ViewOwnStoreGroup = new(1006505, "Visualizar clientes do próprio grupo de lojas", Feature.Customer, UserRuleType.AccessLevel);
public static UserRuleModel ViewOwnBroker = new(1006506, "Visualizar clientes do próprio agente", Feature.Customer, UserRuleType.AccessLevel);
public static UserRuleModel ViewSelectedBrokers = new(1006507, "Visualizar clientes dos agentes selecionadas", Feature.Customer, UserRuleType.AccessLevel, "brokers"); 
public static UserRuleModel ViewBrokerGroups = new(1006508, "Visualizar clientes dos grupos de agentes", Feature.Customer, UserRuleType.AccessLevel, "broker_groups"); 
public static UserRuleModel ViewOwnBrokerGroup = new(1006509, "Visualizar clientes do próprio grupo de agentes", Feature.Customer, UserRuleType.AccessLevel);
public static UserRuleModel ViewWithStatus = new(1006510, "Visualizar clientes com status", Feature.Customer, UserRuleType.AccessLevel, "partner_status"); 
public static UserRuleModel ViewAccordingToHierarchy = new(1006511, "Visualizar clientes conforme à hierarquia", Feature.Customer, UserRuleType.AccessLevel);
public static UserRuleModel EditWithStatus = new(1006512, "Editar clientes com status", Feature.Customer, UserRuleType.EditLevel, "partner_status"); 
}
}
