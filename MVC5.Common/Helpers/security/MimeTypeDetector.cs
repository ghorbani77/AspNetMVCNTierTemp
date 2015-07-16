using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace MVC5.Common.Helpers.security
{
    
    public class MimeTypeDetector
    {
        private static readonly IList<string> WhiteListMimeType=new List<string>
        {
            "image/jpeg",
            "image/png",
            "image/pjpeg",
            "image/x-png",
            "text/plain",
            "text/html",
            "text/xml",
            "text/richtext",
            "text/scriptlet",
            "audio/x-aiff",
            "audio/basic",
            "audio/mid",
            "audio/wav",
            "image/gif",
            "image/tiff",
            "image/bmp",
            "image/x-xbitmap",
            "image/x-jg",
            "image/x-emf",
            "image/x-wmf",
            "video/avi",
            "video/mpeg",
            "application/octet-stream",
            "application/postscript",
            "application/base64",
            "application/macbinhex40",
            "application/pdf",
            "pplication/xml",
            "application/atom+xml",
            "application/rss+xml",
            "application/x-compressed",
            "pplication/x-zip-compressed",
            "pplication/x-gzip-compressed",
            "application/java",
           //executable(.exe & .dll) "application/x-msdownload"
        };

        [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
        private extern static System.UInt32 FindMimeFromData(
            System.UInt32 pBc,
            [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
            [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
            System.UInt32 cbSize,
            [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
            System.UInt32 dwMimeFlags,
            out System.UInt32 ppwzMimeOut,
            System.UInt32 dwReserverd
        );

        public static bool IsAllowMimeType(HttpPostedFileBase file)
        {
            var result = "";
            try
            {
                var data = new byte[256];
                file.InputStream.Read(data, 0, 256);

                var buffer = new byte[256];
                var length = (data.Length > 256) ? 256 : data.Length;
                Array.Copy(data, data, length);

                System.UInt32 mimetype;
                FindMimeFromData(0, null, buffer, 256, null, 0, out mimetype, 0);
                var mimeTypePtr = new IntPtr(mimetype);
                result = Marshal.PtrToStringUni(mimeTypePtr);
                Marshal.FreeCoTaskMem(mimeTypePtr);
            }
            catch
            {
                return false;
            }

            return WhiteListMimeType.Any(a => a == result);
        }


    }
}