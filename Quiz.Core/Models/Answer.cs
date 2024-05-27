using Quiz.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Core.Models;

public class Answer : IAnswer
{
    public bool IsTrue { get; set; } = false;

    public string Text { get; set; }    

    public Answer(string text, bool isTrue)
    {
        this.Text = text;
        this.IsTrue = isTrue;

    }

    public Answer(string text) : this(text, false)
    {
            
    }

}
