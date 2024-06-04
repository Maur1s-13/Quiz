using Quiz.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Cli;

public class HistoryQuestionProvider(IAnswer answer) : IQuestionProvider
{
    
        

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
            list.Add(_questions[i]);
        }

        return list;

    }



}
