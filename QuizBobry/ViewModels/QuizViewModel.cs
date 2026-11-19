using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using QuizBobry.Models;

namespace QuizBobry.ViewModels;

public class QuizViewModel : INotifyPropertyChanged
{
    private readonly List<Question> _questions;
    private int _currentIndex;
    private int _score;
    private bool _answered;
    private int _selectedAnswer = -1;
    private bool _showResults;

    public QuizViewModel()
    {
        _questions = QuestionBank.GetQuestions();
        _currentIndex = 0;
        _score = 0;

        SelectAnswerCommand = new RelayCommand(OnSelectAnswer, _ => !_answered && !_showResults);
        NextQuestionCommand = new RelayCommand(_ => OnNextQuestion(), _ => _answered && !_showResults);
        RestartCommand = new RelayCommand(_ => OnRestart(), _ => _showResults);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    // Commands
    public ICommand SelectAnswerCommand { get; }
    public ICommand NextQuestionCommand { get; }
    public ICommand RestartCommand { get; }

    // Current question data
    public string QuestionText => CurrentQuestion.Text;
    public string AnswerA => $"A.  {CurrentQuestion.Answers[0]}";
    public string AnswerB => $"B.  {CurrentQuestion.Answers[1]}";
    public string AnswerC => $"C.  {CurrentQuestion.Answers[2]}";

    // Progress
    public string ProgressText => $"Pytanie {_currentIndex + 1} z {_questions.Count}";
    public string ScoreText => _answered
        ? $"Wynik: {_score}/{_currentIndex + 1}"
        : (_currentIndex == 0 ? "Wynik: 0/0" : $"Wynik: {_score}/{_currentIndex}");
    public double ProgressValue => (double)_currentIndex / _questions.Count * 100;

    // Answered state
    public bool Answered
    {
        get => _answered;
        private set { _answered = value; OnPropertyChanged(); }
    }

    public int SelectedAnswer
    {
        get => _selectedAnswer;
        private set { _selectedAnswer = value; OnPropertyChanged(); }
    }

    public int CorrectAnswer => CurrentQuestion.CorrectIndex;
    public bool IsCorrect => _selectedAnswer == CurrentQuestion.CorrectIndex;

    public string FeedbackIcon => IsCorrect ? "✅" : "❌";
    public string FeedbackTitle => IsCorrect ? "Brawo!" : "Niestety, zła odpowiedź.";
    public string FeedbackExplanation => CurrentQuestion.Explanation;

    public string NextButtonText => _currentIndex >= _questions.Count - 1 ? "Zobacz wynik  🏆" : "Następne pytanie  →";

    // Results
    public bool ShowResults
    {
        get => _showResults;
        private set { _showResults = value; OnPropertyChanged(); }
    }

    public bool ShowQuiz => !_showResults;
    public int FinalScore => _score;
    public int TotalQuestions => _questions.Count;
    public int FinalPercentage => (int)Math.Round((double)_score / _questions.Count * 100);

    public string ResultEmoji => FinalPercentage switch
    {
        100 => "🏆🦫",
        >= 80 => "🌟🦫",
        >= 60 => "👍🦫",
        >= 40 => "📚🦫",
        _ => "🤔🦫"
    };

    public string ResultMessage => FinalPercentage switch
    {
        100 => "Perfekcyjny wynik! Jesteś ekspertem od bobrów!",
        >= 80 => "Świetny wynik! Znasz się na bobrach bardzo dobrze!",
        >= 60 => "Dobry wynik! Wiesz sporo o bobrach!",
        >= 40 => "Niezły początek! Warto doczytać o bobrach!",
        _ => "Bobry mają jeszcze wiele tajemnic — czas je odkryć!"
    };

    public string ResultDetail => $"Poprawne odpowiedzi: {_score} z {_questions.Count}";

    private Question CurrentQuestion => _questions[_currentIndex];

    private void OnSelectAnswer(object? parameter)
    {
        if (parameter is not string indexStr || !int.TryParse(indexStr, out int index))
            return;

        SelectedAnswer = index;
        if (index == CurrentQuestion.CorrectIndex)
            _score++;

        Answered = true;
        NotifyAll();
    }

    private void OnNextQuestion()
    {
        _currentIndex++;
        if (_currentIndex >= _questions.Count)
        {
            ShowResults = true;
            NotifyAll();
            return;
        }

        Answered = false;
        SelectedAnswer = -1;
        NotifyAll();
    }

    private void OnRestart()
    {
        _currentIndex = 0;
        _score = 0;
        _selectedAnswer = -1;
        Answered = false;
        ShowResults = false;
        NotifyAll();
    }

    private void NotifyAll()
    {
        OnPropertyChanged(nameof(QuestionText));
        OnPropertyChanged(nameof(AnswerA));
        OnPropertyChanged(nameof(AnswerB));
        OnPropertyChanged(nameof(AnswerC));
        OnPropertyChanged(nameof(ProgressText));
        OnPropertyChanged(nameof(ScoreText));
        OnPropertyChanged(nameof(ProgressValue));
        OnPropertyChanged(nameof(Answered));
        OnPropertyChanged(nameof(SelectedAnswer));
        OnPropertyChanged(nameof(CorrectAnswer));
        OnPropertyChanged(nameof(IsCorrect));
        OnPropertyChanged(nameof(FeedbackIcon));
        OnPropertyChanged(nameof(FeedbackTitle));
        OnPropertyChanged(nameof(FeedbackExplanation));
        OnPropertyChanged(nameof(NextButtonText));
        OnPropertyChanged(nameof(ShowResults));
        OnPropertyChanged(nameof(ShowQuiz));
        OnPropertyChanged(nameof(FinalScore));
        OnPropertyChanged(nameof(FinalPercentage));
        OnPropertyChanged(nameof(ResultEmoji));
        OnPropertyChanged(nameof(ResultMessage));
        OnPropertyChanged(nameof(ResultDetail));
    }

    private void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
