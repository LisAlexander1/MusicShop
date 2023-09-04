
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MusicShop.Helpers;
public class BlobToImageConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        byte[] blobData = value as byte[];
            
        if (blobData != null && blobData.Length > 0)
        {
            // Создаем временный файл для хранения BLOB-данных
            string tempFilePath = Path.GetTempFileName();
                
            try
            {
                // Записываем BLOB-данные во временный файл
                File.WriteAllBytes(tempFilePath, blobData);
                    
                // Загружаем изображение из временного файла
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.UriSource = new Uri(tempFilePath);
                bitmapImage.EndInit();
                    
                return bitmapImage;
            }
            finally
            {
                // Удаляем временный файл
                File.Delete(tempFilePath);
            }
        }
            
        return null;
    }
        
    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        return default;
    }
}