using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public void loadNamePlayer ()
    {
        SceneManager.LoadScene("namePlayer");
    }
    public void loadLobby()
    {
        SceneManager.LoadScene("room");
    }
}
