namespace Searchinator.Core
{
    public interface IBaseSearchRule
    {
        bool IsApplicable(SearchQuery query);
        string AddToSearch(SearchQuery query);
    }
}