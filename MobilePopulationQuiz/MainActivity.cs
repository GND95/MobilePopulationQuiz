using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace MobilePopulationQuiz
{
    [Activity(Label = "Population Quiz", MainLauncher = true, Icon = "@drawable/TitleBarIcon")]
    public class MainActivity : Activity
    {
        int numberCorrect = 0;
        int totalQuestions = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.Main);
            base.OnCreate(savedInstanceState);

            Button b1 = FindViewById<Button>(Resource.Id.button1);
            Button b2 = FindViewById<Button>(Resource.Id.button2);
            Button b3 = FindViewById<Button>(Resource.Id.button3);
            Button b4 = FindViewById<Button>(Resource.Id.button4);
            Button btnNext = FindViewById<Button>(Resource.Id.button5);
            TextView question = FindViewById<TextView>(Resource.Id.textView1);
            TextView score = FindViewById<TextView>(Resource.Id.textView3);
            btnNext.Enabled = false;

            b1.SetBackgroundColor(Android.Graphics.Color.DimGray);
            b2.SetBackgroundColor(Android.Graphics.Color.DimGray);
            b3.SetBackgroundColor(Android.Graphics.Color.DimGray);
            b4.SetBackgroundColor(Android.Graphics.Color.DimGray);

            List<int> alreadyUsed = new List<int>();//list for the numbers which have already been selected by the random number generator and therefore cannot be used again to select the next question

            void disableButtons()
            {
                b1.Enabled = false;
                b2.Enabled = false;
                b3.Enabled = false;
                b4.Enabled = false;
                btnNext.Enabled = true;
            };

            void enableButtons()
            {
                b1.Enabled = true;
                b2.Enabled = true;
                b3.Enabled = true;
                b4.Enabled = true;
                btnNext.Enabled = false;
            };

            void calculateScore()
            {
                decimal scorePercent = (decimal.Parse(numberCorrect.ToString()) / decimal.Parse(totalQuestions.ToString())) * 100;
                score.Text = numberCorrect.ToString() + " out of " + totalQuestions.ToString() + "  " + "(" + System.Math.Round(scorePercent, 0).ToString() + "%" + ")";
            };

            btnNext.Click += delegate
            {
                if (totalQuestions > 8) //this number needs to be one less than the total number of questions 
                {
                    btnNext.Text = "Finish";
                    //insert code here to finish the app and take the user to a score page with main menu/restart buttons
                }
                b3.Visibility = Android.Views.ViewStates.Visible;
                b4.Visibility = Android.Views.ViewStates.Visible;
                System.Random RNG = new System.Random(System.DateTime.Now.Millisecond);
                int randomNumber;
                do
                {
                    randomNumber = RNG.Next(1, 10); //the second digit will always be 1 greater than the number of total questions
                    Toast.MakeText(this, randomNumber.ToString(), ToastLength.Short).Show(); //testing purposes, remove later
                }
                while (alreadyUsed.Contains(randomNumber)); //if the already used question number comes up in the random number generator, generate a new random number and try again

                switch (randomNumber)
                {
                    case 1:
                        questionOne();
                        break;
                    case 2:
                        questionTwo();
                        break;
                    case 3:
                        questionThree();
                        break;
                    case 4:
                        questionFour();
                        break;
                    case 5:
                        questionFive();
                        break;
                    case 6:
                        questionSix();
                        break;
                    case 7:
                        questionSeven();
                        break;
                    case 8:
                        questionEight();
                        break;
                    case 9:
                        questionNine();
                        break;
                }           
                enableButtons();
                b1.SetBackgroundColor(Android.Graphics.Color.DimGray);
                b2.SetBackgroundColor(Android.Graphics.Color.DimGray);
                b3.SetBackgroundColor(Android.Graphics.Color.DimGray);
                b4.SetBackgroundColor(Android.Graphics.Color.DimGray);
            };

            btnNext.PerformClick(); //generates a random question the first time the program is run

            void questionOne()
            {
                question.Text = "Which country has closest to 150 million people?";
                b1.Text = "United States";
                b2.Text = "Germany";
                b3.Text = "United Kingdom";
                b4.Text = "Russia";

                b1.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b1.SetBackgroundColor(Android.Graphics.Color.Red);
                    b4.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(1);
                };
                b2.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b2.SetBackgroundColor(Android.Graphics.Color.Red);
                    b4.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(1);
                };
                b3.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b3.SetBackgroundColor(Android.Graphics.Color.Red);
                    b4.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(1);
                };
                b4.Click += delegate
                {
                    Toast.MakeText(this, "Correct", ToastLength.Short).Show();
                    b4.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    numberCorrect++;
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(1);
                };
            }

            void questionTwo()
            {
                question.Text = "What is the most populated country in the world?";
                b1.Text = "India";
                b2.Text = "China";
                b3.Text = "United States";
                b4.Text = "Indonesia";

                b1.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b1.SetBackgroundColor(Android.Graphics.Color.Red);
                    b2.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(2);
                };
                b2.Click += delegate
                {
                    Toast.MakeText(this, "Correct", ToastLength.Short).Show();
                    b2.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    numberCorrect++;
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(2);
                };
                b3.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b3.SetBackgroundColor(Android.Graphics.Color.Red);
                    b2.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(2);
                };
                b4.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b4.SetBackgroundColor(Android.Graphics.Color.Red);
                    b2.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(2);
                };
            }
            void questionThree()
            {
                question.Text = "Which country has a population closest to 325 million people?";
                b1.Text = "Pakistan";
                b2.Text = "United Kingdom";
                b3.Text = "Brazil";
                b4.Text = "United States";

                b1.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b1.SetBackgroundColor(Android.Graphics.Color.Red);
                    b4.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(3);
                };
                b2.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b2.SetBackgroundColor(Android.Graphics.Color.Red);
                    b4.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(3);
                };
                b3.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b3.SetBackgroundColor(Android.Graphics.Color.Red);
                    b4.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(3);
                };
                b4.Click += delegate
                {
                    Toast.MakeText(this, "Correct", ToastLength.Short).Show();
                    b4.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    numberCorrect++;
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(3);
                };
            }
            void questionFour()
            {
                b3.Visibility = Android.Views.ViewStates.Invisible;
                b4.Visibility = Android.Views.ViewStates.Invisible;
                question.Text = "Which country has the largest number of citizens?";
                b1.Text = "Australia";
                b2.Text = "Canada";

                b1.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b1.SetBackgroundColor(Android.Graphics.Color.Red);
                    b2.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(4);
                };
                b2.Click += delegate
                {
                    Toast.MakeText(this, "Correct", ToastLength.Short).Show();
                    b2.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    numberCorrect++;
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(4);
                };
            }
            void questionFive()
            {
                b3.Visibility = Android.Views.ViewStates.Invisible;
                b4.Visibility = Android.Views.ViewStates.Invisible;
                question.Text = "Which country has more citizens?";
                b1.Text = "South Korea";
                b2.Text = "North Korea";

                b1.Click += delegate
                {
                    Toast.MakeText(this, "Correct", ToastLength.Short).Show();
                    b1.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    numberCorrect++;
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(5);
                };
                b2.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b2.SetBackgroundColor(Android.Graphics.Color.Red);
                    b2.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(5);
                };
            }
            void questionSix()
            {
                question.Text = "Which of these countries have the most people?";
                b1.Text = "Germany";
                b2.Text = "France";
                b3.Text = "Japan";
                b4.Text = "Italy";

                b1.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b1.SetBackgroundColor(Android.Graphics.Color.Red);
                    b3.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(6);
                };
                b2.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b2.SetBackgroundColor(Android.Graphics.Color.Red);
                    b3.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(6);
                };
                b3.Click += delegate
                {
                    Toast.MakeText(this, "Correct", ToastLength.Short).Show();
                    b3.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    numberCorrect++;
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(6);
                };
                b4.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b3.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    b4.SetBackgroundColor(Android.Graphics.Color.Red);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(6);
                };
            }
            void questionSeven()
            {
                question.Text = "Which of these countries have the most people?";
                b1.Text = "Japan";
                b2.Text = "Brazil";
                b3.Text = "Mexico";
                b4.Text = "Russia";

                b1.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b1.SetBackgroundColor(Android.Graphics.Color.Red);
                    b2.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(7);
                };
                b2.Click += delegate
                {
                    Toast.MakeText(this, "Correct", ToastLength.Short).Show();
                    b2.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(7);
                };
                b3.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b2.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    b3.SetBackgroundColor(Android.Graphics.Color.Red);
                    disableButtons();
                    numberCorrect++;
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(7);
                };
                b4.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b2.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    b4.SetBackgroundColor(Android.Graphics.Color.Red);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(7);
                };
            }
            void questionEight()
            {
                question.Text = "Which of these countries have the least amount of people?";
                b1.Text = "Sweden";
                b2.Text = "Finland";
                b3.Text = "Denmark";
                b4.Text = "Norway";

                b1.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b1.SetBackgroundColor(Android.Graphics.Color.Red);
                    b4.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(8);
                };
                b2.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b4.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    b2.SetBackgroundColor(Android.Graphics.Color.Red);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(8);
                };
                b3.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b4.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    b3.SetBackgroundColor(Android.Graphics.Color.Red);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(8);
                };
                b4.Click += delegate
                {
                    Toast.MakeText(this, "Correct", ToastLength.Short).Show();
                    b4.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    numberCorrect++;
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(8);
                };
            }
            void questionNine()
            {
                question.Text = "Which of these countries have the most people?";
                b1.Text = "Nigeria";
                b2.Text = "Mexico";
                b3.Text = "Japan";
                b4.Text = "Russia";

                b1.Click += delegate
                {
                    Toast.MakeText(this, "Correct", ToastLength.Short).Show();
                    b1.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    numberCorrect++;
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(9);
                };
                b2.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b1.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    b2.SetBackgroundColor(Android.Graphics.Color.Red);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(9);
                };
                b3.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b1.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    b3.SetBackgroundColor(Android.Graphics.Color.Red);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(9);
                };
                b4.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b1.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    b4.SetBackgroundColor(Android.Graphics.Color.Red);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                    alreadyUsed.Add(9);
                };
            }
        }
    }
}

