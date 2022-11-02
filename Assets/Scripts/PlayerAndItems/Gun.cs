using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float shotDelay = 0.5f;

    public Camera fpsCam;

    private AudioSource sound;

    PlayerAmmo ammo;
    public string team;
    private bool canShoot;

    void Start () {
        sound = GetComponent<AudioSource>();
        //team = GetComponent<PlayerHealth>().GetTeam();
        ammo = transform.parent.parent.parent.gameObject.GetComponent<PlayerAmmo>(); 
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        // shoot when left mouse button is clicked and has sufficient ammo
        if (Input.GetButtonDown("Fire1") && ammo.GetAmmoCount() > 0 && canShoot) {
            if (gameObject.name == "BurstRifle" && ammo.GetAmmoCount() > 2) {
                Shoot();
                StartCoroutine(BurstDelayCoroutine());
                Shoot();
                StartCoroutine(BurstDelayCoroutine());
                Shoot();
            }
            else {
                Shoot();
            } 
            
            Debug.Log(ammo.GetAmmoCount());
            canShoot = false;
            StartCoroutine(DelayCoroutine()); // delay in between shots
        }
        
    }

    void Shoot() {
        sound.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
            //Debug.Log(hit.transform.name);
            PlayerHealth other = hit.transform.GetComponent<PlayerHealth>();
            if (other != null) {
                other.TakeDamage(damage);
            }
        }
        ammo.UseAmmo();
    }

    // delay in between gun shots
    IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(shotDelay);
        canShoot = true;
    }

    IEnumerator BurstDelayCoroutine()
    {
        yield return new WaitForSeconds(0.8f);
    }
}
