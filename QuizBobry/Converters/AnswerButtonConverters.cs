using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace QuizBobry.Converters;

/// <summary>
/// Returns a background brush for an answer button based on selection state.
/// Parameters via MultiBinding: Answered (bool), SelectedAnswer (int), CorrectAnswer (int), ButtonIndex (string).
/// </summary>
public class AnswerBackgroundConverter : IMultiValueConverter
{
    private static readonly Brush Default = new SolidColorBrush(Color.FromRgb(45, 55, 72));       // dark slate
    private static readonly Brush Hover = new SolidColorBrush(Color.FromRgb(55, 65, 85));
    private static readonly Brush Correct = new SolidColorBrush(Color.FromRgb(22, 101, 52));      // green
    private static readonly Brush Incorrect = new SolidColorBrush(Color.FromRgb(153, 27, 27));    // red

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length < 3
            || values[0] is not bool answered
            || values[1] is not int selected
            || values[2] is not int correct
            || parameter is not string idxStr
            || !int.TryParse(idxStr, out int idx))
            return Default;

        if (!answered) return Default;

        if (idx == correct) return Correct;
        if (idx == selected && selected != correct) return Incorrect;
        return Default;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        => throw new NotSupportedException();
}

/// <summary>
/// Returns border brush for answer buttons.
/// </summary>
public class AnswerBorderConverter : IMultiValueConverter
{
    private static readonly Brush Default = new SolidColorBrush(Color.FromRgb(74, 85, 104));
    private static readonly Brush Correct = new SolidColorBrush(Color.FromRgb(34, 197, 94));
    private static readonly Brush Incorrect = new SolidColorBrush(Color.FromRgb(239, 68, 68));

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length < 3
            || values[0] is not bool answered
            || values[1] is not int selected
            || values[2] is not int correct
            || parameter is not string idxStr
            || !int.TryParse(idxStr, out int idx))
            return Default;

        if (!answered) return Default;

        if (idx == correct) return Correct;
        if (idx == selected && selected != correct) return Incorrect;
        return Default;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        => throw new NotSupportedException();
}

/// <summary>
/// BoolToVisibility: true → Visible, false → Collapsed.
/// </summary>
public class BoolToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is true ? Visibility.Visible : Visibility.Collapsed;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotSupportedException();
}

/// <summary>
/// Inverted BoolToVisibility: false → Visible, true → Collapsed.
/// </summary>
public class InverseBoolToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is true ? Visibility.Collapsed : Visibility.Visible;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotSupportedException();
}

/// <summary>
/// Returns the feedback border brush (green if correct, red if incorrect).
/// </summary>
public class FeedbackBorderConverter : IValueConverter
{
    private static readonly Brush Correct = new SolidColorBrush(Color.FromRgb(34, 197, 94));
    private static readonly Brush Incorrect = new SolidColorBrush(Color.FromRgb(239, 68, 68));

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is true ? Correct : Incorrect;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
