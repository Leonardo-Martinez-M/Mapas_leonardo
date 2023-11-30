using MashUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MashUp
{
    public partial class index : System.Web.UI.Page
    {
        HelperPuebla Helper;
        HelperPuebla otroHelper;
        Helper NuevoHelper;
        HelperGasolina helperGaso;
        HelperDivisas helperDivisa;

        public index()
        {
            Helper = new HelperPuebla();
            NuevoHelper = new Helper();
            otroHelper = new HelperPuebla();
            helperGaso = new HelperGasolina();
            helperDivisa = new HelperDivisas();
        }

        protected async void Page_Load(object sender, EventArgs e)
        {

            //Todos los métodos para obtener información del Clima de PUEBLA

            await Helper.ObtenerDatosPuebla("18.833333", "-98.0");


            Label2.Text = Helper.ObtenerNombre();
            LabelTempActual.Text = Helper.ObtenerTemperatura();
            LabelTempMaxima.Text = Helper.ObtenerTemperaturaMaxima();
            LabelTempMinima.Text = Helper.ObtenerTemperaturaMinima();
            ImagenDescriptiva.Attributes.Add("src", Helper.ObtenerImagen());
            Nubosidad.Text = Helper.ObtenerNubosidad();
            Humedad.Text = Helper.ObtenerHumedad();
            Label4.Text = Helper.ObtenerDescripcion();
            HoraSalida.Text = Helper.ObtenerHoraSalidaSol();
            HoraPuesta.Text = Helper.ObtenerHoraPuestaSol();


            if (!IsPostBack)
            {
                await helperDivisa.ObtenerDivisa();
                ObtenerMoneda();
                NuevoHelper.ciudad = "Puebla";
                NuevoHelper.pais = "mx";
                await NuevoHelper.ObtenerData();
                labelError.Text = "";
                await otroHelper.ObtenerDatosPuebla(NuevoHelper.obtenerLatitud(), NuevoHelper.obtenerLongitud());

                nombre.Text = otroHelper.ObtenerNombre();
                temp.Text = otroHelper.ObtenerTemperatura();
                tempMin.Text = otroHelper.ObtenerTemperaturaMinima();
                tempMax.Text = otroHelper.ObtenerTemperaturaMaxima();
                nubo.Text = otroHelper.ObtenerNubosidad();
                hume.Text = otroHelper.ObtenerHumedad();
                Image1.Attributes.Add("src", otroHelper.ObtenerImagen());
                descripcion.Text = otroHelper.ObtenerDescripcion();
                horaSa.Text = otroHelper.ObtenerHoraSalidaSol();
                horaPu.Text = otroHelper.ObtenerHoraPuestaSol();
            }


        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            helperGaso.ciudad = labelCiudad.Text;


            if (labelCiudad.Text == "" || labelPais.Text == "")
            {
                labelError.Text = "Ha ocurrido un error";
            }
            else
            {
                NuevoHelper.ciudad = labelCiudad.Text;
                NuevoHelper.pais = labelPais.Text;
                await NuevoHelper.ObtenerData();


                await otroHelper.ObtenerDatosPuebla(NuevoHelper.obtenerLatitud(), NuevoHelper.obtenerLongitud());
                if (NuevoHelper.obtenerLatitud() == null || NuevoHelper.obtenerLongitud() == null)
                {
                    labelError.Text = NuevoHelper.Error;

                }
                else
                {
                    labelError.Text = "";

                    nombre.Text = otroHelper.ObtenerNombre();
                    temp.Text = otroHelper.ObtenerTemperatura();
                    tempMin.Text = otroHelper.ObtenerTemperaturaMinima();
                    tempMax.Text = otroHelper.ObtenerTemperaturaMaxima();
                    nubo.Text = otroHelper.ObtenerNubosidad();
                    hume.Text = otroHelper.ObtenerHumedad();

                    Image1.Attributes.Add("src", otroHelper.ObtenerImagen());
                    descripcion.Text = otroHelper.ObtenerDescripcion();
                    horaSa.Text = otroHelper.ObtenerHoraSalidaSol();
                    horaPu.Text = otroHelper.ObtenerHoraPuestaSol();

                    // Creamos una variable la cual va a almacenar latitud utilizando el método obtenerLatitud de la clase NuevoHelper
                    var latitud = NuevoHelper.obtenerLatitud();

                    // Creamos una variable la cual va a almacenar longitud utilizando el método obtenerLongitud de la clase NuevoHelper
                    var longitud = NuevoHelper.obtenerLongitud();

                    // Clave de API para acceder a los servicios de OpenWeatherMap
                    var apiKey = "18fc322912e7118123f17e7e7e2c9b9c";

                    // Construir la URL para el mapa de ubicación utilizando Google Maps
                    MapaUbicacion.Src = "https://maps.google.com/?ll=" + latitud + "," + longitud + "&z=8&t=m&output=embed";

                    // Construir la URL para el mapa climatológico utilizando OpenWeatherMap
                    MapaClimatologico.Src = "https://openweathermap.org/weathermap?basemap=map&cities=false" + "&layer=temperature&lat=" + latitud + "&lon=" + longitud + "&appid=" + apiKey + "&zoom=10";

                }

            }
            gasolina.Attributes.Add("src", $"https://petrointelligence.com/api/api_precios.html?consulta=estado&estado={helperGaso.ObtenerAbreviatura()}");
            

        }
        protected void ObtenerMoneda()
        {
            List<string> monedas = new List<string> {
                "ARS", "AUD", "BCH", "USD", "BGN", "BNB", "BRL", "BTC", "CAD", "CHF", "CNY",
            "CZK", "DKK", "DOGE", "DZD", "ETH", "EUR", "GBP", "HKD", "HRK", "HUF",
            "IDR", "ILS", "INR", "ISK", "JPY", "KRW", "LTC", "MAD", "MXN", "MYR",
            "NOK", "NZD", "PHP", "PLN", "RON", "RUB", "SEK", "SGD", "THB", "TRY",
            "TWD", "XRP", "ZAR"
            };

            foreach (string moneda in monedas)
            {
                DropDownList1.Items.Add(new ListItem(moneda));
                DropDownList2.Items.Add(new ListItem(moneda));

            }
        }

        protected async void Button2_Click(object sender, EventArgs e)
        {

            helperDivisa.monedaNativa = DropDownList1.SelectedValue.ToString();
            helperDivisa.monedaObjetivo = DropDownList2.SelectedValue.ToString();

            helperDivisa.monto = montoDeseado.Text;
            await helperDivisa.ObtenerDivisa();
            resultadoConversion.Text = helperDivisa.ObtenerMonto();

            

        }
    }
}