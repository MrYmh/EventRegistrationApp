$(function () {
    var l = abp.localization.getResource('EventRegistrationApp');

    var eventId = $('#Event_Id').val();

    $('#RegisterButton').click(function () {
        abp.ajax({
            url: '/api/app/registration/register?eventId=' + eventId,
            type: 'POST',
            success: function () {
                abp.notify.success(l('RegistrationSuccessful'));
            }
        });
    });

    $('#CancelRegistrationButton').click(function () {
        abp.ajax({
            url: '/api/app/registration/cancel?eventId=' + eventId,
            type: 'POST',
            success: function () {
                abp.notify.success(l('CancellationSuccessful'));
            }
        });
    });
});