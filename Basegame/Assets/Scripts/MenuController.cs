using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    public void PlayGame()
    {
        StartCoroutine(ChangeLevel());
        SceneManager.LoadScene(2);
    }
    public void Setting()
    {
        StartCoroutine(ChangeLevel());
        SceneManager.LoadScene(1);
    }
    public void BackToMenu()
    {
        StartCoroutine(ChangeLevel());
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        StartCoroutine(ChangeLevel());
        SceneManager.LoadScene(controller.currentScene);
        Time.timeScale = 1f;
    }
    public void Resume()
    {
        controller.GamePause.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void PlayDungeonI()
    {
        StartCoroutine(ChangeLevel());
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }
    public void PlayDungeonII()
    {
        StartCoroutine(ChangeLevel());
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
    }
    public void PlayDungeonIII()
    {
        StartCoroutine(ChangeLevel());
        SceneManager.LoadScene(4);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
    }
    IEnumerator ChangeLevel() 
    {
        FaderScript fade = GameObject.FindGameObjectWithTag("Fader").GetComponent<FaderScript>();
        float fadeTime = fade.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
    }
}
