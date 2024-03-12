namespace WebSalesSystem.Shared.API.Contracts;
public class QuestionType(int id, string name) : Enumeration(id, name)
{
    public static readonly QuestionType Ok = new(1, nameof(Ok));
    public static readonly QuestionType OkAndCancel = new(2, nameof(OkAndCancel));
    public static readonly QuestionType YesAndNo = new(3, nameof(YesAndNo));
    public static readonly QuestionType YesNoAndCancel = new(4, nameof(YesNoAndCancel));
}