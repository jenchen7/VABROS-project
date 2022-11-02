using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamePlayer : MonoBehaviour
{
    public InputField playerName;
    private string name;
    // Start is called before the first frame update
    public void enterName()
    {
        name = playerName.text;
    }
 
}
