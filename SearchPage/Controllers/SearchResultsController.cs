using SearchPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SearchPage.Controllers
{
    public class SearchResultController : ApiController
    {
        SearchResult[] results = new SearchResult[]{
            new SearchResult() { Url="test.com", Description="test test test", mediaUrl="", ResultType="NEWS" },
            new SearchResult() { Url="test.com/test1", Description="test test test test test test", mediaUrl="", ResultType="NEWS" },
            new SearchResult() { Url="test.com/test2", Description="test test test test test test test test test", mediaUrl="", ResultType="NEWS" },
            new SearchResult() { Url="test.com/test3", Description="test test test test test test test test test test test test test test test", mediaUrl="", ResultType="NEWS" },
            new SearchResult() { Url="test.com/test4", Description="test test test test test test test test test test test test test test test test test test", mediaUrl="", ResultType="NEWS" },
            new SearchResult() { Url="test.com/test5", Description="test test test test test test test test test test test test test test test test test test test test test", mediaUrl="", ResultType="NEWS" },
            new SearchResult() { Url="test.com/image1", Description="image image image", mediaUrl="http://baconmockup.com/100/100", ResultType="IMAGE" },
            new SearchResult() { Url="test.com/image2", Description="image image image image image image ", mediaUrl="http://baconmockup.com/100/50", ResultType="IMAGE" },
            new SearchResult() { Url="test.com/image3", Description="image image image image image image  image image image  ", mediaUrl="http://baconmockup.com/50/50", ResultType="IMAGE" },
            new SearchResult() { Url="test.com/image4", Description="image image image image image image image image image image image image", mediaUrl="http://baconmockup.com/20/100", ResultType="IMAGE" },
            new SearchResult() { Url="test.com/image5", Description="image image image image image image image image image image image image image image image", mediaUrl="http://baconmockup.com/20/20", ResultType="IMAGE" },
            new SearchResult() { Url="test.com/video1", Description="video video video", mediaUrl="http://youtube.com", ResultType="VIDEO" },
            new SearchResult() { Url="test.com/video2", Description="video video video video video video", mediaUrl="http://youtube.com", ResultType="VIDEO" },
            new SearchResult() { Url="test.com/video3", Description="video video video video video video video video video", mediaUrl="http://youtube.com", ResultType="VIDEO" }
        };

        
        public IEnumerable<SearchResult> Get([FromUri]SearchQuery searchQuery)
        {            
            return results.Where(x => (x.ResultType == searchQuery.searchType && (x.Description.Contains(searchQuery.query) || x.Url.Contains(searchQuery.query))));
        }
        
        public IEnumerable<SearchResult> Post([FromUri]SearchQuery searchQuery)
        {
            return results.Where(x => (x.ResultType == searchQuery.searchType && (x.Description.Contains(searchQuery.query) || x.Url.Contains(searchQuery.query))));
        }

    }
}
