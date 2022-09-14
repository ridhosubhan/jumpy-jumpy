using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffects;

    public int maxHealth = 3;
    public int currentHealth; 
    public HealthBar healthBar;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();       
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Trap_Tag")){
            // playerDie();
            currentHealth -= 1;
            healthBar.SetHealth(currentHealth);
            if(currentHealth <= 0){
                playerDie();
            }
        }
    }

    

    private void playerDie(){
        deathSoundEffects.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void restartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
