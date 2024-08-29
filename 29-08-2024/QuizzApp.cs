using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    internal class Program
    {
        enum Options
        {
            Option1 = 1,
            Option2 = 2,
            Option3 = 3,
            Option4 = 4
        }
        class Question
        {
            public string Description { get; set; }
            public string[] options = new string[4];
            public Options RightAnswer { get; set; }
            public void AddQuestion()
            {
                Console.WriteLine("Enter the description");
                Description = Console.ReadLine();
                Console.WriteLine("Enter the options");
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"Enter option{i + 1}");
                    options[i] = Console.ReadLine();
                }
                Console.WriteLine("Enter the right option");
                RightAnswer = (Options)int.Parse(Console.ReadLine());

            }

        }

        class Quiz
        {
            private int Score { get; set; } = 0;
            public void AttempTest(Question[] questions)
            {
                
                    foreach (Question question in questions)
                    {
                        Console.WriteLine(question.Description);
                        for (int j = 0; j < question.options.Length; j++)
                        {
                            Console.WriteLine(question.options[j]);
                        }
                        Console.WriteLine("Enter the answer");
                        Options answer = (Options)int.Parse(Console.ReadLine());

                    if(question.RightAnswer == answer)
                    {
                        Score++;
                    }
                    }

                Console.WriteLine($"Your score is {Score}");

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of questions");
            int N = int.Parse(Console.ReadLine());
            Question[] questions = new Question[N];

            for(int i = 0;i < N; i++)
            {
                Question question = new Question();
                question.AddQuestion();
                questions[i] = question;

            }

            Console.WriteLine("Take  quizzzz----------------------------");

            Quiz quiz = new Quiz();
            quiz.AttempTest(questions);

        }
    }
}
