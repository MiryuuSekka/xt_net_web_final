$('#option1').click(function myfunction() {
    //var checkBoxes = document.getElementsByClassName("AwardCheckbox");
    //var checkedData;
    //for (var i = 0; i < checkBoxes.length; i++) {
    //    checkedData[i] = $(".AwardCheckbox#" + i).is(":checked");
    //}

    //location.href = '/Pages/User/Edit.cshtml?id='+;
});

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
    var button = $(event.relatedTarget) // Button that triggered the modal
    var recipient = button.data('whatever') // Extract info from data-* attributes
    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    var modal = $(this)
    modal.find('.modal-title').text('New message to ' + recipient)
    modal.find('.modal-body input').val(recipient)
})