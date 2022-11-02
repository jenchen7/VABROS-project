using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleortBlueStart : MonoBehaviour
{
   Vector3 tpLocation = new Vector3(-6f, 4f, 100f);
  
    void OnTriggerEnter(Collider Col)
    {
         CharacterController player = Col.gameObject.GetComponent<CharacterController>();
        player.enabled = false;
        player.transform.position = tpLocation;
        player.enabled = true;
            
//Purple Base to Purple Enterance
            
        
    }
}

