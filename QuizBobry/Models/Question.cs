namespace QuizBobry.Models;

public class Question
{
    public string Text { get; init; } = string.Empty;
    public string[] Answers { get; init; } = [];
    public int CorrectIndex { get; init; }
    public string Explanation { get; init; } = string.Empty;
}
