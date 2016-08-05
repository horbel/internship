/// <reference path="Scripts/knockout-3.4.0.js" />
function calc() {
    var self = this;
    self.Number1 = ko.observable("1");
    self.Number2 = ko.observable("2");
    self.result = ko.observable("");

    self.Operations = ['+', '-', '*', '/'];
    self.SelectedOperation=ko.observable('');

    function GetRequestUrl() {
        var url = 'http://127.0.0.1:3000/';
        var reqString = 'action=' + self.SelectedOperation() + '&number1=' + self.Number1() + '&number2=' + self.Number2();
        return url + reqString;
    }
    self.getResultFromServer = function () {
        $.ajax({
            url: GetRequestUrl(),
            cache: false,
            type: 'GET',
            contentType: 'text/plain; charset=utf-8',
            success: function (data) {
                self.result(data); //Put the response in result input
               
            }
        });
    }
    
};

var calcViewModel = new calc();
ko.applyBindings(calcViewModel);
