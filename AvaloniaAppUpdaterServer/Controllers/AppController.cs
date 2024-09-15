using AvaloniaAppUpdaterServer.Data;
using Microsoft.AspNetCore.Mvc;


namespace AvaloniaAppUpdaterServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly FileService _fileService;

        public AppController(FileService fileService)
        {
            _fileService = fileService;
        }
        [HttpGet("version")]
        public async Task<IActionResult> GetVersion()
        {
            var version = await _fileService.GetVersionAsync();
            if (version == null)
                return NotFound("Last version not found");

            return Ok(version);
        }

        [HttpGet("app")]
        public async Task<IActionResult> GetFile()
        {
            var file = await _fileService.GetFileAsync();
            if (file == null)
                return NotFound();

            return File(file.FileData, "application/zip");
        }

    }
}
