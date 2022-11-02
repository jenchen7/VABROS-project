using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue1 : MonoBehaviour
{
   Vector3 tpLocation = new Vector3(19.7f,6f,52.17f);
  
    void OnTriggerEnter(Collider Col)
    {
         CharacterController player = Col.gameObject.GetComponent<CharacterController>();
        player.enabled = false;
        player.transform.position = tpLocation;
        player.enabled = true;
            
//Purple Base to Purple Enterance
            
        
    }
}