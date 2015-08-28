chrome.app.runtime.onLaunched.addListener(function () {
    chrome.app.window.create('Main.html', {
        frame: "none",
        'outerBounds': {
            'width': 650,
            'height': 415
        }
    });
});