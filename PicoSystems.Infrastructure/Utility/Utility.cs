namespace PicoSystems.Infrastructure.Utility
{
    public static class Utility
    {

        public static bool ExistsPath(string path)
        {
            return File.Exists(path);
        }
    }
}
