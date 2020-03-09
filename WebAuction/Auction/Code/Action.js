$('.RoleOption').button('toggle');

function ChangeUserRole(userId, NewRole) {
    console.log(userId);
    console.log(NewRole);
    location.href = '/Pages/User/Edit.cshtml?id=' + userId + '&role=' + NewRole;
}



$('#exampleModal').on('show.bs.modal', function (event) {
    var modal = $(this)
    modal.find('.modal-title').text('Add new Lot')
    modal.find('.modal-body input').val();
})

$('#EditTitleModal').on('show.bs.modal', function (event) {
    var modal = $(this)
    modal.find('.modal-title').text('Edit lot.Title')
    modal.find('.modal-body input').val();
})
$('#EditPhotoModal').on('show.bs.modal', function (event) {
    var modal = $(this)
    modal.find('.modal-title').text('Edit lot.Photo')
    modal.find('.modal-body input').val();
})
$('#EditTagModal').on('show.bs.modal', function (event) {
    var modal = $(this)
    modal.find('.modal-title').text('Edit lot.Tag')
    modal.find('.modal-body input').val();
})
$('#EditDateModal').on('show.bs.modal', function (event) {
    var modal = $(this)
    modal.find('.modal-title').text('Edit lot.Date')
    modal.find('.modal-body input').val();
})
$('#EditPriceModal').on('show.bs.modal', function (event) {
    var modal = $(this)
    modal.find('.modal-title').text('Edit lot.Price')
    modal.find('.modal-body input').val();
})
$('#EditStatusModal').on('show.bs.modal', function (event) {
    var modal = $(this)
    modal.find('.modal-title').text('Edit lot.Status')
    modal.find('.modal-body input').val();
})

function onAjaxSuccess() {
    location.reload();
}

function DeleteLot(id) {
    $.post(
        "/Pages/Lot/Logic/Delete.cshtml",
        {
            id: id
        },
        onAjaxSuccess
    );
}

function DeleteBet(id) {
    $.post(
        "/Pages/Bet/Delete.cshtml",
        {
            id: id
        },
        onAjaxSuccess
    );
}

function DeleteImage(id) {
    $.post(
        "/Pages/Photo/Delete.cshtml",
        {
            id: id
        },
        onAjaxSuccess
    );
}

function DeleteUser(userId) {
    $.post(
        "/Pages/User/Edit.cshtml",
        {
            id: userId,
            d: "y"
        },
        onAjaxSuccess
    );
}

function Pay(id) {
    alert("can't");
}

function ViewUserLots(UserId) {
    $.post(
        "/Pages/Index.cshtml",
        {
            id: UserId
        },
    );
}

