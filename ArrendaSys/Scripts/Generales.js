

function GetUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}
function agregarImagen() {
    $("#inputImagen").trigger("click");
}
function agregarMultiplesArchivos() {
    $("#inputArchivosInmueble").trigger("click");

}
function fechaHoyMostrar(date) {

    var dd = date.getDate();
    var mm = date.getMonth() + 1;
    var yyyy = date.getFullYear();
    if (dd < 10) {
        dd = '0' + dd
    }
    if (mm < 10) {
        mm = '0' + mm
    }
    var fechaString = dd + '/' + mm + '/' + yyyy;
    return fechaString;

}
function FechaformatoInput(fecha) {
    var dd = fecha.getDate();
    var mm = fecha.getMonth() + 1;
    var yyyy = fecha.getFullYear();
    if (dd < 10) {
        dd = '0' + dd
    }
    if (mm < 10) {
        mm = '0' + mm
    }

    fechaString = yyyy + '-' + mm + '-' + dd;
    return fechaString;
}
function mostrarNombreImagen() {
    var tipo = parseInt($("#tipoCuenta").val());
    debugger;
    $("#NombreMultiplesArchivosArr").empty();
    $("#NombreMultiplesArchivosProp").empty();
    $("#NombreMultiplesArchivosInmo").empty();
    var archivosCuerpo = $("#inputImagen").get(0).files;
    for (f = 0; f < archivosCuerpo.length; f++) {
        if (tipo == 2) {
            $("#NombreMultiplesArchivosArr").append(archivosCuerpo[f].name + "<br/>")
        }
        if (tipo == 3) {
            $("#NombreMultiplesArchivosProp").append(archivosCuerpo[f].name + "<br/>")
        }
        if (tipo == 4) {
            $("#NombreMultiplesArchivosInmo").append(archivosCuerpo[f].name + "<br/>")
        }

    }
}
function MostrarNombreMultiplesArchivos() {
    $("#NombreMultiplesArchivos").empty();
    var archivosCuerpo = $("#inputArchivosInmueble").get(0).files;
    for (f = 0; f < archivosCuerpo.length; f++) {
        $("#NombreMultiplesArchivos").append(archivosCuerpo[f].name + "<br/>")
    }
}
function GuardarImagen(idCuenta) {
    var data = new FormData();
    data.append("Ruta", "Inmueble");
    data.append("Id" + "," + idCuenta, idCuenta);
    var archivos = $("#inputImagen").get(0).files;
    for (i = 0; i < archivos.length; i++) {
        data.append("Archivos", archivos[i]);
    }
    postGuardarImagen(data,idCuenta);
}
function postGuardarImagen(data,idCuenta) {
    $.ajax({
        type: "POST",
        url: "/Api/Cuenta/GuardarImagenCuenta",
        contentType: false,
        processData: false,
        data: data,
        async: false,
        success: function (response) {
        },
        error: function (jqxhr) {
            alert("rompiste algo bro")
            console.log(jqxhr)
        }
    })
}
function GuardarArchivo(idInmueble) {
    var data = new FormData();
    data.append("Ruta", "Inmueble");
    data.append("Id" + "," + idInmueble, idInmueble);
    var archivos = $("#inputArchivosInmueble").get(0).files;
    for (i = 0; i < archivos.length; i++) {
        data.append("Archivos", archivos[i]);
    }
    postGuardarArchivo(data);
}
function postGuardarArchivo(data) {
    $.ajax({
        type: "POST",
        url: "/Api/Inmueble/GuardarArchivosInmueble",
        contentType: false,
        processData: false,
        data: data,
        async:false,
        success: function (response) {
           
        },
        error: function (jqxhr) {
            alert("rompiste algo bro")
        }
    })

}


