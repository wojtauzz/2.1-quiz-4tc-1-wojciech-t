using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace QuizBobry.Converters;

/// <summary>
/// Converts a 0–100 percentage to a pixel width (assuming max ~560px track).
/// </summary>
public class PercentToWidthConverter : IValueConverter
{
    public static readonly PercentToWidthConverter Instance = new();
    private const double MaxWidth = 560;

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double pct)
            return pct / 100.0 * MaxWidth;
        return 0.0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
