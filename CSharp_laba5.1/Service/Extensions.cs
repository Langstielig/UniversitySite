namespace CSharp_laba5._1.Service
{
    public static class Extensions
    {
        public static string CutController(this string str)
        {
            return str.Replace("Controller", ""); //вырезаем вхождение Controller
        }
    }
}
