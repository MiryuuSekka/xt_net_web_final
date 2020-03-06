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
    //var recipient = button.data('whatever') // Extract info from data-* attributes

    var modal = $(this)
    modal.find('.modal-title').text('Add new Lot')
    modal.find('.modal-body input').val();
    //modal.find('.modal-body input').val(recipient)
})

function AddLot(Title, Company, Status, DateStart, DateEnd, Price, img1, img2, img3) {
    var url = "";
    var lot = {
        Title: Title,
        Company: Company,
        Status: Status,
        DateStart: DateStart,
        DateEnd: DateEnd,
        Price: Price,
        img1: img1,
        img2: img2,
        img3: img3
    }
    $.ajax({
        url: url,
        type: "POST",
        success: function (result) {
            console.log(result)
        },
        error: function (result) {
            console.log(result)
        }
    })
}

/*
$('#exampleModal').on('hidden.bs.modal', function (e) {
    //parent.postMessage($("#mainContent").height() + 1, "*");

});



function ChangeUserRole(step) {
    modal.find('.modal-body input').val(step++);
    alert("CCC");
}

$("#myModal").on("hide.bs.modal", function () {
    alert("BBB");
});
*/