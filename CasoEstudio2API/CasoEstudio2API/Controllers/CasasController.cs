using CasoEstudio2API.Entidades;
using CasoEstudio2API.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace CasoEstudio2API.Controllers
{
    public class CasasController : ApiController
    {
        [HttpGet]
        [Route("Casa/ConsultarCasas")]
        public ResultadoCasa ConsultarCasas()
        {
            var respuesta = new ResultadoCasa();

            try
            {
                //Llamar a la base de datos
                using (var db = new CasoEstudioKNEntities())
                {
                    var datos = db.ConsultarCasas().ToList();

                    if (datos.Count > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                        respuesta.Datos = datos;

                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se encontraron resultados";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presento un error en el sistema";
            }

            return respuesta;
        }

        [HttpGet]
        [Route("Casa/ListaCasas")]
        public ResultadoCasa ListaCasas()
        {
            var respuesta = new ResultadoCasa();

            try
            {
                //Llamar a la base de datos
                using (var db = new CasoEstudioKNEntities())
                {
                    var datos = db.ListaCasas().ToList();

                    if (datos.Count > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                        respuesta.Datos = datos;

                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se encontraron resultados";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presento un error en el sistema";
            }

            return respuesta;
        }

        [HttpGet]
        [Route("Casa/ConsultarCasa")]
        public ResultadoCasa ConsultarCasa(long IdCasa)
        {
            var respuesta = new ResultadoCasa();

            try
            {
                //Llamar a la base de datos
                using (var db = new CasoEstudioKNEntities())
                {
                    var dato = db.ConsultarCasa(IdCasa).FirstOrDefault();

                    if (dato != null)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                        respuesta.Dato = dato;
                    }

                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se encontraron resultados";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presento un error en el sistema";
            }

            return respuesta;
        }

        [HttpPut]
        [Route("Casa/AlquilarCasa")]
        public Resultado AlquilarCasa(Casa entidad)
        {
            var respuesta = new Resultado();

            try
            {
                //Llamar a la base de datos
                using (var db = new CasoEstudioKNEntities())
                {
                    var resp = db.AlquilarCasa(entidad.IdCasa, entidad.UsuarioAlquiler);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "Su informacion ya se encuentra registrada";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "su informacion no se pudo registrar";
            }

            return respuesta;
        }

    }
}
