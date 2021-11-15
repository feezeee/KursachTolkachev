
$(function () {
    $('#editQualification').on('click', '.rowEditStart', function () {
        var id = parseInt($(this).find('.editId').html());
        document.location.href = '/Qualification/Edit?id=' + id;
        //alert($(this).find('.editId').html());
    });
});
