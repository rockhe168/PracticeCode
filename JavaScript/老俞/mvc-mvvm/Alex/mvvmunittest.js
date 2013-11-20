(function (win) {
    var SquareView = win.SquareView,
        Model = win.Model,
        Controller = win.Controller,
        DisplayView = win.DisplayView,
        ButtonView = win.ButtonView;
    
    var model = new Model();
    var viewModel = new ViewModel(model);
    var view = new SquareView(viewModel);
    var displayView = new DisplayView(viewModel);
    var btnView = new ButtonView(viewModel);
})(this);