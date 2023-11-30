using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MashUp.Models
{
    public class HelperGasolina
    {
        Helper nuevoHelper;

        public List<Codigos> DatosCodigos { get; set; }
        public string ciudad { get; set; }
        public HelperGasolina()
        {
            DatosCodigos = new List<Codigos>();

            DatosCodigos.Add(new Codigos
            {
                Estado = "AGUASCALIENTES",
                Abreviatura = "AGS"
            });
            DatosCodigos.Add(new Codigos
            {
                Estado = "BAJA CALIFORNIA",
                Abreviatura = "BC"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "BAJA CALIFORNIA SUR",
                Abreviatura = "BCS"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "CAMPECHE",
                Abreviatura = "CAMP"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "CHIAPAS",
                Abreviatura = "CHIS"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "CHIHUAHUA",
                Abreviatura = "CHIH"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "CIUDAD DE MÉXICO",
                Abreviatura = "CDMX"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "COAHUILA DE ZARAGOZA",
                Abreviatura = "COAH"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "COLIMA",
                Abreviatura = "COL"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "DURANGO",
                Abreviatura = "DGO"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "ESTADO DE MÉXICO",
                Abreviatura = "MEX"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "GUANAJUATO",
                Abreviatura = "GTO"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "GUERRERO",
                Abreviatura = "GRO"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "HIDALGO",
                Abreviatura = "HGO"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "JALISCO",
                Abreviatura = "JAL"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "MICHOACÁN DE OCAMPO",
                Abreviatura = "MICH"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "MORELOS",
                Abreviatura = "MOR "
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "NAYARIT",
                Abreviatura = "NAY "
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "NUEVO LEÓN",
                Abreviatura = "NL"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "OAXACA",
                Abreviatura = "OAX"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "PUEBLA",
                Abreviatura = "PUE"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "QUERÉTARO",
                Abreviatura = "QRO"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "QUINTANA ROO",
                Abreviatura = "QROO"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "SAN LUIS POTOSÍ",
                Abreviatura = "SLP"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "SINALOA",
                Abreviatura = "SIN"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "SONORA",
                Abreviatura = "SON"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "TABASCO",
                Abreviatura = "TAB"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "TAMAULIPAS",
                Abreviatura = "TAMPS"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "TLAXCALA",
                Abreviatura = "TLAX"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "VERACRUZ",
                Abreviatura = "VER"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "YUCATÁN",
                Abreviatura = "YUC"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "ZACATECAS",
                Abreviatura = "ZAC"
            });

        }
        public string ObtenerAbreviatura()
        {
            string abreviatura = "";
            for (int i = 0; i <= DatosCodigos.Count - 1; i++)
            {
                if (DatosCodigos[i].Estado.ToUpper() == ciudad.ToUpper())
                {
                    abreviatura = DatosCodigos[i].Abreviatura;
                    break;
                } 
               
            }
            return abreviatura;
        }
    }
}