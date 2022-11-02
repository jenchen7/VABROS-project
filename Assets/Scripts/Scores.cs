using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    public Text[] scoreTexts;
    public static int blueScore;
    public static int redScore;
 
    void Start () {
        scoreTexts = GetComponentsInChildren<Text>();
        blueScore = 0;
        redScore = 0;
    }
 
    void Update () {
        scoreTexts[1].text = blueScore.ToString();
        scoreTexts[2].text = redScore.ToString();

        if (redScore == 10 || blueScore == 10) {
            blueScore = 0;
            redScore = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene("MountainMapIdea");
        }
    }

    public static void AddBlueScore() {
        blueScore++;
    }

    public static void AddRedScore() {
        redScore++;
    }

}
