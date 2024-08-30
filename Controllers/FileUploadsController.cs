using Microsoft.AspNetCore.Mvc;
using Final_Retail.Models;
using Final_Retail.Services;
using System.Threading.Tasks;


namespace Final_Retail.Controllers
{
    public class FileUploadsController : Controller
    {
        private readonly FileUploadService _fileUploadService;

        public FileUploadsController(FileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        // GET: FileUploads
        public async Task<IActionResult> Index()
        {
            var files = await _fileUploadService.GetFileUploadsAsync("FileUploads");
            return View(files);
        }

        // GET: FileUploads/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileUpload = await _fileUploadService.GetFileUploadAsync("FileUploads", id);
            if (fileUpload == null)
            {
                return NotFound();
            }

            return View(fileUpload);
        }

        // GET: FileUploads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FileUploads/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FileName,FileUrl,ContentType")] FileUpload fileUpload)
        {
            if (ModelState.IsValid)
            {
                await _fileUploadService.AddOrUpdateFileUploadAsync(fileUpload);
                return RedirectToAction(nameof(Index));
            }
            return View(fileUpload);
        }

        // GET: FileUploads/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileUpload = await _fileUploadService.GetFileUploadAsync("FileUploads", id);
            if (fileUpload == null)
            {
                return NotFound();
            }
            return View(fileUpload);
        }

        // POST: FileUploads/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RowKey,FileName,FileUrl,ContentType")] FileUpload fileUpload)
        {
            if (id != fileUpload.RowKey)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _fileUploadService.AddOrUpdateFileUploadAsync(fileUpload);
                }
                catch
                {
                    if (!await FileUploadExists(fileUpload.RowKey))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fileUpload);
        }

        // GET: FileUploads/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileUpload = await _fileUploadService.GetFileUploadAsync("FileUploads", id);
            if (fileUpload == null)
            {
                return NotFound();
            }

            return View(fileUpload);
        }

        // POST: FileUploads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _fileUploadService.DeleteFileUploadAsync("FileUploads", id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> FileUploadExists(string id)
        {
            var fileUpload = await _fileUploadService.GetFileUploadAsync("FileUploads", id);
            return fileUpload != null;
        }
    }
}
