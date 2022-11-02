
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currHealth;
    Vector3 spawnPoint; 
    public string team;
    private CharacterController player;
    public HealthBar healthBar;
    public Actions actions;
    CharacterController controller;
    Movement mov;

    void Start() {
        currHealth = maxHealth;
        healthBar = GetComponentInChildren<HealthBar>();
        actions = GetComponentInChildren<Actions>();
        controller = GetComponent<CharacterController>();
        mov = GetComponent<Movement>();
        //team = GetComponent<PlayerTeamScript>().team;
        if (SceneManager.GetActiveScene().name == "City Map Idea") {
            spawnPoint = new Vector3(426.5f,-79f,536f);
            SpawnPlayer();

        }
        else if(SceneManager.GetActiveScene().name == "MountainMapIdea") {
            spawnPoint = new Vector3(582.1f,-163.8f,573f);
            SpawnPlayer();
        }
    }
    
    public void TakeDamage(float amount)
    {
        currHealth -= amount;
        Debug.Log(currHealth);
        healthBar.SetHealth((int)currHealth);
        actions.Damage();

        // kills enemy if health reaches 0
        if (currHealth <= 0) {
            KillPlayer();
        }
    }

    public void RestoreHealth(float amount) {
        currHealth += amount;
        Debug.Log(currHealth);

        if (currHealth > maxHealth) {
            currHealth = maxHealth;
        }
        healthBar.SetHealth((int)currHealth);

    }

    // respawns player (WIP); replace destroy object with proper respawn script
    void KillPlayer() {

        if(GetComponent<FlagCollection>().hasBlueFlag) {
            GetComponent<FlagCollection>().hasBlueFlag = false;
            GameObject.Find("BlueFlag").SetActive(true);
        }
        else if (GetComponent<FlagCollection>().hasRedFlag) {
            GetComponent<FlagCollection>().hasRedFlag = false;
            GameObject.Find("RedFlag").SetActive(true);

        }
        actions.Death();
        mov.enabled = false;  // disables moving until respawn
        StartCoroutine(RespawnCoroutine());
        SpawnPlayer();

        // sounds[1].Play();
    }

    void SpawnPlayer() {
        controller.enabled = false;
        controller.transform.position = spawnPoint;
        controller.enabled = true;
    }

    public string GetTeam() {
        return this.team;
    }

    IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(3f);
        mov.enabled = true;
    }
    
}