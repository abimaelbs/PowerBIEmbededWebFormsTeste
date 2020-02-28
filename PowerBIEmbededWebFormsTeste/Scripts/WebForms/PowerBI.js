
window.onload = function () { // find the iFrame on the page and handle the loaded event.
    var iframe = document.getElementById('iFrameEmbedReport');
    iframe.src = document.getElementById('MainContent_embedUrlText').value;  //embedReportUrl;
    iframe.onload = postActionLoadReport;
    // post the access token to the iFrame to load the tile
    function postActionLoadReport() {
        // get the app token.
        accessToken = document.getElementById('MainContent_accessTokenText').value;//{generate app token};
        // construct the push message structure
        var m = { action: "loadReport", accessToken: accessToken };
        message = JSON.stringify(m);
        // push the message.
        iframe = document.getElementById('iFrameEmbedReport');
        iframe.contentWindow.postMessage(message, "*");
    }
};