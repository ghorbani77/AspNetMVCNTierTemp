
namespace MVC5.Web.Searching
{
    public static class YeKe
    {
        public const char ArabicYeChar = (char)1610;
        public const char PersianYeChar = (char)1740;

        public const char ArabicKeChar = (char)1603;
        public const char PersianKeChar = (char)1705;


        public static string ApplyCorrectYeKe(this string data)
        {
            if (string.IsNullOrWhiteSpace(data)) return string.Empty;
            return data.Replace(ArabicYeChar, PersianYeChar).Replace(ArabicKeChar, PersianKeChar).Trim();
        }
    }
}
