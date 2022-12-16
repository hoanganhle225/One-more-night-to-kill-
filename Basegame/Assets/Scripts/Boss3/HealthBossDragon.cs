using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBossDragon : MonoBehaviour
{
    public Dragon dragon;
    private Slider slider;
    float fillvalue;

    public GameController controller;
    public PlayerController player;
    
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        slider = GetComponent<Slider>();
        dragon = GameObject.FindGameObjectWithTag("Boss").GetComponent<Dragon>();
    }

    // Update is called once per frame
    void Update()
    {
        // set thanh máu theo máu hiện tại của Dragon,
        fillvalue = dragon.currentHealth / dragon.maxhealth;
        slider.value = fillvalue;
        
        // Boss chết thì tự hủy thanh máu
        if (slider.value <= 0){
            Destroy(this.gameObject, 3f);
            controller.WinScene.SetActive(true);
            player.enabled = false;

        }
    }
}
