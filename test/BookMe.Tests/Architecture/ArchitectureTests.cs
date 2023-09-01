using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;
using BookMe.Application;
using BookMe.Domain.Abstractions;

namespace BookMe.Tests.Architecture
{
    public class ArchitectureTests
    {
        private static readonly ArchUnitNET.Domain.Architecture Architecture = new ArchLoader()
            .LoadAssemblies(
                typeof(Entity).Assembly,
                typeof(DependencyInjection).Assembly
            ).Build();

        private readonly IObjectProvider<IType> _domainLayer = Types()
            .That()
            .ResideInAssembly(typeof(Entity).Assembly)
            .As("Domain layer");

        private readonly IObjectProvider<IType> _applicationLayer = Types()
            .That()
            .ResideInAssembly(typeof(DependencyInjection).Assembly)
            .As("Application layer");

        [Fact]
        public void DomainLayerShouldNotDependOnAnyOtherLayers()
        {
            var appRule = Types().That()
                .Are(_domainLayer)
                .Should().NotDependOnAny(_applicationLayer);
            appRule.Check(Architecture);
        }


        //[Fact]
        //public void ApplicationLayerShouldOnlyDependOnDomainLayer()
        //{
        //    var appRule = Types().That()
        //        .Are(_applicationLayer)
        //        .Should().DependOnAny(_domainLayer);
        //    appRule.Check(Architecture);
        //}
    }
}
