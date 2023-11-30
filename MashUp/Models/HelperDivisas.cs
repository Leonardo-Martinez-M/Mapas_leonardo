using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MashUp.Models
{
    public class HelperDivisas
    {
        //Accedemos a la clase Datadivisas
        DataDivisas data;

        //Manejador de mensajes
        HttpMessageHandler HandlerDatos;


        //Creamos la dirección base:
        string DirBase;

        string Error;
        public string monedaNativa { get; set; }
        public string monedaObjetivo { get; set; }

        public string monedasTotales { get; set; }
        public string monto { get; set; }

        //Método constructor
        public HelperDivisas()
        {
            HandlerDatos = new HttpClientHandler();
        }


        public async Task ObtenerDivisa()
        {
            // Nuestro EndPoint https://exchange-rates.abstractapi.com/v1/convert/?api_key=d5facf2d7b944c85a560c6d623b56597&base=USD&target=MXN&base_amount=1

            //Definimos nuestra Dirección Base
            DirBase = "https://exchange-rates.abstractapi.com";

            //Y nuestro URI
            try
            {
                string solicitudCliente = $"/v1/convert/?api_key=d5facf2d7b944c85a560c6d623b56597&base={monedaNativa}&target={monedaObjetivo}&base_amount={monto}";
                try
                {
                    //Se crea la instancia HttpCliente, el objeto se destruye al 
                    // terminar la ejecución delk bloque using 
                    using (var Cliente = new HttpClient(HandlerDatos))
                    {
                        //configuramos la cabecera de la solicitud del servicio web
                        Cliente.BaseAddress = new Uri(DirBase);
                        Cliente.DefaultRequestHeaders.Accept.Clear();
                        Cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/Json"));
                        Cliente.DefaultRequestHeaders.Add("X-API-Key", "d5facf2d7b944c85a560c6d623b56597");

                        //se hace la solicitud del servicio web, y se verifica que la solicitud sea exitosa
                        HttpResponseMessage respuesta = await Cliente.GetAsync($"{solicitudCliente}");
                        respuesta.EnsureSuccessStatusCode();
                        //I$SuccessStatusCode= True, para una respuesta válida
                        if (respuesta.IsSuccessStatusCode)
                        {
                            //obtenemos el Json como un string 'ReadAsStringAsync'
                            var jsoncadena = await respuesta.Content.ReadAsStringAsync();
                            //Deserializaremos el json a la clase 'DatosClimaPuebla'
                            //la clase

                            data = JsonConvert.DeserializeObject<DataDivisas>(jsoncadena);
                        }
                        else
                        {
                            Error = "Se ha producido un error al olicitar el servivio web";
                            throw new Exception();  
                        }
                    }
                }
                catch (HttpRequestException ex)
                {

                    Error = $"Ocurrió un error: {ex.Message}";
                }
                return;


            }
            catch (Exception)
            {
                Error = "Ha ocurrido un error";
            }
        }


        public string ObtenerMonto()
        {
            if(data == null)
            {
                return "Has ingresado un valor incorrecto";
            }
            else
            {
                return data.converted_amount.ToString();

            }
        }
    }
}