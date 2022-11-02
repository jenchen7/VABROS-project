using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float maxHealth = 30;
    private float currHealth;

    void Start() {
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 60*Time.deltaTime, 0);
    }
    
    public void TakeDamage(float amount)
    {
        currHealth -= amount;

        // kills enemy if health reaches 0
        if (currHealth <= 0) {
            KillEnemy();
        }
    }

    void KillEnemy() {
        //MovePlayer.sounds[2].Play();
        Destroy(gameObject);
    }
    
}