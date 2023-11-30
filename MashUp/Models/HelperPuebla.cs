using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using MashUp.Models;



namespace MashUp.Models
{
    public class HelperPuebla
    {
        Temperatures dato;

        string DirBase;
        public string Error { get; set; }

        HttpMessageHandler HandlerClima;

        public HelperPuebla()
        {
            HandlerClima = new HttpClientHandler();
        }


        public async Task ObtenerDatosPuebla(string lat, string lon)
        {
            // Nuestro EndPoint https://api.openweathermap.org/data/2.5/weather?lat=18.833333&lon=-98.0&appid=5c06c6e640d5d7b37544317e22c5bad0

            //Definimos nuestra Dirección Base
            DirBase = "https://api.openweathermap.org";

            //Y nuestro URI

            string solicitudCliente = $"/data/2.5/weather?lat={lat}&lon={lon}&appid=5c06c6e640d5d7b37544317e22c5bad0&lang=es";
            try
            {
                //Se crea la instancia HttpCliente, el objeto se destruye al 
                // terminar la ejecución delk bloque using 
                using (var Cliente = new HttpClient(HandlerClima))
                {
                    //configuramos la cabecera de la solicitud del servicio web
                    Cliente.BaseAddress = new Uri(DirBase);
                    Cliente.DefaultRequestHeaders.Accept.Clear();
                    Cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/Json"));

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

                        dato = JsonConvert.DeserializeObject<Temperatures>(jsoncadena);



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

                Error = ex.Message;
            }
            return;

        }





        //Funciones propias para Obtener datos de PUEBLA

        public string ObtenerNombre()
        {
            if (dato == null)
            {
                return "Valor no disponible";
            }
            return dato.Name;

        }

        //Obtener la temperatura actual
        public string ObtenerTemperatura()
        {
            if (dato == null)
            {
                return "Valor no disponible";

            }
            else
            {
                var temp = dato.Main.Temp - 273.15 + "°";
                return temp.ToString();
            }

        }

        //Obtener la temperatura máxima
        public string ObtenerTemperaturaMaxima()
        {
            if (dato == null)
            {
                return "Valor no disponible";
            }
            else
            {
                var tempMax = dato.Main.temp_max - 273.15 + "°";
                return tempMax.ToString();
            }

        }

        //Obtener la temperatura mínima
        public string ObtenerTemperaturaMinima()
        {
            if (dato == null)
            {
                return "Valor no disponible";
            }
            else
            {
                var tempMin = dato.Main.temp_min - 273.15 + "°";
                return tempMin.ToString();
            }

        }

        //Obtener la imagen descriptiva del clima
        public string ObtenerImagen()
        {
            if (dato == null)
            {
                return "Valor no disponible";
            }
            else
            {
                var img = dato.Weather[0].Icon;
                var urlImg = $"http://openweathermap.org/img/wn/{img}.png";
                return urlImg;
            }

        }

        //Obtener la descripción
        public string ObtenerDescripcion()
        {
            if (dato == null)
            {
                return "Valor no disponible";
            }
            else
            {
                var desc = dato.Weather[0].Description;
                return desc.ToString();
            }

        }
        //Obtener la nubosidad
        public string ObtenerNubosidad()
        {
            if (dato == null)
            {
                return "Valor no disponible";
            }
            else
            {
                var clouds = dato.Clouds.All;
                return clouds.ToString();
            }

        }

        //Obtener la Humedad
        public string ObtenerHumedad()
        {
            if (dato == null)
            {
                return "Valor no disponible";
            }
            else
            {
                var humedad = dato.Main.Humidity;
                return humedad.ToString();

            }
        }

        //Obtener la hora de salida del sol
        public string ObtenerHoraSalidaSol()
        {
            if (dato == null)
            {
                return "Valor no disponible";
            }
            else
            {
                DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                date = date.AddSeconds(dato.Sys.Sunrise);
                return date.ToString();
            }

        }

        //Obtener la hora de puesta del sol
        public string ObtenerHoraPuestaSol()
        {
            if (dato == null)
            {
                return "Valor no disponible";
            }
            else
            {
                DateTime fecha = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                fecha = fecha.AddSeconds(dato.Sys.Sunset);


                return fecha.ToString();
            }


        }
    }
}