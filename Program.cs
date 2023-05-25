class MainClass
{
    public static object Main(string[] args)
    {

        // Welcome message
        Console.WriteLine("Welcome to the Te Reo Maori Quiz!");

        // Ask for name
        Console.Write("What is your name?  \n ");
        string name = Console.ReadLine();

        // Reply With hello + name then delay
        Console.WriteLine("Hello " + name);
        Thread.Sleep(1500);
        Console.Clear();

        // Let the user know that That all answers should be in captials letter for the start of each sentence or A noun or name
        Console.WriteLine("Please note that all answers should have a captial letter for the start of a answer eg. (Like this) not (not like this)\nBut if it is a name please enter there last and first name with a capital letter");
        Thread.Sleep(5000);
        Console.Clear();

        // Ask for level
        Console.WriteLine("Please choose a level: ");
        Console.WriteLine("B for Beginner");
        Console.WriteLine("I for Intermediate");
        Console.WriteLine("H for Hard");
        Console.Write("Your choice: ");
        char level = Console.ReadLine().ToUpper()[0];
        string[] questions;
        int score = 0;

        switch (level)
        {
            case 'B':
                askquestions(name, level);
                break;

            case 'I':
                askquestions(name, level);
                break;

            case 'H':
                askquestions(name, level);
                break;
        }



        static void askquestions(string name, char level)
        {
            {

                // Determine quiz questions based on level
                string[,] Questions;
                switch (level)
                {
                    case "B":
                        Questions = new string[,] {
          { "Hello", "Kia ora" },
          { "Thank you", "Teno koe" },
          { "Goodbye", "Kia ora" },
          { "Yes", "Ae" },
          { "No", "Kao" },
          { "I love you", "Aroha ana ahau ki a koe" }
                        };
                        break;
                    case "I":
                        Questions = new string[,] {
          { "What is your name", "Ko wai to ingoa?" },
          { "Where are you from", "No hea koe?" },
          { "How are you", "Kei te pehea koe?" },
          { "What time is it", "He aha te taima?" },
          { "What is this", "He aha tenei?" },
          { "How old are you", "E hia ou tau?" },
                        };
                        break;
                    case "H":
                        Questions = new string[,] {
          { "What is the Maori name for New Zealand", "Aotearoa" },
          { "What is the name of the longest river in New Zealand", "Waikato River" },
          { "Who is the current Prime Minister of New Zealand", "Chirs Hipkins" },
          { "What is the name of the famous Maori haka", "Ka Mate" },
          { "Who was the first Maori astronaut to go to space", "Mana Vautier" },
          { "What is the Maori word for love", "Aroha" },
                        };
                        break;
                    default:
                        Console.WriteLine("Invalid level selection. Please select B, I, or H.");
                        return;

                }

            }
            // Ask questions
            for (int i = 0; i < questions.GetLength(0); i++)
            {
                // Ask question
                Console.Write(name + ", what is the Maori translation for '" + questions[i, 0] + "? ");
                string answer = Console.ReadLine();

                // Validate answer
                if (answer == questions[i, 1])
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
                    Console.WriteLine("Incorrect. The correct answer is: " + questions[i, 1]);
                }

                // Delay and clear screen
                Thread.Sleep(3000);
                Console.Clear();
            }

            // Display final score
            Console.WriteLine("Congratulations " + name + ", you finished the quiz!");
            Console.WriteLine("Your final score is: " + score + "/" + questions.GetLength(0));
        }
    }
}
