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
using System.Collections.Generic;

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

        public String getQuestionContent()
        {
            return this.content;
        }

        public String getQuestionAnswer(int n)
        {
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

    public class QDB
    {
        App thisApp = Application.Current as App;

        private List<Question> s1 = new List<Question>();
        private List<Question> s2 = new List<Question>();
        private List<Question> s3 = new List<Question>();

        public QDB()
        {
            // Category 1 - Geography 
            s1.Add(new Question(1, "Which city is the capital of United Kingdom?", "Belfast", "Cardiff", "London", "Edinburgh", 3));
            s1.Add(new Question(1, "Which mountain is the Earth's heigest mountain?", "Mount Blanc", "Mount Everest", "K1", "Makalu", 2));
            s1.Add(new Question(1, "How many percents of the Earth's surface is covered by the wather?", "between 68 and 69", "between 69 and 70", "between 70 nad 71", "between 71 and 72", 3));
            s2.Add(new Question(1, "Madagascar island lies in the...", "Indian Ocean", "Pacific Ocean", "Southern Ocean", "", 1));
            s2.Add(new Question(1, "What is the elevation height of K2 mountain?", "8,811 m", "8,611 m", "8,711", "", 2));
            s3.Add(new Question(1, "The world's tallest waterfall is...", "Angel Falls", "Tugela Falls", "", "", 1));

            // Category 2 - Exact sciences
            s1.Add(new Question(2, "How many degrees contains a full angle?", "90", "180", "360", "720", 3));
            s1.Add(new Question(2, "Pythagorean theorem is about...", "triangles", "squares", "circles", "polygons", 1));
            s1.Add(new Question(2, "Ten meters per secound eguals...", "10 km/h", "18 km/h", "36 km/h", "48 km/h", 3));
            s2.Add(new Question(2, "Which planet in Solar System is the largest (but Sun)?", "Saturn", "Jupiter", "Uranus", "", 2));
            s2.Add(new Question(2, "one cubic meter equals...", "10 liters", "100 liters", "1000 liters", "", 3));
            s3.Add(new Question(2, "How many bits contains IPv4 addres?", "32", "64", "", "", 1));

            // Category 3 - Music & art
            s1.Add(new Question(3, "Freddie Mercury was a lider of...", "Rolling Stones", "Pink Floyd", "Led Zeppelin", "Queen", 4));
            s1.Add(new Question(3, "Finish band's name: Jackson ...", "Four", "Five", "Six", "Seven", 2));
            s1.Add(new Question(3, "Who has painted the Mona Lisa?", "Claude Monet", "Vinente Van Ghog", "Leonardo Da Vinci", "Rembrandt van Rijn", 3));
            s2.Add(new Question(3, "David was sculped by...", "Michelangelo", "Leonardo Da Vinci", "Auguste Rodin", "", 1));
            s2.Add(new Question(3, "Who is a lider of Mettalica?", "Kirk Hammett", "James Hetfield", "Lars Ulrich", "", 2));
            s3.Add(new Question(3, "Who has designed the Sydney Opera House building?", "Donald Crone", "Jorn Utzon", "", "", 2));

            // Category 4 - Sport
            s1.Add(new Question(4, "Erick Cantona has played in...", "Manchaster United", "Arsenal", "Newcastle", "Liverpool", 1));
            s1.Add(new Question(4, "What is the distance of marathon?", "42,095 km", "42,155 km", "42,195 km", "42,225 km", 3));
            s1.Add(new Question(4, "First Summer Olympic Games held in...", "1896", "1900", "1904", "1908", 1));
            s2.Add(new Question(4, "How many times Nicki Pedersen was Speedway Grand Prix Champion?", "Two", "Three", "Four", "", 2));
            s2.Add(new Question(4, "How many times did Sergey Bubka break a world record in pole vaulting (indoor and outdoor)?", "25", "35", "45", "", 2));
            s3.Add(new Question(4, "How many goals did Andriy Schevchenko scores for AC Milan?", "175", "183", "", "", 1));
            
            // Category 5 - History
            s1.Add(new Question(5, "In which year did World War I end?", "1914", "1915", "1918", "1919", 3));
            s1.Add(new Question(5, "When did World War II end?", "October 1st, 1945", "October 2nd, 1945", "September 1st, 1945", "September 2nd, 1945", 4));
            s1.Add(new Question(5, "How many years did Hundred Years' War last?", "100", "107", "113", "115", 3));
            s2.Add(new Question(5, "In which century did The Battle of Vienna take place?", "17th", "18th", "16th", "", 1));
            s2.Add(new Question(5, "In which battle did Erwin Rommel fight agains Bernard L. Montgomery in 1942?", "First Battle of El Alamein", "Second Battle of El Alamein", "Third Battle of El Alamein", "", 2));
            s3.Add(new Question(5, "Prohibition was instituted with ratification of the Eighteenth Amendment to the United States Constitution in...", "1919", "1929", "", "", 1));
            
            // Category 6 - Biology 
            s1.Add(new Question(6, "What is the name of red blood cells?", "Thrombocytes", "Blood plasma", "Leukocytes", "Erythrocytes", 4));
            s1.Add(new Question(6, "Which animal is World's largest?", "Elephant", "Whale", "Elephant Seal", "Hippo", 2));
            s1.Add(new Question(6, "Penicillin was discovered by...", "Frederick Banting", "Robert Koch", "Alexander Fleming", "Alfred Nobel", 3));
            s2.Add(new Question(6, "How many chromosomes contains a human's DNA?", "44", "46", "48", "", 2));
            s2.Add(new Question(6, "Which of thoes animals is not a mammal?", "Dolphin", "Shark", "Whale", "", 2));
            s3.Add(new Question(6, "Glioma attacks a tissue of...", "Brain", "Nerves", "", "", 1));
            
        }

        public Question[] getQuestions()
        {
            Random random = new Random();

            int[] CatCheck = new int[7];

            Question[] q1 = new Question[s1.Count];
            Question[] q2 = new Question[s2.Count];
            Question[] q3 = new Question[s3.Count]; 

            int[] qc1 = new int[s1.Count];
            int[] qc2 = new int[s2.Count];
            int[] qc3 = new int[s3.Count];

            s1.CopyTo(q1);
            s2.CopyTo(q2);
            s3.CopyTo(q3);

            if (thisApp.setData.Cat1 == true) { CatCheck[1] = 1; }
            if (thisApp.setData.Cat2 == true) { CatCheck[2] = 1; }
            if (thisApp.setData.Cat3 == true) { CatCheck[3] = 1; }
            if (thisApp.setData.Cat4 == true) { CatCheck[4] = 1; }
            if (thisApp.setData.Cat5 == true) { CatCheck[5] = 1; }
            if (thisApp.setData.Cat6 == true) { CatCheck[6] = 1; }

            Boolean state;
            int n;

            Question[] randomQuestions = new Question[9];

            // randomize Stage One guestions
            for (int i = 1; i < 5; i++)
            {
                state = true;
                while (state)
                {
                    n = random.Next(0, s1.Count);
                    if (qc1[n] != 1 && CatCheck[q1[n].getCat()] != 1)
                    {
                        randomQuestions[i] = q1[n];
                        qc1[n] = 1;
                        state = false;
                    }
                }
            }
            // randomize Stage Two questions
            for (int i = 5; i < 8; i++)
            {
                state = true;
                while (state)
                {
                    n = random.Next(0, s2.Count);
                    if (qc2[n] != 1 && CatCheck[q2[n].getCat()] != 1)
                    {
                        randomQuestions[i] = q2[n];
                        qc2[n] = 1;
                        state = false;
                    }
                }
            }
            // randomize Final Stage question
            state = true;
            while (state)
            {
                n = random.Next(0, s3.Count);
                if (qc3[n] != 1 && CatCheck[q3[n].getCat()] != 1)
                {
                    randomQuestions[8] = q3[n];
                    qc3[n] = 1;
                    state = false;
                }
            }

            return randomQuestions;
        }
    }
}
