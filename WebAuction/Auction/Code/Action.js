$('.RoleOption').button('toggle');

function ChangeUserRole(userId, NewRole) {
    console.log(userId);
    console.log(NewRole);
    location.href = '/Pages/User/Edit.cshtml?id=' + userId + '&role=' + NewRole;
}

function DeleteUser(userId) {
    console.log(userId);
    location.href = '/Pages/User/Edit.cshtml?id=' + userId+'&d=y';
}

$('#exampleModal').on('show.bs.modal', function (event) {
    var modal = $(this)
    modal.find('.modal-title').text('Add new Lot')
    modal.find('.modal-body input').val();
})

function DeleteLot(id) {
    $.post(
        "/Pages/Lot/DeleteLot.cshtml",
        {
            id: id
        },
        onAjaxSuccess
    );

    function onAjaxSuccess() {
        location.reload(); 
    }
}


