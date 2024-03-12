namespace WebSalesSystem.Shared.API.Contracts;
public class Question
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? QuestionType { get; set; }
    public ICollection<QuestionAnswers> Answers { get; set; } = new List<QuestionAnswers>();
    public int? NextOnConfirm { get; set; }
    public int? NextOnDecline { get; set; }
    public bool ContinueOnCancel { get; set; }
    public int AnswerOnCancel { get; set; }
    public int Answer { get; set; }

    public Question() { }

    public Question(string? title, string? description, QuestionType questionType, Question? nextOnConfirm, Question? nextOnDecline, bool continueOnCancel, int answerOnCancel) 
    {
        Title = title;
        Description = description;
        QuestionType = questionType.ToString();
        GetAnswersValue(questionType);
        NextOnConfirm = nextOnConfirm?.Id;
        NextOnDecline = nextOnDecline?.Id;      
        ContinueOnCancel = continueOnCancel;
        AnswerOnCancel = answerOnCancel;
    }

    private void GetAnswersValue(QuestionType questionType)
    {
        switch (questionType.Name)
        {
            case "OkAndCancel":
                Answers.Add(QuestionAnswers.Ok);
                Answers.Add(QuestionAnswers.Cancel);
                break;
            case "YesAndNo":
                Answers.Add(QuestionAnswers.Yes);
                Answers.Add(QuestionAnswers.No);
                break;
            case "YesNoAndCancel":
                Answers.Add(QuestionAnswers.Yes);
                Answers.Add(QuestionAnswers.No);
                Answers.Add(QuestionAnswers.Cancel);
                break;
            default:
                Answers.Add(QuestionAnswers.Ok);
                break;
        }
    }
}