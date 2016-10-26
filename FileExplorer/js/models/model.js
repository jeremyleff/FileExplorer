var ViewModel = function () {
    var self = this;

    this.services           = ko.observableArray();
    this.years              = ko.observableArray();
    this.dates              = ko.observableArray();
    this.files              = ko.observableArray();
    this.selectedService    = ko.observable();
    this.selectedYear       = ko.observable();
    this.selectedDate       = ko.observable();

    this.selectedService.subscribe(function (path) {
        $.getJSON("/api/Folder/" + path.name, function (data) {
            self.years(data);
        })
    });

    this.selectedYear.subscribe(function (path) {
        $.getJSON("/api/Folder/" + self.selectedService().name + "%252F" + path.name, function (data) {
            self.dates(data);
        })
    });

    this.selectedDate.subscribe(function (path) {
        $.getJSON("/api/File/" + self.selectedService().name + "%252F" + self.selectedYear().name + "%252F" + path.name, function (data) {
            self.files(data);
            init();
        })
    });

    $.getJSON("/api/Folder", function (data) {
        self.services(data);
    })
};

ko.applyBindings(new ViewModel());

