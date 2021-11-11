(function ($) {
    "use strict"

    $('#world-map').vectorMap({
        map: 'world_en',
        backgroundColor: '#a5bfdd',
        borderColor: '#818181',
        borderOpacity: 0.25,
        borderWidth: 1,
        color: '#f4f3f0',
        enableZoom: true,
        hoverColor: '#c9dfaf',
        hoverOpacity: null,
        normalizeFunction: 'linear',
        scaleColors: ['#b6d6ff', '#005ace'],
        selectedColor: '#c9dfaf',
        selectedRegions: null,
        showTooltip: true,
        onRegionClick: function (element, code, region) {
            var message = 'انتخاب شما :  "' +
                region +
                '" کد مورد انتخابی شما : ' +
                code.toUpperCase();

            alert(message);
        }
    });

    $('#usa').vectorMap({
        map: 'usa_en',
        backgroundColor: '#a5bfdd',
        borderColor: '#818181',
        borderOpacity: 0.25,
        borderWidth: 1,
        color: '#f4f3f0',
        enableZoom: true,
        hoverColor: '#c9dfaf',
        hoverOpacity: null,
        normalizeFunction: 'linear',
        scaleColors: ['#b6d6ff', '#005ace'],
        selectedColor: '#c9dfaf',
        selectedRegions: null,
        showTooltip: true,
        onRegionClick: function (element, code, region) {
            var message = 'انتخاب شما : "' +
                region +
                '" کد مورد انتخاب شما : ' +
                code.toUpperCase();

            alert(message);
        }
    });






})(jQuery);