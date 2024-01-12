
using System.Globalization;

namespace Archivum.Logic
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (((byte[])value).Length == 0)
            {
                return ImageSource.FromFile("picture1.svg");
            }

            MemoryStream ms = new MemoryStream((byte[])value);

            return ImageSource.FromStream(() => ms);
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertImageSourceToBytesAsync((ImageSource)value);
        }
        public async Task<byte[]> ConvertImageSourceToBytesAsync(ImageSource imageSource)
        {
            Stream stream = await ((StreamImageSource)imageSource).Stream(CancellationToken.None);
            byte[] bytesAvailable = new byte[stream.Length];
            stream.Read(bytesAvailable, 0, bytesAvailable.Length);

            return bytesAvailable;
        }
    }
}
