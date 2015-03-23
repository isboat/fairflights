'use strict';

var UIHelper = function () {

    this.IsLoading = false;

    this.ShowBusy = function (ele) {

        var $el = ele || 'body';

        $($el).prepend('<div class="loading"></div>');
        $('.loading').css({
            width: $($el).css('width'),
            height: $($el).css('height')
        });
        this.IsLoading = true;
    };

    this.HideBusy = function () {
        $('.loading').remove();
    };
};


var uiHelper = new UIHelper();