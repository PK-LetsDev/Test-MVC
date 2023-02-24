var dataTable;
$(document).ready(function () {
    loadDataTable();
})
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Company/GetAll"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "streetAddress", "width": "15%" },
            { "data": "city", "width": "15%" },
            { "data": "state", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                         <div class="w-75 btn-group" role="group">
                        <a href="/Admin/Company/Upsert?id=${data}" class="btn btn-primary"><i class="bi bi-pencil-fill"></i>&nbsp;Edit</a>
                        <a onClick=Delete('/Admin/Company/Delete/${data}')
                        <a asp-controller="Category" asp-action="Delete" asp-route-id="@obj.Id" class="btn btn-secondary"><i class="bi bi-trash-fill"></i>&nbsp;Delete</a>
                    </div>
                        `
                },
                "width": "15%"
            },
        ]
    });
}
function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.massage);
                    }
                    else {
                        toastr.error(data.massage);
                    }
                }
            })
        }
    })
}