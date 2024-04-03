using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ProgromusTaskForge.API.Controllers;
[ApiController]
[Route(BaseApiPath+"/[controller]")]
[EnableCors("AllowOrigin")]
public class ApiBaseController:ControllerBase
{
    private const string BaseApiPath = "/api";
}