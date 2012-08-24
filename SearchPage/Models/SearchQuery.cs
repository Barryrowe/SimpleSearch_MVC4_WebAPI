using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchPage.Models
{
    public class SearchQuery
    {
        public string query { get; set; }
        public string searchType { get; set; }

        public SearchQuery()
        {
        }

        public SearchQuery(string query, string searchType)
        {
            this.query = query;
            this.searchType = searchType;
        }
    }
}