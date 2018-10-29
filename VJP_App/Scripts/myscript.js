$(document).ready(function () {

    $("input:radio").change(function () {
        var id = this.name;
        var rating = this.value;

        // alert(n + v +p +c);
        $.ajax({
            url: '/Judge/RateProject',
            type: "GET",
            data: { ProjectId: id, Ratings:rating  },
            dataType: "json",
            traditional: true
        });
    });

    var checkedVals = $('.theClass:checkbox:checked').map(function () {
        return this.value;
    }).get();
    //alert(checkedVals.join(","));

})