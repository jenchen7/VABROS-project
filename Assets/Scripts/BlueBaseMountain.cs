using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBaseMountain : MonoBehaviour
{
    void OnTriggerEnter(Collider Col)
    {
        CharacterController player = Col.gameObject.GetComponent<CharacterController>();
        if (player.gameObject.GetComponent<FlagCollection>().hasRedFlag) {
            player.gameObject.GetComponent<FlagCollection>().hasRedFlag = false;
            Scores.AddBlueScore();
            RespawnFlagCoroutine(GameObject.Find("RedFlag"));
        }
        
    }

    IEnumerator RespawnFlagCoroutine(GameObject obj)
    {
        yield return new WaitForSeconds(10);
        obj.SetActive(true);
    }
}
