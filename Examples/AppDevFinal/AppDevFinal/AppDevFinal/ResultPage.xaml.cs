namespace AppDevFinal;

public partial class ResultPage : ContentPage
{
    public ResultPage(
        string studentId,
        int score,
        int correct,
        int wrong,
        string date,
        string time,
        string q1,
        string q2,
        string q3,
        string q4,
        string q5
       )
    {
        InitializeComponent();

        StudentIdLabel.Text = $"Student ID: {studentId}";

        ScoreLabel.Text =
            $"Score: {(score * 20)}% ({score}/5)";

        CorrectLabel.Text =
            $"Correct Answers: {correct}";

        WrongLabel.Text =
            $"Wrong Answers: {wrong}";

        DateLabel.Text =
            $"Date: {date}";

        TimeLabel.Text =
            $"Time: {time}";

        ReviewLabel.Text =
       $"Q1 Your Answer: {q1}\n" +
       $"Q1 Correct: C\n" +
        $"Q2 Your Answer: {q2}\n" +
        $"Q2 Correct: B\n" +
       $"Q3 Your Answer: {q3}\n" +
       $"Q3 Correct: A\n" +
       $"Q4 Your Answer: {q4}\n" +
       $"Q4 Correct: C\n" +
       $"Q5 Your Answer: {q5}\n" +
       $"Q5 Correct: D";
    }

    private void ToReport(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ReportPage());
    }
}