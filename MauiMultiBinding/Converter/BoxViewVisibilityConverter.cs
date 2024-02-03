using System.Globalization;
using MauiMultiBinding.Models;

namespace MauiMultiBinding.Converter;

public class BoxViewVisibilityConverter : IMultiValueConverter
{
    public static int Count = 0;
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        Count++;
        // if (values[1] != null)
        // {
        //     var currentProduct = values[1] as Product;
        //     return currentProduct!.IsBoxViewVisible;
        // }
        return (Count % 2 == 0);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}