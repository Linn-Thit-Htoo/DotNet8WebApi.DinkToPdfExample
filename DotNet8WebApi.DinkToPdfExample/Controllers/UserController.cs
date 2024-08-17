namespace DotNet8WebApi.DinkToPdfExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IPDFService _pdfService;

    public UserController(IPDFService pdfService)
    {
        _pdfService = pdfService;
    }

    [HttpPost("Generate-PDF")]
    public async Task<IActionResult> GeneratePdf()
    {
        try
        {
            var user = new UserModel
            {
                UserId = 1,
                UserName = "Linn Thit",
                UserRole = "Admin",
                IsActive = true
            };

            var htmlStr = await _pdfService.GetHtml(user);
            var pdf = await _pdfService.GeneratePdf(htmlStr);

            return File(pdf, "application/pdf", $"{user.UserName}.pdf");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
