using Quiz.Core;

namespace Quiz.Cli;

public class HistoryQuestionProvider : IQuestionProvider
{   

    public string Base64EncodedImage
    {
        get
        {
            return "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";
        }
    }

    public string Topic => "History(KI)";

    public List<Question> GetQuestions(int num)
    {
        List<Question> _questions = new List<Question>();

        // Question 1
        Question q1 = new("In welchem Jahr fand die Schlacht von Hastings statt?");
        q1.AddAnswer(new Answer("1066", true));
        q1.AddAnswer(new Answer("878"));
        q1.AddAnswer(new Answer("1215"));
        q1.AddAnswer(new Answer("1453"));
        _questions.Add(q1);

        // Question 2
        Question q2 = new("Wer war der erste römische Kaiser?");
        q2.AddAnswer(new Answer("Augustus", true));
        q2.AddAnswer(new Answer("Julius Caesar"));
        q2.AddAnswer(new Answer("Nero"));
        q2.AddAnswer(new Answer("Tiberius"));
        _questions.Add(q2);

        // Question 3
        Question q3 = new("In welchem Jahr begann der Zweite Weltkrieg?");
        q3.AddAnswer(new Answer("1939", true));
        q3.AddAnswer(new Answer("1914"));
        q3.AddAnswer(new Answer("1941"));
        q3.AddAnswer(new Answer("1945"));
        _questions.Add(q3);

        // Question 4
        Question q4 = new("Wer entdeckte Amerika 1492?");
        q4.AddAnswer(new Answer("Christoph Kolumbus", true));
        q4.AddAnswer(new Answer("Ferdinand Magellan"));
        q4.AddAnswer(new Answer("Leif Erikson"));
        q4.AddAnswer(new Answer("James Cook"));
        _questions.Add(q4);

        // Question 5
        Question q5 = new("Wer war der erste Präsident der Vereinigten Staaten?");
        q5.AddAnswer(new Answer("George Washington", true));
        q5.AddAnswer(new Answer("Thomas Jefferson"));
        q5.AddAnswer(new Answer("John Adams"));
        q5.AddAnswer(new Answer("James Madison"));
        _questions.Add(q5);

        // Question 6
        Question q6 = new("In welchem Jahr fiel die Berliner Mauer?");
        q6.AddAnswer(new Answer("1989", true));
        q6.AddAnswer(new Answer("1961"));
        q6.AddAnswer(new Answer("1975"));
        q6.AddAnswer(new Answer("1991"));
        _questions.Add(q6);

        // Question 7
        Question q7 = new("Wer war der Führer der Sowjetunion während des Zweiten Weltkriegs?");
        q7.AddAnswer(new Answer("Joseph Stalin", true));
        q7.AddAnswer(new Answer("Vladimir Lenin"));
        q7.AddAnswer(new Answer("Nikita Chruschtschow"));
        q7.AddAnswer(new Answer("Leonid Breschnew"));
        _questions.Add(q7);

        // Question 8
        Question q8 = new("In welchem Jahr begann der Erste Weltkrieg?");
        q8.AddAnswer(new Answer("1914", true));
        q8.AddAnswer(new Answer("1918"));
        q8.AddAnswer(new Answer("1939"));
        q8.AddAnswer(new Answer("1945"));
        _questions.Add(q8);

        // Question 9
        Question q9 = new("Wer war die Königin von England während der spanischen Armada 1588?");
        q9.AddAnswer(new Answer("Elisabeth I.", true));
        q9.AddAnswer(new Answer("Maria I."));
        q9.AddAnswer(new Answer("Victoria"));
        q9.AddAnswer(new Answer("Anne"));
        _questions.Add(q9);

        // Question 10
        Question q10 = new("In welchem Jahr wurde die Unabhängigkeitserklärung der USA unterzeichnet?");
        q10.AddAnswer(new Answer("1776", true));
        q10.AddAnswer(new Answer("1783"));
        q10.AddAnswer(new Answer("1812"));
        q10.AddAnswer(new Answer("1865"));
        _questions.Add(q10);

        // Question 11
        Question q11 = new("Wer führte die Französische Revolution an?");
        q11.AddAnswer(new Answer("Maximilien Robespierre", true));
        q11.AddAnswer(new Answer("Napoleon Bonaparte"));
        q11.AddAnswer(new Answer("Louis XVI"));
        q11.AddAnswer(new Answer("Marie Antoinette"));
        _questions.Add(q11);

        // Question 12
        Question q12 = new("In welchem Jahr wurde die Magna Carta unterzeichnet?");
        q12.AddAnswer(new Answer("1215", true));
        q12.AddAnswer(new Answer("1066"));
        q12.AddAnswer(new Answer("1492"));
        q12.AddAnswer(new Answer("1666"));
        _questions.Add(q12);

        // Question 13
        Question q13 = new("Wer war der erste Kaiser des Heiligen Römischen Reiches?");
        q13.AddAnswer(new Answer("Karl der Große", true));
        q13.AddAnswer(new Answer("Otto I."));
        q13.AddAnswer(new Answer("Friedrich I."));
        q13.AddAnswer(new Answer("Heinrich IV."));
        _questions.Add(q13);

        // Question 14
        Question q14 = new("In welchem Jahr fand die Reformation statt?");
        q14.AddAnswer(new Answer("1517", true));
        q14.AddAnswer(new Answer("1453"));
        q14.AddAnswer(new Answer("1492"));
        q14.AddAnswer(new Answer("1618"));
        _questions.Add(q14);

        // Question 15
        Question q15 = new("Wer war der Anführer der Hunnen, der Rom bedrohte?");
        q15.AddAnswer(new Answer("Attila", true));
        q15.AddAnswer(new Answer("Genghis Khan"));
        q15.AddAnswer(new Answer("Tamerlan"));
        q15.AddAnswer(new Answer("Alarich"));
        _questions.Add(q15);

        // Question 16
        Question q16 = new("In welchem Jahr fand die Russische Revolution statt?");
        q16.AddAnswer(new Answer("1917", true));
        q16.AddAnswer(new Answer("1905"));
        q16.AddAnswer(new Answer("1939"));
        q16.AddAnswer(new Answer("1945"));
        _questions.Add(q16);

        // Question 17
        Question q17 = new("Wer war der Premierminister von Großbritannien während des Zweiten Weltkriegs?");
        q17.AddAnswer(new Answer("Winston Churchill", true));
        q17.AddAnswer(new Answer("Neville Chamberlain"));
        q17.AddAnswer(new Answer("Clement Attlee"));
        q17.AddAnswer(new Answer("Margaret Thatcher"));
        _questions.Add(q17);

        // Question 18
        Question q18 = new("In welchem Jahr endete der Zweite Weltkrieg?");
        q18.AddAnswer(new Answer("1945", true));
        q18.AddAnswer(new Answer("1944"));
        q18.AddAnswer(new Answer("1946"));
        q18.AddAnswer(new Answer("1950"));
        _questions.Add(q18);

        // Question 19
        Question q19 = new("Wer war der letzte Zar von Russland?");
        q19.AddAnswer(new Answer("Nikolaus II.", true));
        q19.AddAnswer(new Answer("Alexander III."));
        q19.AddAnswer(new Answer("Peter der Große"));
        q19.AddAnswer(new Answer("Iwan der Schreckliche"));
        _questions.Add(q19);

        // Question 20
        Question q20 = new("Wer war der britische Entdecker, der Australien entdeckte?");
        q20.AddAnswer(new Answer("James Cook", true));
        q20.AddAnswer(new Answer("Francis Drake"));
        q20.AddAnswer(new Answer("Henry Hudson"));
        q20.AddAnswer(new Answer("Walter Raleigh"));
        _questions.Add(q20);

        List<Question> list = new List<Question>();

        

        for (int i = 0; i < num; i++)
        {
            Random random = new Random();
            int gen = random.Next(0, _questions.Count());
            list.Add(_questions[gen]);
        }

        return list;

    }



}
