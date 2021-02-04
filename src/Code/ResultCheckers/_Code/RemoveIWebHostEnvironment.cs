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

namespace Ark.ResultCheckers.Api1.Controllers
{
    public interface IWebHostEnvironment : IHostingEnvironment
    {
    }


}
namespace Ark.ResultCheckers.Api2.Controllers
{
    public interface IWebHostEnvironment : IHostingEnvironment
    {
    }


}

namespace Goke.Core
{
    public static class DataUrl
    {
        public static string ToDataUrl(this MemoryStream data, string format)
        {
            var span = new Span<byte>(data.GetBuffer()).Slice(0, (int)data.Length);
            return $"data:{format};base64,{Convert.ToBase64String(span.ToArray())}";
        }

        public static string ToDataUrl(this MemoryStream data)
        {
            var span = new Span<byte>(data.GetBuffer()).Slice(0, (int)data.Length);
            return $"{Convert.ToBase64String(span.ToArray())}";
        }

        public static byte[] ToBytes(string url)
        {
            var commaPos = url.IndexOf(',');
            if (commaPos >= 0)
            {
                var base64 = url.Substring(commaPos + 1);
                return Convert.FromBase64String(base64);
            }

            return null;
        }

        public static string ToData(string url)
        {
            var commaPos = url.IndexOf(',');
            if (commaPos >= 0)
            {
                var base64 = url.Substring(commaPos + 1);
                return base64;
            }

            return null;
        }

        public static string ToFormat(string url)
        {
            var commaPos1 = url.IndexOf(':');
            var commaPos2 = url.IndexOf(';');
            if (commaPos1 >= 0)
            {
                var format = url.Substring(commaPos1 + 1, commaPos2 - commaPos1 - 1);
                return format;
            }
            return null;
        }

        public static string ToFileExtension(string url)
        {
            var commaPos1 = url.IndexOf(':');
            var commaPos2 = url.IndexOf(';');
            if (commaPos1 >= 0)
            {
                var format = url.Substring(commaPos1 + 1, commaPos2 - commaPos1 - 1);
                return format.Substring(format.IndexOf('/') + 1);
            }
            return null;
        }

        public static bool IsValidContentUrl(string contentUrl)
        {
            return false;
        }
    }
}
