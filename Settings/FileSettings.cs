namespace GameZone.Settings
{
    public static class FileSettings
    {
        public const string ImagesPath = "/assets/images";
        public const string AllowedExtensions = ".jpg,.jpeg,.png";
        public const int MaxFileSizeInMB = 5;
        public const int MaxFileSizeInBytes = MaxFileSizeInMB * 1024 * 1024;
    }
}
