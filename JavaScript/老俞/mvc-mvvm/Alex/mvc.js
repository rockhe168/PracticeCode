//
// 根据http://geekswithblogs.net/dlussier/archive/2009/11/21/136454.aspx对比图，
// 做的mvc pattern
//
function addEvent(obj, type, callback) {
    var listeners = obj.__eventListener ? obj.__eventListener : (obj.__eventListener = {});
    if (!listeners[type]) {
        listeners[type] = [];
    }
    listeners[type].push(callback);
}

function fireEvent(obj, type, dataObj) {
    var listeners = obj.__eventListener, len = 0;
    if (listeners && listeners[type]) {
        listeners = listeners[type];
        len = listeners.length;
    }
    while (len--) {
        listeners[len].call(null, dataObj);
    }
}


function animation(el, value, original, callback) {
    var timer = setTimeout(function () {
        if (value) {
            value -= 5;
            original += 5;
            el.style.left = original + "px";
            setTimeout(arguments.callee, 100);
        }
        else {
            callback.call();
        }
    }, 100);
}

//
//
//
function SquareView(model) {
    this.el = document.getElementById("obj");
    this.model = model;
}
SquareView.prototype.move = function (value, callback) {
    var distance = this.el.style.left || 0;
    if (distance) {
        distance = distance.replace("px", "") - 0;
    }
    animation(this.el, value, distance, callback);
}
//
//
//
function DisplayView(model) {
    this.el = document.getElementById("info");
    this.model = model;
    this.update(this.model.getStatus());
    addEvent(this.model, "updateStatus", this.update.bind(this));
}
DisplayView.prototype.update = function (str) {
    this.el.innerHTML = str;
};
//
//
//
function ButtonView(model) {
    this.el = document.getElementById("btn");
    this.model = model;
    var that = this;
    addEvent(this.model, "updateStatus", function (str) {
        if (str == "done") {
            that.el.disabled = false;
        }
        else {
            that.el.disabled = true;
        }
    });
}
//
// 这个Model的抽象是当前物体
//
function Model() {
    var model = {
        distance: 0,
        status: "no started"
    };
    this.addDistance = function (value) {
        model.distance += value;
    }
    this.getStatus = function () {
        return model.status;
    };
    this.setStatus = function (value) {
        model.status = value;
        fireEvent(this, "updateStatus", model.status);
    }
}
//
// Controller所了解的更多，也是入口
//
function Controller() {
    var model = new Model(),
        squareView = new SquareView(model),
        displayView = new DisplayView(model),
        btnView = new ButtonView(model);

    function moveFinished() {
        model.setStatus("done");
    }
    this.move = function (value) {
        model.addDistance(value);
        model.setStatus("moving");
        squareView.move(value, moveFinished);
    };
}