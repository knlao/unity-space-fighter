using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public int score;

    public GameObject canvas;
    public GameObject infoText;

    public Text healthText;
    public Text maxHealthText;

    public bool isGameOver = false;

    private void Start()
    {
        FindObjectOfType<HealthBar>().SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (!isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Time.timeScale == 0)
                {
                    FindObjectOfType<UIManager>().Resume();
                }
                else
                {
                    FindObjectOfType<UIManager>().Pause();
                }
            }
        }
        healthText.text = "" + health;
        maxHealthText.text = "" + maxHealth;
    }

    public void DoDamage(int dmg)
    {
        health -= dmg;
        
        if (-dmg > 0 && health < maxHealth)
        {
            GameObject t = Instantiate(infoText, canvas.transform);
            t.GetComponent<InfoText>().ChangeText("+" + (-dmg) + " health");
        }
        health = Mathf.Clamp(health, 0, maxHealth);
        FindObjectOfType<UIManager>().UpdateHealthBar(health);
        CheckDeath();
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            print("You died.");
            isGameOver = true;

            int highestScore = PlayerPrefs.GetInt("highestScore");
            if (highestScore < score)
            {
                PlayerPrefs.SetInt("highestScore", score);
            }
            
            Destroy(FindObjectOfType<Player>().gameObject);
            FindObjectOfType<UIManager>().GameOver();
        }
    }

    public void AddScore(int s)
    {
        score += s;
        print(score);
        FindObjectOfType<UIManager>().UpdateScoreText(score);
    }
}
