using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Nest;
using Ninject;
using Searchinator.Core;

namespace Searchinator
{
    class Program
    {
        private static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
  
            IList<IBaseSearchRule> baseSearchRules = 
                kernel.GetAll<IBaseSearchRule>().ToList();

            IList<IGeneralInfoSearchRule> generalInfoSearchRules =
                kernel.GetAll<IGeneralInfoSearchRule>().ToList();

            kernel.Bind<IBaseSearchRule>().To<TextSearch>();
            kernel.Bind<IBaseSearchRule>().To<GeneralInfoSearch>();

            kernel.Bind<IGeneralInfoSearchRule>().To<PriceToRule>();
            kernel.Bind<IGeneralInfoSearchRule>().To<PriceFromRule>();

            kernel.Bind<ISearch>()
                .To<Search>()
                .WithConstructorArgument(Search.CTOR_SEARCH_RULES_ARG_NAME, baseSearchRules);

            kernel.Bind<IGeneralInfoSectionSearch>()
                .To<GeneralInfoSectionSearch>()
                .WithConstructorArgument(GeneralInfoSectionSearch.CTOR_GENERAL_INFO_SEARCH_RULES_ARG_NAME,
                    generalInfoSearchRules);

          


            SearchQuery query = new SearchQuery() 
            { 
                Text = "Awsome thing", 
                GeneralInfo = new GeneralInfo()
                {
                    PriceTo = 200,
                    PriceFrom = 10
                } 
            };

            var searchinator = kernel.Get<ISearch>();
            var output = searchinator.SearchFor(query);

            Console.WriteLine(output);

            Console.ReadKey();
        }
    }

}
