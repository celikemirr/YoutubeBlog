
$(document).ready(function () {


    $('#categoriesTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
        ],
        language: {
            "sDecimal": ",",
            "sEmptyTable": "No data is available in the table",
            "sInfo": "Showing records from _START_ to _END_ from _TOTAL_ registration",
            "sInfoEmpty": "No registration",
            "sInfoFiltered": "(_MAX_ found in the registration)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Sayfada _MENU_ show registration",
            "sLoadingRecords": "Loading...",
            "sProcessing": "Processing...",
            "sSearch": "Search:",
            "sZeroRecords": "No matching registration found",
            "oPaginate": {
                "sFirst": "First",
                "sLast": "Last",
                "sNext": "Next one",
                "sPrevious": "Previous"
            },
            "oAria": {
                "sSortAscending": ": Activate ascending column sort",
                "sSortDescending": ": Capitalize descending column sort"
            },
            "select": {
                "rows": {
                    "_": "%d Registration selected",
                    "0": "hi",
                    "1": "1 registration selected"
                }
            }
        }
    });
});
articleIndex.js
articleIndex.js Displaying.