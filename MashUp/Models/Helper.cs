using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using static MashUp.Models.Location;

//Manejador de la clase Data helper (Direccion, Longitud y latitud atraves de ciudad y pais)
namespace MashUp.Models
{
    public class Helper
    {
        Location root;
        HelperPuebla helper;


        string DirBase;
        public string Error { get; set; }

        public string ciudad { get; set; }
        public string pais { get; set; }

        HttpMessageHandler HandlerDatos;

        public Helper()
        {
            HandlerDatos = new HttpClientHandler();
        }

        public async Task ObtenerData()
        {
            // Nuestro EndPoint https://nominatim.openstreetmap.org/search?q=puebla&countrycodes=mx&format=json&addressdateils=1

            //Definimos nuestra Dirección Base
            DirBase = "https://nominatim.openstreetmap.org";

            //Y nuestro URI
            try
            {
                string solicitudCliente = $"/search?q={ciudad}&countrycodes={pais}&format=json&addressdetails=0";
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
                        Cliente.DefaultRequestHeaders.Add("User-Agent", "Identificador");

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

                            root = JsonConvert.DeserializeObject<List<Location>>(jsoncadena).FirstOrDefault();
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


      
        //Funcion para obtener Latitud
        public string obtenerLatitud()
        {
            if(root == null)
            {
                return "Valor no disponible";
            }
            else
            {
                return root.lat;

            }


        }
        //Funcion para obtener Longiud 
        public string obtenerLongitud()
        {
            if(root == null)
            {
                return "Valor no disponible";
            }
            else
            {

            return root.lon;
            }


        }

    }

}