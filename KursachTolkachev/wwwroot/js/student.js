﻿$(function () {
    $('#editStudent').on('click', '.rowEditStart', function () {
        var id = parseInt($(this).find('.editId').html());
        document.location.href = '/Student/Edit?id=' + id;
        //alert($(this).find('.editId').html());
    });
});