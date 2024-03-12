namespace WebSalesSystem.Shared.API.Contracts;
public class QuestionAnswers(int id, string name) : Enumeration(id, name)
{
    public static readonly QuestionAnswers Ok = new(1, nameof(Ok));
    public static readonly QuestionAnswers Yes = new(2, nameof(Yes));
    public static readonly QuestionAnswers No = new(3, nameof(No));
    public static readonly QuestionAnswers Cancel = new(4, nameof(Cancel));
}