using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using Xamarin.Forms;

namespace OrlandoDemo.Converters
{
    public class ImageConverter: IValueConverter
    {
        public ImageConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string uri = "https://www.nasa.gov/sites/all/themes/custom/nasatwo/images/nasa-logo.svg";
            if (value != null)
            {
                string url = value.ToString();
                uri = url.Replace("public://", "https://www.nasa.gov/sites/default/files/styles/image_card_4x3_ratio/public/");
            }
            //HttpClient client = new HttpClient();
            //Stream s = await client.GetStreamAsync(uri);
            //StreamWriter fs = new StreamWriter(s);

            return uri;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //throw new NotImplementedException();
            return null;
        }
    }
}
