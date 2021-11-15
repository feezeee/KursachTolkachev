// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
if (User.IsInRole("Администратор") || User.IsInRole("Директор")) {
    $(function () {
        $('#editQualification').on('click', '.rowEditStart', function () {
            var id = parseInt($(this).find('.editId').html());
            document.location.href = '/Qualification/Edit?id=' + id;
            //alert($(this).find('.editId').html());
        });
    });
}
if (User.IsInRole("Администратор") || User.IsInRole("Директор")) {
    $(function () {
        $('#editSubject').on('click', '.rowEditStart', function () {
            var id = parseInt($(this).find('.editId').html());
            document.location.href = '/Subject/Edit?id=' + id;
            //alert($(this).find('.editId').html());
        });
    });
}