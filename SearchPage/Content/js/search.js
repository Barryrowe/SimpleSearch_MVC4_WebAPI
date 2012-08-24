

//Setup our search util namespace, so all of our JS for this feature is sandboxed
(function (searchUtil, $, undefined) {
    //Store a reference to our search util in the closure, so it's methods can
    //refer to itself without worrying about global scope
    var instance = searchUtil;

    searchUtil.renderResults = function (results) {
        var $resultContainer = $("#resultContainer");

        if (results && results.length > 0) {
            $('li', $resultContainer).remove();
        }


        $.each(results, function (i, result) {
            var rowClass = 'alt', html = '';
            if (i % 2 !== 0) {
                rowClass = '';
            }
            //With more time this could get run through a templating engine
            //like mustache.js or something similar.         

            html += '<li class="result ';
            html += rowClass;
            html += '"><a href="';
            html += result.Url;
            html += '">';
            html += result.Url;
            html += '</a><div class="description">';
            html += result.Description;
            html += '</div>';
            if (result.ResultType === 'IMAGE') {
                html += '<img src="';
                html += result.mediaUrl;
                html += '" />';
            } else if (result.ResultType === 'VIDEO') {
                html += '<a href="'
                html += result.mediaUrl
                html += '" target="_blank">View Video</a>';
            }
            html += '</li>';
            $resultContainer.append(html);
        });
    }
    //The function that will actuall perform our search
    searchUtil.search = function () {
        //initialize our vars up top
        var myQuery, mySearchType;

        //grap the searchQuery text
        myQuery = $("#searchQuery").val();
        mySearchType = $("#searchType").val();

        //if the text not empty we can call our api
        if (myQuery) {            
            $.getJSON('/api/SearchResult',
                     { query: myQuery, searchType: mySearchType },
                     function (results) {
                         instance.renderResults(results);
                     });
        } else {
            //Some quick and dirty Focus grabbing Style manipulation to show
            //a search query is requried
            $("#searchQuery").focus().css('background', '#E80000');
            setTimeout(function () {
                $("#searchQuery").css('background', '');
            }, 1000);
        }
    };

    //Here is where we Wire up all of our Events
    searchUtil.init = function () {
        $("#searchForm").live('submit', function (e) {
            e.preventDefault();
            instance.search();            
        });
    };
})(window.searchUtil = window.searchUtil || {}, jQuery);

//On Dom Ready, as long as our searchUtil Namespace is available we initialize our Search events
$(document).ready(function () {
    if (window.searchUtil) {
        searchUtil.init();
    }
});