$(document).ready(function() {
    $("span.random-font-color").each(function (index) {
  
        var text = Array.from($(this).text());

        var s = "";
        text.forEach(function (entry) {
            s += '<span class="lavender">ccccc</span>';
        });

        console.log(s);

    });

});