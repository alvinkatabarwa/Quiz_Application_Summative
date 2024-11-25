// Quiz.cs
using System.Collections.Generic;

namespace QuizApp
{
    public class Quiz
    {
        public string QuizName { get; set; }
        public List<Question> Questions { get; set; }

        public Quiz(string quizName)
        {
            QuizName = quizName;
            Questions = new List<Question>();
        }

        // Method to add questions to the quiz
        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }
    }
}
