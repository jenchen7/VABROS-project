using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickups : MonoBehaviour
{
    PlayerAmmo ammo;
    PlayerHealth health;
    WeaponSwitching[] weapons;
    private GameObject prevObject;
    AudioSource[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        ammo = GetComponent<PlayerAmmo>();
        health = GetComponent<PlayerHealth>();
        sounds = GetComponents<AudioSource>();
        weapons = GetComponentsInChildren<WeaponSwitching>();
        
    }

     void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // collects ammo and temporarly disable ammo box
        if (hit.gameObject.tag == "Ammo" && hit.gameObject != prevObject) {
            prevObject = hit.gameObject;
            ammo.AddAmmo(10);
            sounds[0].Play();

            Debug.Log(ammo.ammoCount);
            StartCoroutine(RespawnTimeCoroutine(hit.gameObject,10));
            
        }

        // collects health regen and temporarily disable health pickup
        if (hit.gameObject.tag == "Health" && hit.gameObject != prevObject) {
            prevObject = hit.gameObject;
            health.RestoreHealth(25);
            sounds[1].Play();

            Debug.Log(health.currHealth);
            StartCoroutine(RespawnTimeCoroutine(hit.gameObject,10));

        }

        // changes active weapon to the weapon picked up
        if (hit.gameObject.tag == "Weapon" && hit.gameObject != prevObject) {
            prevObject = hit.gameObject;

            // change weapon and icon
            foreach (WeaponSwitching weaponSet in weapons) {
                weaponSet.SwitchWeapon( hit.gameObject.GetComponent<GenerateWeapon>().currentWeapon);
            }
            
            sounds[0].Play();

            StartCoroutine(RespawnTimeCoroutine(hit.gameObject,60));

        }

        /*
        // take damage, used for testing
        if (hit.gameObject.tag == "HurtZone" && hit.gameObject != prevObject) {
            prevObject = hit.gameObject;

            health.TakeDamage(25);

        }
        */
        
    }

    // disables then reactivate object after a set amount of time
    IEnumerator RespawnTimeCoroutine(GameObject obj, int seconds)
    {
        obj.SetActive(false);
        yield return new WaitForSeconds(seconds);
        obj.SetActive(true);
        prevObject = null;
    }
}
