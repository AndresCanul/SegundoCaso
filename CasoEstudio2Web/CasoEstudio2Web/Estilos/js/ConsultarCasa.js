function ConsultarPrecio() {

    let IdCasa = $("#IdCasa").val();

    if (IdCasa > 0) {
        $.ajax({
            url: '/Casas/ConsultarCasa?IdCasa=' + IdCasa,
            method: "GET",
            datatype: "json",

            success: function (response) {
                $("#PrecioCasa").val(response.PrecioCasa);
            },
            error: function (response) {

            }
        })
    }

    else {
        $("#PrecioCasa").val(0);
    }
}