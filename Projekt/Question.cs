using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Projekt
{
    public class Question
    {
        private String content;
        private String[] answers = new String[5];
        private int correctAnswer;
        private int category;

        public Question(int cat, String content, String ansver1, String ansver2, String ansver3, String ansver4, int correctAnsver)
        {
            this.category = cat;
            this.content = content;
            this.answers[1] = ansver1;
            this.answers[2] = ansver2;
            this.answers[3] = ansver3;
            this.answers[4] = ansver4;
            this.correctAnswer = correctAnsver;
        }

        public int getCat()
        {
            return this.category;
        }

        public String getQuestionContent(){
            return this.content;
        }

        public String getQuestionAnswer(int n){
            return this.answers[n];
        }

        public String getCorrectAnswer()
        {
            return this.answers[correctAnswer]; 
        }

        public int getCorrectAnswerNum()
        {
            return this.correctAnswer;
        }

    }
}
