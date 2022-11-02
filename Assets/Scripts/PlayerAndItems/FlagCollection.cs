using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCollection : MonoBehaviour
{
    public bool hasRedFlag;
    public bool hasBlueFlag;
    GameObject prevObject;

    // Start is called before the first frame update
    void Start()
    {
        hasRedFlag = false;
        hasBlueFlag = false;
        
    }

    void OnControllerColliderHit(ControllerColliderHit hit) {

        if (hit.gameObject.name == "RedFlag" && !hasBlueFlag) {
            hasRedFlag = true;
            hit.gameObject.SetActive(false);
        }

        if (hit.gameObject.name == "BlueFlag" && !hasRedFlag) {
            hasBlueFlag = true;
            hit.gameObject.SetActive(false);
        }
    }
}
