namespace AppDevFinal;
using System.Text;
using System.Text.Json;

public partial class ExamPage : ContentPage
{
    private string studentId;
    public ExamPage(string student)
    {
        InitializeComponent();
        studentId = student;
    }
    private async void SubmitExam(object sender, EventArgs e)
    {
        try
        {
            int score = 0;
            int correctanswers = 0;
            int wronganswers = 0;
            DateTime currentDateTime = DateTime.Now;
            string examdate = currentDateTime.ToString("yyyy-MM-dd");
            string examtime = currentDateTime.ToString("HH:mm:ss");
  

            if (!Q1A.IsChecked &&
                !Q1B.IsChecked &&
                !Q1C.IsChecked &&
                !Q1D.IsChecked)
            {
                await DisplayAlert("Error", "Please answer Question 1.", "OK");
                return;
            }

            if (Q1C.IsChecked)
            {
                score++;
                correctanswers ++;
            }
            else
            {
                wronganswers++;
            }

            if (!Q2A.IsChecked &&
                !Q2B.IsChecked &&
                !Q2C.IsChecked &&
                !Q2D.IsChecked)
            {
                await DisplayAlert("Error", "Please answer Question 2.", "OK");
                return;
            }

            if (Q2B.IsChecked)
            {
                score++;
                    correctanswers ++;
            }
            else
            {
                wronganswers ++;
            }

            if (!Q3A.IsChecked &&
                !Q3B.IsChecked &&
                !Q3C.IsChecked &&
                !Q3D.IsChecked)
            {
                await DisplayAlert("Error", "Please answer Question 3.", "OK");
                return;
            }

            if (Q3A.IsChecked &&
                !Q3B.IsChecked &&
                !Q3C.IsChecked &&
                !Q3D.IsChecked)
            {
                score++;
                correctanswers++;
            }
            else { wronganswers++; }


            if (!Q4A.IsChecked &&
                !Q4B.IsChecked &&
                !Q4C.IsChecked &&
                !Q4D.IsChecked)
            {
                await DisplayAlert("Error", "Please answer Question 4.", "OK");
                return;
            }

            if (Q4C.IsChecked &&
                !Q4A.IsChecked &&
                !Q4B.IsChecked &&
                !Q4D.IsChecked)
            {
                score++;
                correctanswers++;
            }
            else
            {
                wronganswers++;
            }

            if (!Q5A.IsChecked &&
                !Q5B.IsChecked &&
                !Q5C.IsChecked &&
                !Q5D.IsChecked)
            {
                await DisplayAlert("Error", "Please answer Question 5.", "OK");
                return;
            }

            if (Q5D.IsChecked)
            {
                score++;
                correctanswers++;
            }
            else { wronganswers++; }

            var client = new HttpClient();

            var examData = new
            {
                STUDENTID = studentId,
                DATE = examdate,
                TIME = examtime,
                SCORE = score,
                CORRECT = correctanswers,
                WRONG = wronganswers
            };

            var json = JsonSerializer.Serialize(examData);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            string baseUrl;

            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                baseUrl = "http://10.0.2.2/CITA355/CITA-355-Final-Project/CITA_355_PROJECT_ONE/";
            }
            else if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                baseUrl = "http://localhost/CITA355/CITA-355-Final-Project/CITA_355_PROJECT_ONE/";
            }
            else
            {
                baseUrl = "http://192.168.X.X/CITA355/CITA-355-Final-Project/CITA_355_PROJECT_ONE/";
            }

            string url = baseUrl + "submitdatabase.php";

            var response = await client.PostAsync(url, content);

            string q1answer;

            if (Q1A.IsChecked)
            {
                q1answer = "A";
            }
            else if (Q1B.IsChecked)
            {
                q1answer = "B";
            }
            else if (Q1C.IsChecked)
            {
                q1answer = "C";
            }
            else
            {
                q1answer = "D";
            }
            string q2answer;

            if (Q2A.IsChecked)
            {
                q2answer = "A";
            }
            else if (Q2B.IsChecked)
            {
                q2answer = "B";
            }
            else if (Q2C.IsChecked)
            {
                q2answer = "C";
            }
            else
            {
                q2answer = "D";
            }

            string q3answer;

            if (Q3A.IsChecked &&
                !Q3B.IsChecked &&
                !Q3C.IsChecked &&
                !Q3D.IsChecked)
            {
                q3answer = "A only";
            }
            else
            {
                q3answer = "Multiple or None";
            }

            string q4answer;

            if (Q4C.IsChecked &&
                !Q4A.IsChecked &&
                !Q4B.IsChecked &&
                !Q4D.IsChecked)
            {
                q4answer = "C only";
            }
            else
            {
                q4answer = "Multiple or None";
            }
            string q5answer;

            if (Q5A.IsChecked)
            {
                q5answer = "A";
            }
            else if (Q5B.IsChecked)
            {
                q5answer = "B";
            }
            else if (Q5C.IsChecked)
            {
                q5answer = "C";
            }
            else
            {
                q5answer = "D";
            }

            await Navigation.PushAsync(
            new ResultPage(
             studentId,
            score,
            correctanswers,
            wronganswers,
            examdate,
            examtime,
            q1answer,
            q2answer,
            q3answer,
            q4answer,
            q5answer
    ));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }


}