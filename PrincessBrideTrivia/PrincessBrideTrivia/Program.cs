﻿using System;
using System.IO;

namespace PrincessBrideTrivia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = GetFilePath();
            Question[] questions = LoadQuestions(filePath);
            RandomizeQuestions(questions);
            RandomizeAnswers(questions);
            int numberCorrect = 0;
            for (int i = 0; i < questions.Length; i++)
            {
                bool result = AskQuestion(questions[i]);
                if (result)
                {
                    numberCorrect++;
                }
            }
            Console.WriteLine("You got " + GetPercentCorrect(numberCorrect, questions.Length) + " correct");
        }

        public static string GetPercentCorrect(int numberCorrectAnswers, int numberOfQuestions)
        {
            return ((double)numberCorrectAnswers / numberOfQuestions * 100) + "%";
        }

        public static bool AskQuestion(Question question)
        {
            DisplayQuestion(question);

            string userGuess = GetGuessFromUser();
            return DisplayResult(userGuess, question);
        }

        public static string GetGuessFromUser()
        {
            return Console.ReadLine();
        }

        public static bool DisplayResult(string userGuess, Question question)
        {
            if (userGuess == question.CorrectAnswerIndex)
            {
                Console.WriteLine("Correct");
                return true;
            }

            Console.WriteLine("Incorrect");
            return false;
        }

        public static void DisplayQuestion(Question question)
        {
            Console.WriteLine("Question: " + question.Text);
            for (int i = 0; i < question.Answers.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + question.Answers[i]);
            }
        }

        public static string GetFilePath()
        {
            return "Trivia.txt";
        }

        public static Question[] LoadQuestions(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            Question[] questions = new Question[lines.Length / 5];
            for (int i = 0; i < questions.Length; i++)
            {
                int lineIndex = i * 5;
                string questionText = lines[lineIndex];

                string answer1 = lines[lineIndex + 1];
                string answer2 = lines[lineIndex + 2];
                string answer3 = lines[lineIndex + 3];

                string correctAnswerIndex = lines[lineIndex + 4];

                Question question = new Question();
                question.Text = questionText;
                question.Answers = new string[3];
                question.Answers[0] = answer1;
                question.Answers[1] = answer2;
                question.Answers[2] = answer3;
                question.CorrectAnswerIndex = correctAnswerIndex;
                questions[i] = question;
            }
            return questions;
        }

        public static void RandomizeQuestions(Question[] questions)
        {
            Question tempQuestion;
            int swap;
            Random rand = new Random();
            for(int i = 0; i < questions.Length; i++)
            {
                swap = rand.Next(0, questions.Length - 1);
                tempQuestion = questions[i];
                questions[i] = questions[swap];
                questions[swap] = tempQuestion;
            }
        }

        public static void RandomizeAnswers(Question[] questions)
        {
            string tempAnswer;
            int swap;
            Random rand = new Random();
            foreach(Question question in questions)
            {
                int correctIndex = int.Parse(question.CorrectAnswerIndex) - 1;

                for(int i = 0; i < question.Answers.Length; i++)
                {
                    swap = rand.Next(0, question.Answers.Length - 1);
                    if(i == correctIndex || swap == correctIndex)
                    {
                        correctIndex = (i == correctIndex) ? swap : i;
                        question.CorrectAnswerIndex = (correctIndex + 1).ToString();
                    }
                    tempAnswer = question.Answers[i];
                    question.Answers[i] = question.Answers[swap];
                    question.Answers[swap] = tempAnswer;
                }
            }
        }
    }
}
