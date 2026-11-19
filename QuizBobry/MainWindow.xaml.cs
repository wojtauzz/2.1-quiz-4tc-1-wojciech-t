using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using QuizBobry.ViewModels;

namespace QuizBobry;

public partial class MainWindow : Window
{
    private static readonly Brush DefaultBg = new SolidColorBrush(Color.FromRgb(45, 55, 72));
    private static readonly Brush DefaultBorder = new SolidColorBrush(Color.FromRgb(74, 85, 104));
    private static readonly Brush CorrectBg = new SolidColorBrush(Color.FromRgb(22, 101, 52));
    private static readonly Brush CorrectBorder = new SolidColorBrush(Color.FromRgb(34, 197, 94));
    private static readonly Brush IncorrectBg = new SolidColorBrush(Color.FromRgb(153, 27, 27));
    private static readonly Brush IncorrectBorder = new SolidColorBrush(Color.FromRgb(239, 68, 68));

    public MainWindow()
    {
        InitializeComponent();

        // Define the AnswerBtnTemplate in code to avoid complex XAML bindings
        Resources["AnswerBtnTemplate"] = CreateAnswerButtonTemplate();
    }

    private static ControlTemplate CreateAnswerButtonTemplate()
    {
        var template = new ControlTemplate(typeof(Button));

        var borderFactory = new FrameworkElementFactory(typeof(Border));
        borderFactory.SetValue(Border.CornerRadiusProperty, new CornerRadius(10));
        borderFactory.SetBinding(Border.PaddingProperty, new System.Windows.Data.Binding("Padding")
        {
            RelativeSource = new System.Windows.Data.RelativeSource(System.Windows.Data.RelativeSourceMode.TemplatedParent)
        });
        borderFactory.SetBinding(Border.BackgroundProperty, new System.Windows.Data.Binding("Background")
        {
            RelativeSource = new System.Windows.Data.RelativeSource(System.Windows.Data.RelativeSourceMode.TemplatedParent)
        });
        borderFactory.SetBinding(Border.BorderBrushProperty, new System.Windows.Data.Binding("BorderBrush")
        {
            RelativeSource = new System.Windows.Data.RelativeSource(System.Windows.Data.RelativeSourceMode.TemplatedParent)
        });
        borderFactory.SetBinding(Border.BorderThicknessProperty, new System.Windows.Data.Binding("BorderThickness")
        {
            RelativeSource = new System.Windows.Data.RelativeSource(System.Windows.Data.RelativeSourceMode.TemplatedParent)
        });

        var contentFactory = new FrameworkElementFactory(typeof(ContentPresenter));
        contentFactory.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Left);
        contentFactory.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);

        borderFactory.AppendChild(contentFactory);
        template.VisualTree = borderFactory;

        return template;
    }

    private QuizViewModel VM => (QuizViewModel)DataContext;

    private Button[] AnswerButtons => [BtnA, BtnB, BtnC];

    private void AnswerButton_Click(object sender, RoutedEventArgs e)
    {
        // After the command has executed, update button colors
        Dispatcher.InvokeAsync(() => UpdateAnswerButtonColors());
    }

    private void NextButton_Click(object sender, RoutedEventArgs e)
    {
        Dispatcher.InvokeAsync(() => ResetAnswerButtonColors());
    }

    private void RestartButton_Click(object sender, RoutedEventArgs e)
    {
        Dispatcher.InvokeAsync(() => ResetAnswerButtonColors());
    }

    private void UpdateAnswerButtonColors()
    {
        if (!VM.Answered) return;

        var buttons = AnswerButtons;
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == VM.CorrectAnswer)
            {
                buttons[i].Background = CorrectBg;
                buttons[i].BorderBrush = CorrectBorder;
                buttons[i].Foreground = Brushes.White;
            }
            else if (i == VM.SelectedAnswer && VM.SelectedAnswer != VM.CorrectAnswer)
            {
                buttons[i].Background = IncorrectBg;
                buttons[i].BorderBrush = IncorrectBorder;
                buttons[i].Foreground = Brushes.White;
            }
        }
    }

    private void ResetAnswerButtonColors()
    {
        foreach (var btn in AnswerButtons)
        {
            btn.Background = DefaultBg;
            btn.BorderBrush = DefaultBorder;
            btn.Foreground = new SolidColorBrush(Color.FromRgb(224, 224, 224));
        }
    }
}
