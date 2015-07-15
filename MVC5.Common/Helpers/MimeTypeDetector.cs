using System;
using System.Runtime.InteropServices;
using System.Web;

namespace MVC5.Common.Helpers
{
    public class MimeTypeDetector
    {
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

        public string GetMimeType(byte[] content)
        {
            var result = "unknown/unknown";

            try
            {
                var buffer = new byte[256];
                var length = (content.Length > 256) ? 256 : content.Length;
                Array.Copy(content, buffer, length);

                System.UInt32 mimetype;
                FindMimeFromData(0, null, buffer, 256, null, 0, out mimetype, 0);
                var mimeTypePtr = new IntPtr(mimetype);
                result = Marshal.PtrToStringUni(mimeTypePtr);
                Marshal.FreeCoTaskMem(mimeTypePtr);
            }
            catch (Exception)
            {
               //Log.WriteError(MethodInfo.GetCurrentMethod(), ex);
            }


            return result;
        }

    }
}