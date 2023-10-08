using Microsoft.AspNetCore.Mvc;

namespace tl2_tp4_2023_jmfloress.Controllers;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{
    private Cadeteria? cadeteria;

    private readonly ILogger<CadeteriaController> _logger;

    public CadeteriaController(ILogger<CadeteriaController> logger)
    {
        _logger = logger;
        cadeteria = Cadeteria.GetCadeteriaSingleton();
    }

    [HttpGet("GetNombre")]
    public ActionResult<string> GetNombre()
    {
        if(cadeteria != null)
            return Ok(cadeteria.Nombre);
        return BadRequest("No encontro la cadeteria.");
    }

    [HttpGet("GetPedidos")]
    public ActionResult<List<Pedido>> GetPedidos()
    {
        if(cadeteria != null && cadeteria.ListadoPedido.Count() != 0)
            return Ok(cadeteria.ListadoPedido);
        return BadRequest("No se encontraron pedidos.");
        
    }

    [HttpGet("GetCadetes")]
    public ActionResult<List<Cadete>> GetCadetes()
    {
        if(cadeteria != null && cadeteria.ListadoCadete.Count() != 0)
            return Ok(cadeteria.ListadoCadete);
        return BadRequest("No se encontraron cadetes.");
    }

    [HttpGet("GetPedido")]
    public ActionResult<Pedido> GetPedido(int nro) {
        Pedido pedido;
        if(cadeteria != null){
            pedido = cadeteria.GetPedido(nro);
            if(pedido != null)
                return Ok(pedido);
        }  
        return BadRequest("No se encontro el pedido.");
    }

    [HttpGet("GetCadete")]
    public ActionResult<Cadete> GetCadete(int id) {
        Cadete cadete;
        if(cadeteria != null){
            cadete = cadeteria.GetCadete(id);
            if(cadete != null)
                return Ok(cadete);
        }
        return BadRequest("No se encontro el cadete.");
    }

    [HttpGet("GetInforme")]
    public ActionResult<Informe> GetInforme()
    {
        if(cadeteria != null && cadeteria.ListadoPedido.Count() != 0)
            return Ok(cadeteria.GetInforme());
        return BadRequest("Aun no se han cargado pedidos.");  
    }

    [HttpPost("AgregarPedido")]
    public ActionResult<Pedido> AgregarPedido(Pedido pedido)
    {
        if(cadeteria != null && cadeteria.AltaPedido(pedido))
            return Ok(pedido);
        return BadRequest("Error al intentar guardar el pedido.");
    }

    [HttpPost("AgregarCadete")]
    public ActionResult<Cadete> AgregarCadete(Cadete cadete)
    {
        if(cadeteria != null && cadeteria.AltaCadete(cadete))
            return Ok(cadete);
        return BadRequest("Error al intentar guardar al cadete.");
    }

    [HttpPut("AsignarPedido")]
    public ActionResult<Pedido> AsignarPedido(int nroPedido, int idCadete)
    {
        if (cadeteria != null && cadeteria.AsignarCadeteAPedido(nroPedido, idCadete)){
            Pedido pedido = cadeteria.GetPedido(nroPedido);
            return Ok(pedido);
        }
        return BadRequest("No se pudo asignar el pedido al cadete.");
    }

    [HttpPut("CambiarEstadoPedido")]
    public ActionResult<Pedido> CambiarEstadoPedido(int nroPedido,int nuevoEstado)
    {
        if (cadeteria != null && cadeteria.CambiarEstadoPedido(nroPedido, nuevoEstado)){
            Pedido pedido = cadeteria.GetPedido(nroPedido);
            return Ok(pedido);
        }
        return BadRequest("No se pudo cambiar el estado del pedido.");
    }

    [HttpPut("CambiarCadetePedido")]
    public ActionResult<Pedido> CambiarCadetePedido(int nroPedido,int idNuevoCadete)
    {
        if (cadeteria != null && cadeteria.AsignarCadeteAPedido(nroPedido, idNuevoCadete)){
            Pedido pedido = cadeteria.GetPedido(nroPedido);
            return Ok(pedido);
        }
        return BadRequest("No se pudo cambiar el estado del pedido.");
    }

    [HttpPut("ModificarPedido")]
    public ActionResult<Pedido> ModificarPedido(int nroPedido, string obs, string nombre, string direccion, string telefono, string datosReferenciaDireccion)
    {
        if (cadeteria != null && cadeteria.ModificarPedido(nroPedido, obs, nombre, direccion, telefono, datosReferenciaDireccion))
        {
            Pedido pedido = cadeteria.GetPedido(nroPedido);
            return Ok(pedido);
        }
        return BadRequest("No se pudo cambiar el estado del pedido.");
    }

    [HttpDelete("BorrarPedido")]
    public ActionResult<Pedido> BorrarPedido(int nroPedido)
    {
        if (cadeteria != null && cadeteria.BorrarPedido(nroPedido)){
            return Ok("El pedido se borro con exito.");
        }
        return BadRequest("No se pudo cambiar el estado del pedido.");
    }

}