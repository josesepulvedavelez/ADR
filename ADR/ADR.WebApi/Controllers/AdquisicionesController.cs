using ADR.WebApi.Data;
using ADR.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ADR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdquisicionesController : ControllerBase
    {
        AdquisicionContext _adquisicionContext;

        public AdquisicionesController(AdquisicionContext adquisicionContext)
        {
            _adquisicionContext = adquisicionContext;
        }

        [HttpGet("Consultar")]
        public async Task<ActionResult> Consultar()
        {
            try
            {
                var adquisiciones = await _adquisicionContext.Adquisicion.ToListAsync();
                return Ok(adquisiciones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error {ex.Message}");
            }
        }

        [HttpGet("Consultar/{id}")]
        public async Task<ActionResult> Consultar(int id)
        {
            try
            {
                var adquisicion = await _adquisicionContext.Adquisicion.FindAsync(id);
                return Ok(adquisicion);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error {ex.Message}");
            }
        }

        [HttpPost("Crear")]
        public async Task<ActionResult> Crear([FromBody] AdquisicionModel adquisicionModel)
        {
            try
            {
                var adquisicion = await _adquisicionContext.Adquisicion.AddAsync(adquisicionModel);
                await _adquisicionContext.SaveChangesAsync();

                var id = adquisicion.Entity.AdquisicionId;

                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error {ex.Message}");
            }
        }

        [HttpPut("Modificar/{id}")]
        public async Task<ActionResult> Modificar(int id, [FromBody] AdquisicionModel adquisicionModel)
        {
            try
            {
                var existeAdquisicion = await _adquisicionContext.Adquisicion.FindAsync(id);

                if (existeAdquisicion == null)
                {
                    return NotFound(id);
                }

                existeAdquisicion.Unidad = adquisicionModel.Unidad;
                existeAdquisicion.TipoBien = adquisicionModel.TipoBien;
                existeAdquisicion.Cantidad = adquisicionModel.Cantidad;
                existeAdquisicion.ValorUnitario = adquisicionModel.ValorUnitario;
                existeAdquisicion.ValorTotal = adquisicionModel.ValorTotal;
                existeAdquisicion.FechaAdquisicion = adquisicionModel.FechaAdquisicion;
                existeAdquisicion.Proveedor = adquisicionModel.Proveedor;
                existeAdquisicion.Documentacion = adquisicionModel.Documentacion;

                await _adquisicionContext.SaveChangesAsync();

                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno al actualizar el cliente: {ex.Message}");
            }
        }

    }
}
