$(document).ready(function () {
    const colors = ["pomegranate", "governor", "shamrock", "burgundy", "violet", "jaffa", "tainoi", "apple", "lavender", "dodger"];

    $("span.random-font-color").each(function () {  
        var text = Array.from($(this).text());
        var s = "";

        text.forEach(function (entry) {
            s += '<span class="' + getColor() + '">' + entry + '</span>';
        });

        $(this).html(s);
    });
    
    function getColor() {
        return colors[Math.floor(Math.random() * colors.length)];
    }
});