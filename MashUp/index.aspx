﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MashUp.index" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <!-- Referencia a Bootstrap hoja de estilos-->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <!-- Referencia a Bootstrap a JScript -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <!-- Referencia de JScript para el manejo de Youtube -->
    <script src="JScript/PlayerYoutube.js"></script>
    <!-- Referencia de estilos propios -->
    <link href="estilos/styles.css" rel="stylesheet" />
    <!-- Título de la página -->
    <title>MashUp Híbrida</title>
</head>

<body onload="onYoutubeFrameApiReady()">


    <header>
                <!-- Barra de navegación -->
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">MashUp Híbrida</a>
                <button class="navbar-toggler bg-light" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse text-center" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link" href="#costosGasolina">Costos Gasolina</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#convertirMonedas">Convertidor Monedas</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#videoAleatorio">Video aleatorio</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    </header>

    <div class="container text-center">
        <!-- Creamos el elemento ASP -->
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

        <!-- Creamos la clase card para mostrar los datos de la ciudad de Puebla -->
        <div class="container mt-3 mb-3">
            <!-- Presentador de imagenes de ciudad de Puebla -->
            <div class="card">
                <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
                    <div class="carousel-inner">

                        <!-- Primera imagen -->
                        <div class="carousel-item active">
                            <img src="https://blogapi.uber.com/wp-content/uploads/2019/08/9-actividades-en-Puebla-para-descubrir-todo-el-encanto-de-la-ciudad-1024x512.png" class="d-block w-100" alt="img_uno" />
                        </div>
                        <!-- Segunda imagen  -->
                        <div class="carousel-item">
                            <img src="https://img.travesiasdigital.com/2019/04/visitar-puebla.jpg" class="d-block w-100" alt="img_dos" />
                        </div>
                        <!-- Tercera imagen -->
                        <div class="carousel-item">
                            <img src="https://content.r9cdn.net/rimg/dimg/5b/6d/745672d2-city-17433-1682a0c64be.jpg?width=1366&height=768&xhint=2100&yhint=2160&crop=true" class="d-block w-100" alt="img_tres" />
                        </div>
                    </div>

                    <!-- Botones de ontrol de carrusel -->
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>
                <div class="card-body">
                    <h2>Puebla</h2>
                    <!-- Descripcion de Puebla -->
                    <p class="card-text">Ubicada en un valle cerca de cuatro volcanes, Puebla está a 2,160 metros sobre el nivel del mar en el centro oriente del territorio mexicano. Colinda al este con el estado de Veracruz, al poniente con los estados de Hidalgo, México, Tlaxcala y Morelos y al sur con los estados de Oaxaca y Guerrero. </p>
                    <!-- Botones para mostrar datos climatologicos  -->
                    <button class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#modalDatosClimatologicos">Ver datos climatológicos</button>
                </div>
                <!-- Modal para mostar los datos climatologicos -->
                <div class="modal fade" id="modalDatosClimatologicos" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel">Datos Climatológicos</h5>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <!-- Creamos un elemento ASP de la ciudad de Puebla -->
                                <asp:Label ID="Label2" runat="server" Text="title" CssClass="title"></asp:Label>
                                <!-- Motrar detalles climatologicos de 2 columnas   -->
                                <div class="row">
                                    <!-- Columna izquierda -->
                                    <div class="col-md-6">
                                        <p>
                                            Temperatura actual:
                                        <asp:Label ID="LabelTempActual" runat="server" CssClass="title"></asp:Label>
                                        </p>
                                        <p>
                                            Temperatura máxima:
                                        <asp:Label ID="LabelTempMaxima" runat="server" CssClass="title"></asp:Label>
                                        </p>
                                        <p>
                                            Temperatura mínima:
                                        <asp:Label ID="LabelTempMinima" runat="server" CssClass="title"></asp:Label>
                                        </p>
                                        <!-- Imagen descriptiva  -->
                                        <asp:Image ID="ImagenDescriptiva" src="" runat="server" />
                                        
                                        <asp:Label ID="Label4" runat="server" Text="title" CssClass=""> °</asp:Label>
                                    </div>
                                    <!-- Columna derecha -->
                                    <div class="col-md-6">
                                        <p>
                                            Nubosidad:
                                        <asp:Label ID="Nubosidad" runat="server" CssClass="title"></asp:Label>
                                        </p>
                                        <p>
                                            Humedad:
                                        <asp:Label ID="Humedad" runat="server" CssClass="title"></asp:Label>
                                        </p>
                                        <p>
                                            Descripción:
                                        <asp:Label ID="descripcion" runat="server" CssClass="title"></asp:Label>
                                        </p>
                                        <p>
                                            Hora de salida del sol:
                                        <asp:Label ID="HoraSalida" runat="server" CssClass="title"></asp:Label>
                                        </p>
                                        <p>
                                            Hora de puesta del sol:
                                        <asp:Label ID="HoraPuesta" runat="server" CssClass="title"></asp:Label>
                                        </p>
                                    </div>
                                </div>
                            </div>


                            <div class="modal-footer text-center">
                                <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cerrar</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Visualizar costos de gasolina  -->
    <form runat="server" class="text-center">
        <div id="costosGasolina" class="container text-center">
            <!-- Titulo  -->
            <h1>Visualizar costos de gasolina</h1>
            <div class="mb-3">
                <!-- Campo de entrada para ciudad  -->
                <label for="labelCiudad" class="form-label">Ciudad:</label>
                <asp:TextBox ID="labelCiudad" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <!-- Campo de entrada para pais  -->
                <label for="labelPais" class="form-label">País:</label>
                <asp:TextBox ID="labelPais" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
                <!-- Boton de consulta  -->
            <asp:Button ID="Button1" runat="server" Text="Consultar" CssClass="btn btn-success" OnClick="Button1_Click" />
                <!-- Etiqueta para errores  -->
            <asp:Label ID="labelError" runat="server" CssClass="title text-danger mt-2 d-block"></asp:Label>
        </div>

        <div class="table-responsive container mt-3">
            <table class="table table-bordered table-striped table-hover table-success">
                <tr>
                    <th>Nombre:</th>
                    <td>
                        <asp:Label ID="nombre" runat="server" CssClass="title"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>Temperatura actual:</th>
                    <td>
                        <asp:Label ID="temp" runat="server" CssClass="title"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>Temperatura máxima:</th>
                    <td>
                        <asp:Label ID="tempMax" runat="server" CssClass="title"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>Temperatura mínima:</th>
                    <td>
                        <asp:Label ID="tempMin" runat="server" CssClass="title"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>Imagen:</th>
                    <td>
                        <asp:Image ID="Image1" src="" alt="imagen-descriptiva" runat="server" CssClass="img-fluid" />
                    </td>
                </tr>
                <tr>
                    <th>Nubosidad:</th>
                    <td>
                        <asp:Label ID="nubo" runat="server" CssClass="title"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>Humedad:</th>
                    <td>
                        <asp:Label ID="hume" runat="server" CssClass="title"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>Hora de salida del sol:</th>
                    <td>
                        <asp:Label ID="horaSa" runat="server" CssClass="title"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>Hora de puesta del sol:</th>
                    <td>
                        <asp:Label ID="horaPu" runat="server" CssClass="title"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

        <!-- Covertidor de monedas  -->
        <div class="modal fade" id="modalConvertirMonedas" tabindex="-1" aria-labelledby="convertidor" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="convertidor">Convertidor de Monedas</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <h1 class="h4">Ingresar monto:</h1>
                        <div class="mb-3">
                            <!-- Campo de entradad para el monto deseado  -->
                            <asp:TextBox ID="montoDeseado" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <!-- Seleccion de moneda de origen  -->
                            <label for="DropDownList1" class="form-label">Seleccionar moneda de origen:</label>
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>
                        <div class="mb-3">
                            <!-- eleccccion de moneda de destino   -->
                            <label for="DropDownList2" class="form-label">Seleccionar moneda de destino:</label>
                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>
                        <!-- Boto parar realizar la conversion  -->
                        <asp:Button ID="Button2" runat="server" Text="Convertir" CssClass="btn btn-success" OnClick="Button2_Click" />
                        <!-- Etiqueta para mostrar el resultado -->
                        <asp:Label ID="resultadoConversion" runat="server" Text="" CssClass="mt-2 d-block"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <div class="container text-center mt-4" id="convertirMonedas">
        <!-- Modal parar abrir el modal del convertidor de monedas -->
        <button class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#modalConvertirMonedas">Convertidor de Monedas</button>
    </div>
                            
    <!-- Contenedor de multimedia -->
    <div id="videoAleatorio" class="container text-center mt-4">
        <div id="player"></div>
    </div>

    <div class="container text-center mt-3">
        <div class="embed-responsive embed-responsive-16by9">
                                    
            <!-- Mapa precios de gasolina -->
            <iframe class="embed-responsive-item" runat="server" id="gasolina"></iframe>
        </div>
        <div class="embed-responsive embed-responsive-16by9">

            <!-- Mapa de ubicacion -->
            <iframe id="MapaUbicacion" runat="server" width="350" height="350" frameborder="0"></iframe>
            <br />
            <br />
        </div>
        <div class="embed-responsive embed-responsive-16by9">
                                    
            <!-- Mapa climatologico -->
            <iframe id="MapaClimatologico" runat="server" width="600" height="350" frameborder="0"></iframe>
            <br />
            <br />
        </div>
    </div>
        <footer class="bg-dark text-white mt-5">
        <div class="container py-3">
            <div class="row">
                <div class="col-md-6">
                    <p>&copy; 2023 MashuUp. Todos los derechos reservados.</p>
                </div>
                <div class="col-md-6 text-md-right">
                    <p>Desarrollado por: Equipo MashUp ®</p>
                </div>
            </div>
        </div>
    </footer>
</body>
</html>
