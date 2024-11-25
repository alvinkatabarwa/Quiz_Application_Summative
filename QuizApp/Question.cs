// Question.cs
namespace QuizApp
{
    public class Question
    {
        public string QuestionText { get; set; }
        public string[] Options { get; set; }
        public int CorrectAnswer { get; set; }
        public int Weight { get; set; }

        public Question(string questionText, string[] options, int correctAnswer, int weight)
        {
            QuestionText = questionText;
            Options = options;
            CorrectAnswer = correctAnswer;
            Weight = weight;
        }
    }
}
