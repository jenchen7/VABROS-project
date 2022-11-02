using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTwo : MonoBehaviour
{
   Vector3 tpLocation = new Vector3(171.5f, 5f, 130f);
  
    void OnTriggerEnter(Collider Col)
    {
         CharacterController player = Col.gameObject.GetComponent<CharacterController>();
        player.enabled = false;
        player.transform.position = tpLocation;
        player.enabled = true;
            
//Teleport from Green Base To Green Enterance
            
        
    }
}
