function iniciarToastr() {
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
}

$(document).ready(function () {
    $('.excluir-tarefa').on('click', function () {
        var url = "/apagar-tarefa";
        var id = $(this).attr('data-id');
        $.get(url + '/' + id, function (data) {
            $('#modalDelete').html(data);
            $("#modalExcluirTarefa").modal('show');
        });
    });
});

