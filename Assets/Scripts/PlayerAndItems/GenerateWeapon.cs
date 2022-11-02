using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWeapon : MonoBehaviour
{
    public int currentWeapon;

    void Start() {
        currentWeapon = Random.Range(0,4);
        SelectWeapon();
    }

    void Update()
    {
        //transform.position = Vector3.up * Mathf.Cos(Time.deltaTime) * intensity;
        transform.Rotate(0, -60*Time.deltaTime, 0);
    }

    void SelectWeapon() {
        int i=0;
        foreach(Transform weapon in transform) {

            if (i==currentWeapon) {
                weapon.gameObject.SetActive(true);
            }
            else{
                weapon.gameObject.SetActive(false);
            }

            i++;

        }
    }
}
