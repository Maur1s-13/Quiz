using Quiz.Cli;
using Quiz.Core;
using System;


Game game = new Game("Wer gewinnt?");

Player eins = new Player(5, "Manfred");
Player zwei = new Player(2, "Hans");
Player drei = new Player(3, "Daniela");
Player vier = new Player(4, "Frieda");

IQuestionProvider stats = new StaticQuestions();
IQuestionProvider historyQuestionProvider = new HistoryQuestionProvider();


game.AddRound(stats, true, 3);
game.AddRound(historyQuestionProvider, true, 3);


game.AddPlayerToLatestRound(eins);
game.AddPlayerToLatestRound(zwei);
game.AddPlayerToLatestRound(drei);
game.AddPlayerToLatestRound(vier);

GameRound round = game.GetLatestRound();
round.Start();

Console.WriteLine("All players in this round:");
foreach (Player p in round.Players)
{
    Console.WriteLine(p.Name);
}

while (round.MoveNext())
{
    // start game for this player

    // get current play
    Play currentPlay = round.Current;

    // start play
    currentPlay.Start();


    Console.WriteLine($"Spieler: {currentPlay.Player.Name}");

    while (currentPlay.IsActive)
    {

        while (currentPlay.MoveNext())
        {

            Question question = currentPlay.Current;


            Console.WriteLine("Frage: " + question.Text);

            int num = 0;
            foreach (IAnswer a in question.Answers)
            {
                Console.WriteLine($"{num}. {a.Text}");
                num++;
            }

            Console.Write("Auswahl: ");
            int input = Convert.ToInt32(Console.ReadLine());

            question.Answers[input].IsChecked = true;

            var res = currentPlay.ValidateCurrentQuestion();

            if (!res)
            {
                Console.WriteLine("Leider war das eine falsche Antwort");
            }
            else
            {
                Console.WriteLine("Das war die richitige Antwort");
            }

        }
        Console.WriteLine("Gewonnen hat:");
        Console.WriteLine($"{round.BestPlay().Player.Name} mit Level {round.BestPlay().Level}");
    }

}