public class MainClass
{
    public static void Main()
    {
        // Welcome message
        Console.WriteLine("Welcome to the Te Reo Maori Quiz!");

        string name = getName();

        // Reply With hello + name then delay
        Console.WriteLine("Hello " + name);
        Thread.Sleep(1500);
        Console.Clear();

        string level = chooseLevel(name);
        (int score, int numQuestions) = askQuestions(name, level);
        showResults(name, score, numQuestions);

        static string getName()
        {
            string _name;
            // Ask for name
            Console.Write("What is your name?  \n");
            string? providedName = Console.ReadLine();
            if (providedName?.Length > 0) {
                _name = providedName;
                return _name;
            }
            return getName();
        }

        static string chooseLevel(string name)
        {
            // Ask for level
            Console.WriteLine("Please choose a level:");
            Console.WriteLine("\tB for Beginner");
            Console.WriteLine("\tI for Intermediate");
            Console.WriteLine("\tH for Hard");
            Console.Write("Your choice: ");
            string? _level = Console.ReadLine()?.ToUpper()[0].ToString();

            switch (_level)
            {
                case "B":
                    break;
                case "I":
                    break;
                case "H":
                    break;
                default:
                    Console.WriteLine("Invalid level selection. Please select B, I, or H.");
                    return chooseLevel(name);
            }
            return _level;
        }

        static (int, int) askQuestions(string name, string level)
        {
            int score = 0;

            // Determine quiz questions based on level
            string[,] LocalQuestions = new string[,] { };
            switch (level)
            {
                case "B":
                    LocalQuestions = new string[,] {
                            { "Hello", "Kia ora" },
                            { "Thank you", "Teno koe" },
                            { "Goodbye", "Kia ora" },
                            { "Yes", "Ae" },
                            { "No", "Kao" },
                            { "I love you", "Aroha ana ahau ki a koe" }
                    };
                    break;
                case "I":
                    LocalQuestions = new string[,] {
                            { "What is your name", "Ko wai to ingoa?" },
                            { "Where are you from", "No hea koe?" },
                            { "How are you", "Kei te pehea koe?" },
                            { "What time is it", "He aha te taima?" },
                            { "What is this", "He aha tenei?" },
                            { "How old are you", "E hia ou tau?" },
                    };
                    break;
                case "H":
                    LocalQuestions = new string[,] {
                            { "What is the Maori name for New Zealand", "Aotearoa" },
                            { "What is the name of the longest river in New Zealand", "Waikato River" },
                            { "Who is the current Prime Minister of New Zealand", "Chirs Hipkins" },
                            { "What is the name of the famous Maori haka", "Ka Mate" },
                            { "Who was the first Maori astronaut to go to space", "Mana Vautier" },
                            { "What is the Maori word for love", "Aroha" },
                    };
                    break;
            }

            int questionsCount = LocalQuestions.GetLength(0);

            // Ask questions
            for (int i = 0; i < questionsCount; i++)
            {
                // Ask question
                Console.WriteLine(name + ", what is the Maori translation for '" + LocalQuestions[i, 0] + "?");
                string? answer = Console.ReadLine();

                // Validate answer
                if (answer?.ToUpper() == LocalQuestions[i, 1].ToUpper())
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else if (answer == "" || answer == "" || answer == "")
                {
                    Console.WriteLine("Invalid response. Please provide a valid answer.");
                    i--;
                }
                else
                {
                    Console.WriteLine("Incorrect. The correct answer is: " + LocalQuestions[i, 1]);
                }

                // Delay and clear screen
                Thread.Sleep(1500);
                Console.Clear();
            }

            return (score, questionsCount);
        }

        static void showResults(string name, int score, int numQuestions)
        {
            Console.WriteLine("Congratulations " + name + ", you finished the quiz!");
            Console.WriteLine("Your final score is: " + score + "/" + numQuestions);

            // Display final score
            switch (score) {
                case var _ when score < 1:
                    Console.WriteLine("Better luck next time");
                    break;
                case var _ when score < numQuestions:
                    Console.WriteLine("Good Job, keep going and see if you can ace the test!");
                    break;
                case var _ when score == numQuestions:
                    Console.WriteLine("Well Done!, you aced the test!");
                    break;
            }

        }
    }
}
