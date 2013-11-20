//
// 根据http://geekswithblogs.net/dlussier/archive/2009/11/21/136454.aspx对比图，
// 做的mvvm pattern
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



function SquareView(viewModel) {
    this.el = document.getElementById("obj");
    this.viewModel = viewModel;

    addEvent(this.viewModel, "move", this.move.bind(this));
}
SquareView.prototype.move = function (value) {
    var distance = this.el.style.left || 0;
    if (distance) {
        distance = distance.replace("px", "") - 0;
    }
    animation(this.el, value, distance, (function () {
        this.viewModel.done();
    }).bind(this));
}
SquareView.prototype.go = function (value) {
    this.viewModel.go(value);
}
function DisplayView(viewModel) {
    this.el = document.getElementById("info");
    this.viewModel = viewModel;
    this.update(this.viewModel.getStatus());
    addEvent(this.viewModel, "updateStatus", this.update.bind(this));
}
DisplayView.prototype.update = function (str) {
    this.el.innerHTML = str;
};
//
// BtnView是动作的发起者
//
function ButtonView(viewModel) {
    this.el = document.getElementById("btn");
    this.viewModel = viewModel;
    var that = this;
    addEvent(this.viewModel, "updateStatus", function (str) {
        if (str == "done") {
            that.el.disabled = false;
        }
        else {
            that.el.disabled = true;
        }
    });
    this.el.addEventListener("click", function () {
        that.viewModel.go(20);
    }, false);
}
//
// 这个Model的抽象是当前物体的距离
//
function Model() {
    var model = {
        distance: 0
    };
    this.addDistance = function (value) {
        model.distance += value;
        fireEvent(this, "updateDistance", value);
    }
}

//
// ViewModel中保存了物体的运动属性
//
function ViewModel(model) {
    this.model = model;
    var __status = "not started";
    this.setStatus = function (str) {
        __status = str;
        fireEvent(this, "updateStatus", str);
    }
    this.getStatus = function () {
        return __status;
    }
    addEvent(this.model, "updateDistance", this.update.bind(this));
}
ViewModel.prototype.go = function (value) {
    this.setStatus("moving");
    this.model.addDistance(value);
};
ViewModel.prototype.update = function (value) {
    fireEvent(this, "move",value);
};
ViewModel.prototype.done = function () {
    this.setStatus("done");
};