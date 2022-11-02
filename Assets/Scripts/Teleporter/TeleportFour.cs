using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportFour : MonoBehaviour
{
   Vector3 tpLocation = new Vector3(826.8f, 5f, 892.5f);
  
    void OnTriggerEnter(Collider Col)
    {
        CharacterController player = Col.gameObject.GetComponent<CharacterController>();
        player.enabled = false;
        player.transform.position = tpLocation;
        player.enabled = true;
            
//Purple Base to Purple Enterance
            
        
    }
}

