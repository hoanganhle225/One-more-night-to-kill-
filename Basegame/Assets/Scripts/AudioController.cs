using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private AudioSource backgorundAudio;
    
    [SerializeField]
    private AudioSource impactAudio;
    
    [SerializeField]
    private AudioSource getHitAudio;
    
    public PlayerHealth controller;
    public Weapon player;
    
    private float fireRate;
    private float timeRate;
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Weapon>();
        fireRate = player.fireRate;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J) && Time.time > timeRate)
        {
            timeRate = Time.time + fireRate;
            impactAudio.Play();
        }

        if(controller.getHit){
            getHitAudio.Play();
            controller.getHit = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            backgorundAudio.Play();
        }
    }
}
