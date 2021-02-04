using Ark.ResultCheckers.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Goke.Core;

namespace Ark.ResultCheckers.Api1.Controllers
{
    public partial class ApiController : ControllerBase
    {

        protected AppDbContext _context;
        protected IWebHostEnvironment _env;
        private IMemoryCache _cache;

        public ApiController(AppDbContext context, IWebHostEnvironment env, IMemoryCache memoryCache)
        {
            _context = context;
            _env = env;
            _cache = memoryCache;
        }

        protected async Task SaveChangesAndRemoveCacheAsync(string key)
        {
            int rows = await _context.SaveChangesAsync();
            if (rows > 0)
            {
                this.RemoveCache(key);
            }
        }

        protected async Task<(int count, long size, string[] paths)> UploadAsync(IEnumerable<IFormFile> files, string folder, string uniqueFileName = null)
        {
            var webRoot = _env.WebRootPath;
            var contentRoot = _env.ContentRootPath;

            var filePaths = new List<string>();

            //var files = Request.Form.Files;
            long size = files.Sum(f => f.Length);

            foreach (var file in files.Where(w => w.Length > 0))
            {
                var filePath = await SaveFile(file, webRoot, folder, uniqueFileName);
                filePaths.Add(filePath);

            }

            return (files.Count(), size, filePaths.ToArray());
        }

        protected async Task<(int count, long size, string path)> UploadAsync(IFormFile file, string folder, string uniqueFileName = null)
        {
            if (file == null)
                return (0, 0, null);

            var webRoot = _env.WebRootPath;
            var contentRoot = _env.ContentRootPath;

            var filePath = string.Empty;
            var fileName = string.Empty;
            var ext = string.Empty;

            //var files = Request.Form.Files;
            long size = file.Length;

            // to do save
            if (file.Length > 0)
            {
                filePath = await SaveFile(file, webRoot, folder, uniqueFileName);
            }

            return (1, size, filePath);
        }

        protected static async Task<string> SaveFile(IFormFile file, string webRoot, string folder, string uniqueFileName)
        {
            // to do save
            //if (file.Length > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var ext = Path.GetExtension(file.FileName);
                if (!string.IsNullOrWhiteSpace(uniqueFileName))
                {
                    fileName = $"{uniqueFileName}{ext}";
                }

                string filePath = GetFilePath(webRoot, folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return filePath;
            }
        }

        protected static string GetFilePath(string webRoot, string folder, string fileName)
        {
            return Path.Combine(webRoot, folder, fileName);
        }

        public FileResult GetFile(string virtualfolder, string fileName, string mimeType)
        {
            var virtualPath = $"/{virtualfolder}/{fileName}";
            var fileDownloadName = string.Format("pix.{0}", mimeType);

            var contentType = ""; // FileUpload.GetContentType(mimeType);
            return File(virtualPath, contentType, fileDownloadName);
        }

        /*
        protected async Task<string> SaveFileAsync(string contentUrl, string fileNamePrefix)
        {
            try
            {

                // save file first
                if (HttpContext.Request.Form.Files.Any())
                {
                    // remove old files
                    var fileNames = contentUrl?.Split('|', StringSplitOptions.RemoveEmptyEntries);
                    foreach (var item in fileNames)
                    {
                        if (System.IO.File.Exists(item))
                        {
                            System.IO.File.Delete(item);
                        }
                    }

                    for (int i = 0; i < HttpContext.Request.Form.Files.Count; i++)
                    {
                        var file = HttpContext.Request.Form.Files[i];

                        var ext = Path.GetExtension(file.FileName);
                        var fileName = $"{fileNamePrefix ??= "_"}{Guid.NewGuid()}{ext}";

                        var path = Path.Combine(_env.ContentRootPath, "files", fileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        contentUrl += path + "|";
                    }
                }

                // remove last |
                var fileUrl = contentUrl?.Substring(0, contentUrl.Length - 1);

                return fileUrl;
            }
            catch (Exception ex)
            {

                throw new Exception("File not upload", ex);
            }

        }
        */

        protected async Task<(string path, string virtualPath)> SaveFileByteAsync(string contentUrl, string fileNamePrefix, string folder ="files", bool saveToDisk=false)
        {
            try
            {
                var virtualPath = contentUrl;
                var path = string.Empty;

                // save file first
                if (DataUrl.IsValidContentUrl(contentUrl))
                {
                    var bytes = DataUrl.ToBytes(contentUrl);

                    if (saveToDisk || (bytes.Length / 1024 / 1024) > MaxSizeAllow())
                    {
                        var ext = DataUrl.ToFileExtension(contentUrl);

                        var fileName = $"{fileNamePrefix}{Guid.NewGuid()}.{ext}";

                        virtualPath = $"{folder}/{ fileName }";

                        path = Path.Combine(_env.ContentRootPath, virtualPath);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await stream.WriteAsync(bytes, 0, bytes.Length);
                        }

                        virtualPath = "/" + virtualPath;
                    }
                }
                return (path, virtualPath);
            }
            catch (Exception ex)
            {

                throw new Exception("File not upload", ex);
            }

        }

        private static int MaxSizeAllow()
        {
            return 1;
        }
    }

}
