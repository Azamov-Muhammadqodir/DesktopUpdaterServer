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

        [HttpGet("{fileId}")]
        public async Task<IActionResult> GetFile(int fileId)
        {
            var file = await _fileService.GetFileAsync(fileId);
            if (file == null)
                return NotFound();

            return File(file.FileData, "application/zip");
        }

    }
}
