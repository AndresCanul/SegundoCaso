using CasoEstudio2Web.Entidades;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Json;

namespace CasoEstudio2Web.Models
{
    public class CasasModel
    {
        public ResultadoCasa ConsultarCasas()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Casa/ConsultarCasas";
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ResultadoCasa>().Result;
                else
                    return null;
            }
        }

        public ResultadoCasa ListaCasas()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Casa/ListaCasas";
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ResultadoCasa>().Result;
                else
                    return null;
            }
        }

        public ResultadoCasa ConsultarCasa(long IdCasa)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Casa/ConsultarCasa?IdCasa=" + IdCasa;
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ResultadoCasa>().Result;
                else
                    return null;
            }
        }

        public Resultado AlquilarCasa(Casa entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Casa/AlquilarCasa";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PutAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Resultado>().Result;
                else
                    return null;
            }
        }
    }
}