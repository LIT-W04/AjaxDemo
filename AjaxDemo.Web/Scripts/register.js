$(function() {
    $("#email").on('keyup', function() {
        $.get('/home/isvalidemail', { email: $(this).val() }, function(result) {
            $("#register").prop('disabled', !result.IsValid);
        });
    });
});