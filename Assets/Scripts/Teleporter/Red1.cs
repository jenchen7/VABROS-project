using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red1 : MonoBehaviour
{
   Vector3 tpLocation = new Vector3(976.4f,5.77f,941.3f);
  
    void OnTriggerEnter(Collider Col)
    {
         CharacterController player = Col.gameObject.GetComponent<CharacterController>();
        player.enabled = false;
        player.transform.position = tpLocation;
        player.enabled = true;
            
//Purple Base to Purple Enterance
            
        
    }
}