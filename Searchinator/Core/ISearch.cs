namespace Searchinator.Core
{
    public interface ISearch
    {
        string SearchFor(SearchQuery query);
    }
}