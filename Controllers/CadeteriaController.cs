using Microsoft.AspNetCore.Mvc;

namespace tl2_tp4_2023_jmfloress.Controllers;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{
    private Cadeteria cadeteria;

    private readonly ILogger<CadeteriaController> _logger;

    public CadeteriaController(ILogger<CadeteriaController> logger)
    {
        _logger = logger;
        cadeteria = Cadeteria.GetCadeteriaSingleton("./Datos/Cadetes.json", "./Datos/Cadeterias.json");
    }

    [HttpGet("GetPedidos")]
    public ActionResult<List<Pedido>> GetPedidos()
    {
        if(cadeteria.ListadoPedido.Count() != 0)
            return Ok(cadeteria.ListadoPedido);
        return BadRequest("No se encontraron pedidos");
        
    }

    [HttpGet("GetCadetes")]
    public ActionResult<List<Cadete>> GetCadetes()
    {
        if(cadeteria.ListadoCadete.Count() != 0)
            return Ok(cadeteria.ListadoCadete);
        return BadRequest("No se encontraron cadetes");
        
    }

    [HttpGet("GetInforme")]
    public ActionResult<Informe> GetInforme()
    {
        if(cadeteria.ListadoPedido.Count() != 0)
            return Ok(cadeteria.GetInforme());
        return BadRequest("Aun no se han cargado pedidos");  
    }

    [HttpPost("AgregarPedido")]
    public ActionResult<string> AgregarPedido(Pedido pedido)
    {
        if(cadeteria.AltaPedido(pedido))
            return Ok("Pedido agregado con exito!");
        return BadRequest("Error al intentar guardar el pedido");
    }

    [HttpPut("AsignarPedido")]
    public ActionResult AsignarPedido(int idPedido, int idCadete)
    {
        if (cadeteria.AsignarCadeteAPedido(idPedido, idCadete))
            return Ok("Pedido asignado con exito");
        return BadRequest("No se pudo asignar el pedido al cadete");
    }

    [HttpPut("CambiarEstadoPedido")]
    public ActionResult CambiarEstadoPedido(int idPedido,int nuevoEstado)
    {
        if (cadeteria.CambiarEstadoPedido(idPedido, nuevoEstado))
            return Ok("Estado del pedido cambiado con exito");
        return BadRequest("No se pudo cambiar el estado del pedido");
    }

    [HttpPut("CambiarCadetePedido")]
    public ActionResult CambiarCadetePedido(int idPedido,int idNuevoCadete)
    {
        if (cadeteria.AsignarCadeteAPedido(idPedido, idNuevoCadete))
            return Ok("Estado del pedido cambiado con exito");
        return BadRequest("No se pudo cambiar el estado del pedido");
    }
}