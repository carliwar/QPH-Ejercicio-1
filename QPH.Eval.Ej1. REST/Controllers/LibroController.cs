using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QPH.Eval.Ej1._REST.Models;
using QPH.Eval.Ej1.Business;
using QPH.Eval.Ej1.Core;
using QPH.Eval.Ej1.Core.Models;
using QPH.Eval.Ej1.Repository;

namespace QPH.Eval.Ej1._REST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public LibroController(IConfiguration configuration, IMapper mapper)
        {
            this.configuration = configuration;
            this.mapper = mapper;
        }
        
        [HttpGet]
        public IEnumerable<Libro> Get(int page, string filter, bool? asc, string customFilter, string customFilterValue)
        {
            var dbContext = new QPHContext(configuration.GetConnectionString("QPHDB"));
            var libroRepository = new LibroRepository(dbContext);
            var librosBusiness = new LibrosBusiness(libroRepository);

            Enum.TryParse(customFilter, out SortingEnum sortingEnum);

            var results = librosBusiness.GetLibros(page, filter, asc, sortingEnum, customFilterValue);

            return results;
        }

        [HttpPost]
        public  IActionResult CreateLibro(LibroCreateRequest newLibro)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dbContext = new QPHContext(configuration.GetConnectionString("QPHDB"));
            var libroRepository = new LibroRepository(dbContext);
            var librosBusiness = new LibrosBusiness(libroRepository);

            Libro libroACrear = mapper.Map<Libro>(newLibro);

            LibroPostResult result = librosBusiness.CreateLibro(libroACrear);

            if (!result.Success)
            {
                string erroresSerializado = JsonConvert.SerializeObject(result.Errors);
                return BadRequest(erroresSerializado);
            }
                
            return Ok();
        }

        [HttpPost]
        public IActionResult ActualizarLibro(LibroCreateRequest libro)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dbContext = new QPHContext(configuration.GetConnectionString("QPHDB"));
            var libroRepository = new LibroRepository(dbContext);
            var librosBusiness = new LibrosBusiness(libroRepository);

            Libro libroActualizar = mapper.Map<Libro>(libro);

            LibroPostResult result = librosBusiness.UpdateLibro(libroActualizar);

            if (!result.Success)
            {
                string erroresSerializado = JsonConvert.SerializeObject(result.Errors);
                return BadRequest(erroresSerializado);
            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult EliminarLibro(int libroId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dbContext = new QPHContext(configuration.GetConnectionString("QPHDB"));
            var libroRepository = new LibroRepository(dbContext);
            var librosBusiness = new LibrosBusiness(libroRepository);

            try
            {
                librosBusiness.DeleteLibro(libroId);
            }
            catch (Exception exception)
            {
                string erroresSerializado = JsonConvert.SerializeObject(exception);
                return BadRequest(erroresSerializado);
            }           

            return Ok();
        }

    }
}
