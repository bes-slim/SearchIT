using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Searchinator.Core.Contracts;
using Searchinator.Models;

namespace Searchinator.Core.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new IocModule());
            var search = kernel.Get<ISearch>();
            var query = new SearchQuery()
            {
                Text = "my keyword",
                GeneralInfo = new GeneralInfo()
                {
                    PriceFrom = 10000
                    //PriceTo = 50000
                }
            };
            Console.WriteLine(search.SearchFor(query));
            Console.ReadKey();



        }
    }
}
