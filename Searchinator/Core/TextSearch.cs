namespace Searchinator.Core
{
    public class TextSearch : IBaseSearchRule
    {
        public const string SEARCH_FOR_TEXT = "Search for this text ";

        public bool IsApplicable(SearchQuery query)
        {
            return !string.Empty.Equals(query.Text);
        }

        public string AddToSearch(SearchQuery query)
        {
            return SEARCH_FOR_TEXT + query.Text + "\n";
        }
    }
}