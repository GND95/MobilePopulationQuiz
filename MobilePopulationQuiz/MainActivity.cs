using Android.App;
using Android.Widget;
using Android.OS;

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
            int questionNumber = 1;

            Button b1 = FindViewById<Button>(Resource.Id.button1);
            Button b2 = FindViewById<Button>(Resource.Id.button2);
            Button b3 = FindViewById<Button>(Resource.Id.button3);
            Button b4 = FindViewById<Button>(Resource.Id.button4);
            Button btnNext = FindViewById<Button>(Resource.Id.button5);
            TextView question = FindViewById<TextView>(Resource.Id.textView1);
            TextView score = FindViewById<TextView>(Resource.Id.textView3);

            b1.SetBackgroundColor(Android.Graphics.Color.DimGray);
            b2.SetBackgroundColor(Android.Graphics.Color.DimGray);
            b3.SetBackgroundColor(Android.Graphics.Color.DimGray);
            b4.SetBackgroundColor(Android.Graphics.Color.DimGray);

            void disableButtons()
            {
                b1.Enabled = false;
                b2.Enabled = false;
                b3.Enabled = false;
                b4.Enabled = false;
            };

            void enableButtons()
            {
                b1.Enabled = true;
                b2.Enabled = true;
                b3.Enabled = true;
                b4.Enabled = true;
            };

            void calculateScore()
            {
                decimal scorePercent = (decimal.Parse(numberCorrect.ToString()) / decimal.Parse(totalQuestions.ToString())) * 100;
                score.Text = numberCorrect.ToString() + " out of " + totalQuestions.ToString() + "  " + "(" + System.Math.Round(scorePercent, 0).ToString() + "%" + ")";
            };

            btnNext.Click += delegate
            {
                enableButtons();
                b1.SetBackgroundColor(Android.Graphics.Color.DimGray);
                b2.SetBackgroundColor(Android.Graphics.Color.DimGray);
                b3.SetBackgroundColor(Android.Graphics.Color.DimGray);
                b4.SetBackgroundColor(Android.Graphics.Color.DimGray);
            };

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
                };
                b2.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b2.SetBackgroundColor(Android.Graphics.Color.Red);
                    b4.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                };
                b3.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b3.SetBackgroundColor(Android.Graphics.Color.Red);
                    b4.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                };
                b4.Click += delegate
                {
                    Toast.MakeText(this, "Correct", ToastLength.Short).Show();
                    b4.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    numberCorrect++;
                    totalQuestions++;
                    calculateScore();
                };
            }

            void questionTwo()
            {
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
                };
                b2.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b2.SetBackgroundColor(Android.Graphics.Color.Red);
                    b4.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                };
                b3.Click += delegate
                {
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    b3.SetBackgroundColor(Android.Graphics.Color.Red);
                    b4.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    totalQuestions++;
                    calculateScore();
                };
                b4.Click += delegate
                {
                    Toast.MakeText(this, "Correct", ToastLength.Short).Show();
                    b4.SetBackgroundColor(Android.Graphics.Color.DarkGreen);
                    disableButtons();
                    numberCorrect++;
                    totalQuestions++;
                    calculateScore();
                };
            }

            if (questionNumber == 1)
            {
                questionOne();
            }
        }
    }
}

