using UnityEngine;

public class SceneChange : MonoBehaviour
{

    public static void LoadMountainMap() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MountainMapIdea");
    }

    // quits game
    public void ExitGame() {
        Application.Quit();
    }
}
