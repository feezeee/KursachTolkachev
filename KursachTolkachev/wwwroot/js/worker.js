if (User.IsInRole("Администратор") || User.IsInRole("Директор")) {
    $(function () {
        $('#editWorker').on('click', '.rowEditStart', function () {
            var id = parseInt($(this).find('.editId').html());
            document.location.href = '/Worker/Edit?id=' + id;
            //alert($(this).find('.editId').html());
        });
    });
}
