using System;
using System.Windows.Forms;

namespace QuizApp

/// <summary>
/// form for the Quiz Application.
/// Handles user interaction, question display, and score tracking.
/// </summary>
{
    public partial class Form1 : Form // form1 inherits properties from its parent class form
    {
        // variables for the quiz
        int correctAnswer;
        int questionNumber = 1;
        int score;
        int percentage;
        int totalQuestions;

        public Form1()
        {
            InitializeComponent();
            totalQuestions = 8;
            score = 0; // score when the quiz gets initialized
            askQuestion(questionNumber);

        }
        /// <summary>
        /// Handles the event when an answer button is clicked.
        /// Validates the answer and progresses to the next question or ends the quiz.
        /// </summary>
        /// <param name="sender">The button clicked by the user.</param>
        /// <param name="e">Event arguments for the click event.</param>
        private void checkAnswerEvent(object sender, EventArgs e)
        {
            try
            {
                var senderObject = (Button)sender;
                int buttonTag = Convert.ToInt32(senderObject.Tag);

                // Checking if the answer is correct
                if (buttonTag == correctAnswer)
                {
                    score++; // Increment the score for a correct answer everytime a new answer is correct 
                    senderObject.BackColor = System.Drawing.Color.Green; // Change color to green if correct
                }
                else
                {
                    senderObject.BackColor = System.Drawing.Color.Red; // Change color to red if incorrect
                }

                // timer so that the quiz "waits" 1 second so you can see the validity of your answer
                Timer timer = new Timer();
                timer.Interval = 1000; // Wait 1 second before moving to the next question
                timer.Tick += (s, tickEventArgs) =>
                {
                    try
                    {
                        timer.Stop(); // Stop the timer after it ticks
                                      
                        senderObject.BackColor = System.Drawing.Color.White; //button color reset to white as we move to next question

                        // Checking if we've reached the last question
                        if (questionNumber == totalQuestions)
                        {
                            // Calculate the percentage score
                            percentage = (int)Math.Round((double)(score * 100 / totalQuestions));

                            // Display the final score
                            MessageBox.Show(
                                "Quiz Completed " + Environment.NewLine +
                                "You Answered " + score + "/" + totalQuestions + " Questions Right." + Environment.NewLine +
                                "You Scored  " + percentage + "%" + Environment.NewLine +
                                "Click Ok to Replay this quiz "
                            );

                            // Reset for a new quiz
                            score = 0; // Reset score
                            questionNumber = 1; // Reset to first question
                            askQuestion(questionNumber); // Start from the first question again
                        }
                        else
                        {
                            // Move to the next question
                            questionNumber++;
                            askQuestion(questionNumber);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Catch any exceptions during question progression
                        MessageBox.Show($"An error occurred while moving to the next question: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                timer.Start(); // Start the timer
            }
            catch (Exception ex)
            {
                // Catch any unexpected exceptions and show a meaningful message
                MessageBox.Show($"An error occurred while checking the answer: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Displays the question corresponding to the given question number.
        /// </summary>
        /// <param name="qnum">The question number to display.</param>

        private void askQuestion(int qnum) //method to present users with a question "int qnum" is the question number
        {
            switch (qnum)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.atla_social_1200x627;
                    lblQuestion.Text = "1. What is Aang's primary element as an Avatar?";
                    button1.Text = "Air";
                    button2.Text = "Water";
                    button3.Text = "Fire";
                    button4.Text = "Surprise";
                    correctAnswer = 1;
                    break;

                case 2:
                    pictureBox1.Image = Properties.Resources.elements;
                    lblQuestion.Text = "2. What element can Aang bend?";
                    button1.Text = "Water";
                    button2.Text = "All of them";
                    button3.Text = "Fire";
                    button4.Text = "Earth";
                    correctAnswer = 2;
                    break;

                case 3:
                    pictureBox1.Image = Properties.Resources.southernwatertribe;
                    lblQuestion.Text = "3. Who is the last waterbender of the Southern Water Tribe?";
                    button1.Text = "Bumi";
                    button2.Text = "Bato";
                    button3.Text = "Sokka";
                    button4.Text = "Katara";
                    correctAnswer = 4;
                    break;

                case 4:
                    pictureBox1.Image = Properties.Resources.elements;
                    lblQuestion.Text = "4. What type of sub-bending technique was Hama able to do?";
                    button1.Text = "Flight";
                    button2.Text = "Metal Bending";
                    button3.Text = "Lightning Bending";
                    button4.Text = "Blood Bending";
                    correctAnswer = 4;
                    break;

                case 5:
                    pictureBox1.Image = Properties.Resources.toph;
                    lblQuestion.Text = "5. Who taught Toph earthbending?";
                    button1.Text = "Badger Moles";
                    button2.Text = "Lion Turtles";
                    button3.Text = "Sky Bison";
                    button4.Text = "Dragons";
                    correctAnswer = 1;
                    break;

                case 6:
                    pictureBox1.Image = Properties.Resources.iceberg;
                    lblQuestion.Text = "6. Who saves Aang from the iceberg, waking him up after a hundred years?";
                    button1.Text = "His Grandson";
                    button2.Text = "Katara";
                    button3.Text = "Fire Lord Ozai";
                    button4.Text = "His Mother";
                    correctAnswer = 2;
                    break;

                case 7:
                    pictureBox1.Image = Properties.Resources.sunwarriors;
                    lblQuestion.Text = "7. Who teaches Aang firebending in the Sun Warrior's ancient city?";
                    button1.Text = "Monk Gyatso";
                    button2.Text = "Sun Warriors";
                    button3.Text = "Dragons";
                    button4.Text = "Prince Zuko";
                    correctAnswer = 3;
                    break;

                case 8:
                    pictureBox1.Image = Properties.Resources.appa;
                    lblQuestion.Text = "8. What is Aang's flying bison's name?";
                    button1.Text = "Mr. Snuffles";
                    button2.Text = "Momo";
                    button3.Text = "Floppsy";
                    button4.Text = "Appa";
                    correctAnswer = 4;
                    break;
            }
        }
    }
}
