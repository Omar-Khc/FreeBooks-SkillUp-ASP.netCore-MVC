$(document).ready(function () {
    $('#tableRole').DataTable();
});



function DeleteRole(id) {
    Swal.fire({
        title: "هل انت متأكد يا بني ؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "نعم , قم بالحذف"
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = `/Admin/Accounts/DeleteRole?Id=${id}`
            Swal.fire({
                title: "تم الحذف !",
                icon: "success",
                timer: 1500
            });
        }
    });
}

EditRole = (id, name) => {
    document.getElementById("title").innerHTML = "تعديل مجموعة المتستخدمين";
    document.getElementById("btnSave").value = "تعديل";
    document.getElementById("roleId").value = id;
    document.getElementById("roleName").value = name;
}

RestRole = () => {
    document.getElementById("title").innerHTML = "اضافة مجموعة جديدة";
    document.getElementById("btnSave").value = "حفظ";
    document.getElementById("roleId").value = "";
    document.getElementById("roleName").value = "";
}