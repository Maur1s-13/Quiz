using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Core.Models;

public class Question
{
    public string Text { get; set; }



    public Question(string text)
    {
        Text = text;
    }
}
