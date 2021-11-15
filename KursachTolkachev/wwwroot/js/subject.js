$(function () {
    $('#editSubject').on('click', '.rowEditStart', function () {
        var id = parseInt($(this).find('.editId').html());
        document.location.href = '/Subject/Edit?id=' + id;
        //alert($(this).find('.editId').html());
    });
});

