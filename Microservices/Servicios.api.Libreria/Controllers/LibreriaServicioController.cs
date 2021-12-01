﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.api.Libreria.Core.Entities;
using Servicios.api.Libreria.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicios.api.Libreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibreriaServicioController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;

        private readonly IMongoRepository<AutorEntity> _autorGenericoRepository;
        private readonly IMongoRepository<EmpleadoEntity> _empleadoGenericoRepository;
        public LibreriaServicioController(IAutorRepository autorRepository, 
            IMongoRepository<AutorEntity> autorGenericoRepository,
            IMongoRepository<EmpleadoEntity> empleadoGenericoRepository)
        {
            _autorRepository = autorRepository;
            _autorGenericoRepository = autorGenericoRepository;
            _empleadoGenericoRepository = empleadoGenericoRepository;
        }

        [HttpGet("autorGenerico")]
        public async Task<ActionResult<IEnumerable<AutorEntity>>> GetAutorGenerico()
        {
            var autores = await _autorGenericoRepository.GetAll();
            return Ok(autores);
        }
        
        [HttpGet("empleados")]
        public async Task<ActionResult<IEnumerable<AutorEntity>>> GetEmpleadoGenerico()
        {
            var autores = await _empleadoGenericoRepository.GetAll();
            return Ok(autores);
        }
        
        [HttpGet("autores")]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutores()
        {
            var autores = await _autorRepository.GetAutores();
            return Ok(autores);
        }

    }
}
