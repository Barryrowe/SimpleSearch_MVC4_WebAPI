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
        //This is just a hardcoded Array of SearchResult items, but this is where the Controller would need some type of
        //DbContext/Repository to ask for, and push search results into.  Once that were done, we would need to make sure
        //the dependency is injected properly (through Ninject, Unity Service Locator, or some other tool), and mock up
        //a bogus repo/context with dummy data like below for our test cases.
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

        
        //So simple...but the fact that the MODEL object has to have a 0 argument constructor really threw me for a loop. Thank god for a short response to a StackOverflow Answer.
        public IEnumerable<SearchResult> Get([FromUri]SearchQuery searchQuery)
        {            
            return results.Where(x => (x.ResultType == searchQuery.searchType && (x.Description.Contains(searchQuery.query) || x.Url.Contains(searchQuery.query))));
        }        
    }
}
