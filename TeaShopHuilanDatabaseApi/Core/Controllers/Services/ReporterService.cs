namespace TeaShopHuilanDatabaseApi.Core.Controllers.Services
{
    public static class ReporterService
    {
        public static async Task<byte[]> GetContent(string path)
        {
            if (path == null)
                return [];

            var fileData = await File.ReadAllBytesAsync(path);
            return fileData;
        }
    }
}
