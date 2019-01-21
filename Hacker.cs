using UnityEngine;

public class Hacker : MonoBehaviour
{
    string[] Level1Passwords = { "book", "shelf", "aisel", "borrow", "pen", "password", "mouse" };
    string[] Level2Passwords = { "police", "robber", "arrest", "hand cuffs", "weapon", "password" };
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen CurrentScreen;
    string Password;

    void Start()
    {
        ShowMainMenue("Hello Ahmed");
    }

    void ShowMainMenue(string Greeting)
    {
        Terminal.WriteLine(Greeting);
        Terminal.WriteLine("What Do You Want To Hack ?");
        Terminal.WriteLine("1-Local Library");
        Terminal.WriteLine("2-Police Station ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            CurrentScreen = Screen.MainMenu;
            Terminal.ClearScreen();
            ShowMainMenue("Hello Ahmed");

        }
        else if (CurrentScreen == Screen.MainMenu)
        {

            RunMainMenu (input);

        }
        else if (CurrentScreen == Screen.Password)
        {

            CheckPassword(input);

        }
 
    }

    void RunMainMenu (string input)
    {
        bool IsValidLevelNumber = (input == "1" || input == "2");

        if (IsValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();

        }

        else if (input == "ahmed")
        {

            Terminal.ClearScreen();
            ShowMainMenue("Hello Hacker");

        }

 
        else
        {

            Terminal.WriteLine("Please Write Valide Characters");

        }
    }

    void StartGame()
    {
        CurrentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("Write Password");
        switch (level)
        {
            case 1:
                Password = Level1Passwords[Random.Range(0, Level1Passwords.Length)];
                break;

            case 2:
                Password = Level2Passwords[Random.Range(0, Level2Passwords.Length)];
                break;

        }
    }

    void CheckPassword (string input)
    {

        if (input == Password)
        {

            DisplayWinScreen();

        }
        else
        {
            Terminal.WriteLine("Wrong password");
        }

    }
    void DisplayWinScreen()
    {
        CurrentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward ()
    {
        Terminal.WriteLine("WELL DONE!");
        switch (level)
        {
            case 1:
                Terminal.WriteLine("HAVE A BOOK!");
                Terminal.WriteLine(@"
     _________
    /--------//
   /        //
  /        //
 /_______ //
(________(/ 

   
                    ");
                break;
            case 2:
                Terminal.WriteLine("HAVE A GUN!");
                Terminal.WriteLine(@"
    __________
   /  __   ___|
  /  /  |_|
 /  /
/__/



                   ");
                break;

        }


    }
}