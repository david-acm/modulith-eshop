using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;

namespace eShop.Billing.Tests;

public class DomainTypesShould
{
  private static readonly Architecture Architecture =
    new ArchLoader()
      .LoadAssemblies(typeof(AssemblyInfo).Assembly)
      .Build();

  [Fact]
  public void NotDependOnApiTypes()
  {
    var domainTypes = ArchRuleDefinition.Types()
      .That()
      .ResideInNamespace("eShop.Billing.Domain.*", useRegularExpressions: true)
      .And().AreNot([typeof(AssemblyInfo), typeof(BillingServiceRegistrar)])
      .As("Domain types");
    
    var apiTypes = ArchRuleDefinition.Types()
      .That()
      .ResideInNamespace("eShop.Billing.Api.*", useRegularExpressions: true)
      .As("Api types");

    var rule = domainTypes.Should().NotDependOnAny(apiTypes);

    rule.Check(Architecture);
  }
  
  [Fact]
  public void NotDependOnInfraTypes()
  {
    var domainTypes = ArchRuleDefinition.Types()
      .That()
      .ResideInNamespace("eShop.Billing.Domain.*", useRegularExpressions: true)
      .And().AreNot([typeof(AssemblyInfo), typeof(BillingServiceRegistrar)])
      .As("Domain types");
    
    var apiTypes = ArchRuleDefinition.Types()
      .That()
      .ResideInNamespace("eShop.Billing.Infrastructure.*", useRegularExpressions: true)
      .As("Api types");

    var rule = domainTypes.Should().NotDependOnAny(apiTypes);

    rule.Check(Architecture);
  }
}
