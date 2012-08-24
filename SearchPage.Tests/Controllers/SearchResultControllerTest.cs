using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchPage.Controllers;
using SearchPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SearchPage.Tests.Controllers
{
    [TestClass]
    public class SearchResultControllerTest
    {
        [TestMethod]
        public void TestSearchForNews()
        {
            SearchResultController controller = new SearchResultController();

            SearchQuery query = new SearchQuery("test test", "NEWS");
            IEnumerable<SearchResult> result = controller.Post(query);

            Assert.AreEqual(6, result.Count());
            Assert.AreEqual("test test test", result.FirstOrDefault().Description);
        }
        [TestMethod]
        public void TestSearchForImages()
        {
            SearchResultController controller = new SearchResultController();

            SearchQuery query = new SearchQuery("image", "IMAGE");
            IEnumerable<SearchResult> result = controller.Post(query);

            Assert.AreEqual(5, result.Count());
            Assert.AreEqual("image image image", result.FirstOrDefault().Description);
        }

        [TestMethod]
        public void TestSearchForVideo()
        {
            SearchResultController controller = new SearchResultController();

            SearchQuery query = new SearchQuery("video", "VIDEO");
            IEnumerable<SearchResult> result = controller.Post(query);

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("video video video", result.FirstOrDefault().Description);
        }
    }
}
