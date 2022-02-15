using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    public Text scoreText;
    public GameObject healthBar;
    public GameObject pauseMenu;
    public GameObject gameOverUI;
    public Text highestScoreUIText;
    public Text scoreUIText;

    private void Start()
    {
        healthBar.GetComponent<HealthBar>().SetMaxHealth(100);
        healthBar.GetComponent<HealthBar>().SetHealth(100);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void UpdateHealthBar(int health)
    {
        healthBar.GetComponent<HealthBar>().SetHealth(health);
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = "" + score;    
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void toGithub()
    {
        Application.OpenURL("https://github.com/knlao/unity-space-fighter");
    }

    public void GameOver()
    {
        scoreText.enabled = false;
        scoreUIText.text = "" + FindObjectOfType<GameManager>().score;
        highestScoreUIText.text = "" + PlayerPrefs.GetInt("highestScore");
        gameOverUI.SetActive(true);
    }
    
}
