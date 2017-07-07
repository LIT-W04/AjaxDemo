//foo@bar.com
//hello@world.com

$(function () {
    $("#add-number").on('click', function () {
        var minNumber = $("#min").val();
        var maxNumber = $("#max").val();
        var params = {
            min: minNumber,
            max: maxNumber
        };
        $.get('/home/getnumber', params, function (result) {
            $("#numbers").append(`<li>${result.Age}</li>`);
        });
        
    });

    $("#get-with-cars").on('click', function() {
        $.get('/home/otherJsonDemo', function (person) {
            console.log(person.firstName + " " + person.lastName);
            //person.Cars.forEach(function(car) {
            //    console.log(car.Make);
            //});
        });
    });
});