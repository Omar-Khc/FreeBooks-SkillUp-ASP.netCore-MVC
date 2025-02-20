$(document).ready(function () {
    $('#tableRole').DataTable();
});



//function Delete(id) {
//    Swal.fire({
//        title: lbTitleMsgDelete,
//        text: lbTextMsgDelete,
//        icon: 'warning',
//        showCancelButton: true,
//        confirmButtonColor: '#3085d6',
//        cancelButtonColor: '#d33',
//        confirmButtonText: lbconfirmButtonText,
//        cancelButtonText: lbcancelButtonText
//    }).then((result) => {
//        if (result.isConfirmed) {
//            window.location.href = `/Admin/Accounts/DeleteUser?userId=${id}`;
//            Swal.fire(
//                lbTitleDeletedOk,
//                lbMsgDeletedOkRegister,
//                lbSuccess
//            )
//        }
//    })
//}

function DeleteUser(Id) {
    Swal.fire({
        title: "هل انت متأكد يا بني ؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "نعم , قم بالحذف"
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = `/Admin/Accounts/DeleteUser?Id=${Id}`
            Swal.fire({
                title: "تم الحذف !",
                icon: "success",
                timer: 1500
            });
        }
    });
}


Edit = (id, name, email, image, role, active) => {
    document.getElementById("title").innerHTML = "تعديل المستخدم";
    document.getElementById("btnSave").value = "تعديل";
    document.getElementById("userId").value = id;
    document.getElementById("userName").value = name;
    document.getElementById("userEmail").value = email;
    document.getElementById("ddluserRole").value = role;
    var Active = document.getElementById("userActive");
    if (active == "True")
        Active.checked = true;
    else
        Active.checked = false;

    $('#grPassword').hide();
    $('#grcomPassword').hide();

    document.getElementById("userPasswords").value = "$$$$$$";
    document.getElementById("userCompare").value = "$$$$$$";
    document.getElementById("image").hidden = false;
    document.getElementById("image").src = "/Images/Users/" + image;
    document.getElementById("imgeHide").value = image;

    
}

Rest = () => {
    document.getElementById("title").innerHTML = "اضافة مستخدم جديد";
    document.getElementById("btnSave").value = "حفظ";
    document.getElementById("userId").value = "";
    document.getElementById("userName").value = "";
    document.getElementById("userEmail").value = "";
    //document.getElementById("userImage").value = "";
    document.getElementById("ddluserRole").value = "";
    document.getElementById("userActive").checked = false;
    $('#grPassword').show();
    $('#grcomPassword').show();
    document.getElementById("userPasswords").value = "";
    document.getElementById("userCompare").value = "";
    document.getElementById("image").hidden = true;
    document.getElementById("imgeHide").value = "";


}
