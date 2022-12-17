using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject GamePause;
	public GameObject LoseScene;
	public GameObject WinScene;
	public GameObject ChangeScene;

    public MenuController menu;
    public PlayerHealth controller;

    bool existed;
    public int currentScene;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("MenuController").GetComponent<MenuController>();
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        
        currentScene = SceneManager.GetActiveScene().buildIndex;
        
        GamePause.SetActive(false);
        ChangeScene.SetActive(false);
        LoseScene.SetActive(false);
        if(currentScene != 4){
            Destroy(WinScene);
        } else{
            WinScene.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        existed = GameObject.FindGameObjectWithTag("Boss");
        if(!existed)
        {
            ChangeScene.SetActive(true);
        }
        if(controller.currentHealth <= 0){
            LoseScene.SetActive(true);
            
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePause.SetActive(true);
            menu.Pause();
        }
    }
}
