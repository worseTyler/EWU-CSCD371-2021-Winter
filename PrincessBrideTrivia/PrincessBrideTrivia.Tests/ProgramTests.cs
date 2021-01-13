using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
//using System;

namespace PrincessBrideTrivia.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void LoadQuestions_RetrievesQuestionsFromFile()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                // Arrange
                GenerateQuestionsFile(filePath, 2);

                // Act
                Question[] questions = Program.LoadQuestions(filePath);

                // Assert 
                Assert.AreEqual(2, questions.Length);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [TestMethod]
        public void LoadQuestions_IsNotNull()
        {
            // This part was mean
            string filePath = Path.GetRandomFileName();
            try
            {
                
                // Arrange
                GenerateQuestionsFile(filePath, 7);
                // Act
                Question[] questions = Program.LoadQuestions(filePath);
                // Assert
                foreach (Question question in questions)
                {
                    Assert.IsNotNull(question);
                }
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [DataTestMethod]
        [DataRow("1", true)]
        [DataRow("2", false)]
        public void DisplayResult_ReturnsTrueIfCorrect(string userGuess, bool expectedResult)
        {
            // Arrange
            Question question = new Question();
            question.CorrectAnswerIndex = "1";

            // Act
            bool displayResult = Program.DisplayResult(userGuess, question);

            // Assert
            Assert.AreEqual(expectedResult, displayResult);
        }

        [TestMethod]
        public void GetFilePath_ReturnsFileThatExists()
        {
            // Arrange

            // Act
            string filePath = Program.GetFilePath();

            // Assert
            Assert.IsTrue(File.Exists(filePath));
        }

        [DataTestMethod]
        [DataRow(1, 1, "100%")]
        [DataRow(5, 10, "50%")]
        [DataRow(1, 10, "10%")]
        [DataRow(0, 10, "0%")]
        public void GetPercentCorrect_ReturnsExpectedPercentage(int numberOfCorrectGuesses, 
            int numberOfQuestions, string expectedString)
        {
            // Arrange

            // Act
            string percentage = Program.GetPercentCorrect(numberOfCorrectGuesses, numberOfQuestions);

            // Assert
            Assert.AreEqual(expectedString, percentage);
        }

        [TestMethod]
        public void RandomizeQuestions_MakeDifferentOrder()
        {
            // Arrange
            int numSame = 0;
            string filePath = Program.GetFilePath();
            Question[] randomOne = Program.LoadQuestions(filePath);
            Question[] randomTwo = Program.LoadQuestions(filePath);

            // Act
            Program.RandomizeQuestions(randomOne);
            Program.RandomizeQuestions(randomTwo);

            // Assert
            for(int i = 0; i < randomOne.Length; i++)
            {
                if (randomOne[i].Text == randomTwo[i].Text)
                    numSame++;
            }
            if (numSame == randomOne.Length)
                Assert.Fail();
        }
        [TestMethod]
        public void TestingAssertAreNotEqaul()
        {
            string filePath = Program.GetFilePath();
            string[] one = new string[] { "123" };
            string[] two = new string[] { "123" };

            Assert.AreNotEqual(one, two);
        }
        private static void GenerateQuestionsFile(string filePath, int numberOfQuestions)
        {
            for (int i = 0; i < numberOfQuestions; i++)
            {
                string[] lines = new string[5];
                lines[0] = "Question " + i + " this is the question text";
                lines[1] = "Answer 1";
                lines[2] = "Answer 2";
                lines[3] = "Answer 3";
                lines[4] = "2";
                File.AppendAllLines(filePath, lines);
            }
        }
        [TestMethod]
        public void RandomizeAnswers_ChangeOrderOfAnswers()
        {
            // Arrange
            int numSame = 0;
            string filePath = Program.GetFilePath();
            Question[] randomOne = Program.LoadQuestions(filePath);
            Question[] randomTwo = Program.LoadQuestions(filePath);

            // Act
            Program.RandomizeAnswers(randomOne);
            Program.RandomizeAnswers(randomTwo);

            // Assert

            for (int i = 0; i < randomOne.Length; i++)
            {
                if (randomOne[i].Answers[0] == randomTwo[i].Answers[0] &&
                    randomOne[i].CorrectAnswerIndex == randomTwo[i].CorrectAnswerIndex)
                    numSame++;
            }
            if (numSame == randomOne.Length)
                Assert.Fail();
        }

        [TestMethod]
        public void RandomizeAnswers_CorrectAnswerIndexCorrect()
        {
            // Arrange
            string filePath = Program.GetFilePath();
            Question[] random = Program.LoadQuestions(filePath);
            string[] correctAnswers = new string[random.Length];
            for(int i = 0; i < correctAnswers.Length; i++)
            {
                int correctAnswerIndex = int.Parse(random[i].CorrectAnswerIndex) - 1;
                correctAnswers[i] = random[i].Answers[correctAnswerIndex];
            }

            // Act
            Program.RandomizeAnswers(random);

            // Assert
            for(int i = 0; i < random.Length; i++)
            {
                int correctAnswerIndex = int.Parse(random[i].CorrectAnswerIndex) - 1;
                Assert.AreEqual(correctAnswers[i], random[i].Answers[correctAnswerIndex]);
            }
        }
    }
}
