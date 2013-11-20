(function (win) {
    var Controller = win.Controller;

    var controller = new Controller();

    win.test = function () {
        controller.move(20);
    }
})(this);