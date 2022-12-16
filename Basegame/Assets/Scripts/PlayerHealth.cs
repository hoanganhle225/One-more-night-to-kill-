using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    
    public bool getHit;
    public PlayerController controller;

    void Start()
    {
        currentHealth = maxHealth;   
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    void Update() 
    {
        if(maxHealth > numOfHearts){
            maxHealth = numOfHearts;
        }
        
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHealth){
                hearts[i].sprite = fullHeart;
            } else{
                hearts[i].sprite = emptyHeart;
            } 
            if(i < numOfHearts){
                hearts[i].enabled = true;
            } else{
                hearts[i].enabled = false;
            }
        }
        if (currentHealth <= 0){
            controller.anim.SetBool("isDead", true);
            this.gameObject.layer = 13;
            controller.enabled = false;
        }
    }
    public void TakeDamage(int damage){
        currentHealth -= damage;
        getHit = true;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
        {
            TakeDamage(1);

            // other.gameObject.layer = 11;
            // StartCoroutine(InvisibleFrame(other));
            // Destroy(other.gameObject);
            
        } 
    }
    // private IEnumerator InvisibleFrame(Collision2D other)
    // {
    //     yield return new WaitForSeconds(0.3f);
    //     if(other.gameObject.tag == "Enemy"){
    //         other.gameObject.layer = 9;
    //     }
    // }
}
