function Print() {
    $(".hideWhenPrint").hide();
    window.print();
    $(".hideWhenPrint").show();
}

function SaveLultureLS() {
    window.blazorCulture = {
        get: () => window.localStorage['BlazorCulture'],
        set: (value) => window.localStorage['BlazorCulture'] = value
    };
}