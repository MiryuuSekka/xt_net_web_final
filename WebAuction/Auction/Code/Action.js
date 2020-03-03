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
