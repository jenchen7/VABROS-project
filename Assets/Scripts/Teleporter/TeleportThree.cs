using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportThree : MonoBehaviour
{
   Vector3 tpLocation = new Vector3(1027.8f,63f,849.5f);
  
    void OnTriggerEnter(Collider Col)
    {
        CharacterController player = Col.gameObject.GetComponent<CharacterController>();
        if (player.gameObject.GetComponent<FlagCollection>().hasRedFlag) {
            player.gameObject.GetComponent<FlagCollection>().hasRedFlag = false;
            Scores.AddBlueScore();
            RespawnFlagCoroutine(GameObject.Find("RedFlag"));
        }

        player.enabled = false;
        player.transform.position = tpLocation;
        player.enabled = true;
            

            //Purple Enterence to purple base
        
    }

    IEnumerator RespawnFlagCoroutine(GameObject obj)
    {
        yield return new WaitForSeconds(10);
        obj.SetActive(true);
    }
}
//Purple Base Empty (1008,0,1010.7)
//Purple Base (-1.6,50,-103.2)
//Purple Enterence (146.6,-5.4,114.3)
