using SQLite;
namespace survey_5834312;

public partial class App : Application
{
    public static string DBPath { get; private set; }
    public static SurveyDatabase Database { get; private set; }
    public App()
    {
        InitializeComponent();

        DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Surveys.db3");
        Database = new SurveyDatabase(DBPath);

        MainPage = new NavigationPage(new NewPage1());
    }
}
