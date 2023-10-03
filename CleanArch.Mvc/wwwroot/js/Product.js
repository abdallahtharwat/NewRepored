﻿var dataTable

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/product/getall' }, // API URL should retrieve all data

        "columns": [
            { data: 'title', "width": "10%" },
            { data: 'brand', "width": "10%" },
            { data: 'color', "width": "5%" },
            { data: 'code', "width": "10%" },
            { data: 'price', "width": "10%" },
            { data: 'category.name', "width": "10%" },
            { data: 'type.name', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/product/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>
                  <a onClick=Delete('/product/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
                    </div>`
                },
                "width": "30%"
            }
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
                url: url, // url that we will receive in the parameter  in line (36)
                type: 'DELETE',  // http delete
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}