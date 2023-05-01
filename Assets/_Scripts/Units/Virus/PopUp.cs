using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUp : VirusBase {

    private List<string> titles = new List<string>() {
        "Error",
        "?????",
        "Warning",
        "Congratulations!",
        "Alert",
        "Are you stupid?",
        ":)",
        ".......",
        "DO NOT CLOSE THIS WINDOW"
    };

    private List<string> messages = new List<string>() {
        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA",
        "???????????????????????????????????????????",
        "Hi there!",
        ":)",
        "Congratulations on winging an apple android iphone galaxy S13 plus! \n\n Claim it now here!",
        "Your computer has been locked due to suspicious activity. Please call the following number to speak with a technician and unlock your system.",
        "Oh no, windows did an oopsie",
        "Console.Log(\"Hello World\")",
        "Hmmmm"
    };

    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI message;
    public override void Pathfind() {
        throw new System.NotImplementedException();
    }

    private void OnEnable() {
        Initialize();
    }

    private void Initialize() {
        string randomTitle = titles[Random.Range(0, titles.Count)].ToString();
        string randomMessage = messages[Random.Range(0, messages.Count)].ToString();

        title.SetText(randomTitle);
        message.SetText(randomMessage);
    }

    public void CloseWindow() {
        Die();
    }

    public override void SetTarget() {
        throw new System.NotImplementedException();
    }
}
