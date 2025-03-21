$(function () {
    var l = abp.localization.getResource('EventRegistrationApp');

    // Initialize modals
    var createModal = new abp.ModalManager(abp.appPath + 'Events/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Events/EditModal');

    // Initialize DataTable
    var dataTable = $('#EventsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(eventRegistrationApp.services.event.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items: [
                            {
                                text: l('Details'),
                                action: function (data) {
                                    // Redirect to the Details page
                                    window.location.href = abp.appPath + 'Events/Details/' + data.record.id;
                                }
                            },
                            {
                                text: l('Edit'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                confirmMessage: function (data) {
                                    return l('EventDeletionConfirmationMessage', data.record.nameEn);
                                },
                                action: function (data) {
                                    eventRegistrationApp.services.event
                                        .delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                    }
                },
                {
                    title: l('NameEn'),
                    data: "nameEn"
                },
                {
                    title: l('NameAr'),
                    data: "nameAr"
                },
                {
                    title: l('Capacity'),
                    data: "capacity"
                },
                {
                    title: l('IsOnline'),
                    data: "isOnline",
                    render: function (data) {
                        return data ? l('Yes') : l('No');
                    }
                },
                {
                    title: l('StartDate'),
                    data: "startDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                },
                {
                    title: l('EndDate'),
                    data: "endDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                },
                {
                    title: l('Location'),
                    data: "location"
                },
                {
                    title: l('IsActive'),
                    data: "isActive",
                    render: function (data) {
                        return data ? l('Yes') : l('No');
                    }
                }
            ]
        })
    );

    // Reload DataTable when modals are closed
    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    // Open CreateModal when the "New Event" button is clicked
    $('#NewEventButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
