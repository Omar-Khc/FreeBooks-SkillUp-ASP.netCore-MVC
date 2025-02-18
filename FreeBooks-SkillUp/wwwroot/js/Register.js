$(document).ready(function () {
    $('#tableRole').DataTable();
});



function DeleteUser(id) {
    Swal.fire({
        title: "هل انت متأكد يا بني ؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "نعم , قم بالحذف"
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = `/Admin/Accounts/DeleteUser?Id=${id}`
            Swal.fire({
                title: "تم الحذف !",
                icon: "success",
                timer: 1500
            });
        }
    });
}


EditUser = (id, name, email, imageUser, role, activeUser) => {
    document.getElementById("title").innerHTML = "تعديل مجموعة المستخدمين";
    document.getElementById("btnSave").value = "تعديل";
    document.getElementById("userId").value = id;
    document.getElementById("userName").value = name;
    document.getElementById("userEmail").value = email;
    document.getElementById("userImage").value = "";
    document.getElementById("addUserRole").value = role;

    document.getElementById("passwordFields").style.display = "none";
    document.getElementById("confirmPasswordFields").style.display = "none";

    var modal = new bootstrap.Modal(document.getElementById('exampleModal'));
    modal.show();
}

RestRole = () => {
    document.getElementById("title").innerHTML = "اضافة مجموعة جديدة";
    document.getElementById("btnSave").value = "حفظ";
    document.getElementById("userId").value = "";
    document.getElementById("userName").value = "";
    document.getElementById("userEmail").value = "";
    document.getElementById("userImage").value = "";
    document.getElementById("addUserRole").value = "";
    document.getElementById("activeUser").checked = false;
    document.getElementById("imagePreview").style.display = "none";

    document.getElementById("passwordFields").style.display = "block";
    document.getElementById("confirmPasswordFields").style.display = "block";
}
