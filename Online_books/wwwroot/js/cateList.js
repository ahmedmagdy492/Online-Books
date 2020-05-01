var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/Category",
            "type": "GET",
            "datatype": "json",
        },
        "columns": [
            { "data": "name", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Category/Edit?id=${data} class="btn btn-success text-white" style="cursor: pointer;width: 70px;">Edit</a>
                        <a href="/Category/Delete?id=${data}" class="btn btn-danger text-white" style="cursor: pointer;width: 70px;">Delete</a>
                    </div>`;
                },
                "width": "40%"
            }            
        ],
        "langauge": {
            "emptyTable": "no data found",

        },
        "width": "100%"
    });
}