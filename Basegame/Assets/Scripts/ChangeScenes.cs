using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public GameController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("existed");
        if(other.gameObject.tag == "Player")
        {
                SceneManager.LoadScene(controller.currentScene + 1);    

        } 
    }
}
