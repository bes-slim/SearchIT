using System.Linq;
using Ninject;
using Ninject.Modules;
using Searchinator.Core.Contracts;

namespace Searchinator.Core.Client
{
    public class IocModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBaseSearchRule>().To<GeneralInfoSearch>();
            Bind<IBaseSearchRule>().To<TextSearch>();


            Bind<IGeneralInfoSearchRule>().To<PriceToRule>();
            Bind<IGeneralInfoSearchRule>().To<PriceFromRule>();


            Bind<ISearch>()
            .To<Search>()
            .WithConstructorArgument(
                Search.CTOR_SEARCH_RULES_ARG_NAME,
                x => x.Kernel.GetAll<IBaseSearchRule>().ToList());


            Bind<IGeneralInfoSectionSearch>()
            .To<GeneralInfoSectionSearch>()
            .WithConstructorArgument(
                GeneralInfoSectionSearch.CTOR_GENERAL_INFO_SEARCH_RULES_ARG_NAME,
                x => x.Kernel.GetAll<IGeneralInfoSearchRule>().ToList());
        }
    }
}