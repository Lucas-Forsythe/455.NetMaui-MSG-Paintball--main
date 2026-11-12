using AppDevFinal.Model;

namespace AppDevFinal;

public partial class HomePage : ContentPage
{
    Student _student;

    public HomePage(Student student)
    {
        InitializeComponent();
        _student = student;

        WelcomeLabel.Text = $"Welcome {_student.FIRSTNAME} {_student.LASTNAME}";
        StudentIdLabel.Text = $"ID: {_student.STUDENTID}";
        EmailLabel.Text = _student.EMAIL;
    }

    private async void ExamPage_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ExamPage(_student.STUDENTID.ToString()));
    }
}