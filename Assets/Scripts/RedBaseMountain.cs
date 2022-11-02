using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBaseMountain : MonoBehaviour
{
    void OnTriggerEnter(Collider Col)
    {
        CharacterController player = Col.gameObject.GetComponent<CharacterController>();
        if (player.gameObject.GetComponent<FlagCollection>().hasBlueFlag) {
            player.gameObject.GetComponent<FlagCollection>().hasBlueFlag = false;
            Scores.AddRedScore();
            RespawnFlagCoroutine(GameObject.Find("BlueFlag"));
        }
        
    }

    IEnumerator RespawnFlagCoroutine(GameObject obj)
    {
        yield return new WaitForSeconds(10);
        obj.SetActive(true);
    }
}
