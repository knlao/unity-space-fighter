using System;
using UnityEngine;
using UnityEngine.UI;

namespace Shop_Items
{
    public class IncreaseBulletSpeed : MonoBehaviour
    {
        public Button purchaseButton;
        public Text requireMoneyText;
        public Text currentLevelText;
        
        public int requireMoney;
        public float increaseSpeed;
        public int currentLevel;
        public int maxLevel;
        public int requireMoneyIncreaseRate;

        private void Start()
        {
            purchaseButton.enabled = true;
            requireMoneyText.text = "$" + requireMoney;
            currentLevelText.text = "Lv" + currentLevel;
        }

        public void Upgrade()
        {
            int score = FindObjectOfType<GameManager>().score;
            if (score >= requireMoney && currentLevel < maxLevel)
            {
                currentLevel++;
                FindObjectOfType<Player>().fireRate /= increaseSpeed;
                FindObjectOfType<GameManager>().score -= requireMoney;
                FindObjectOfType<UIManager>().UpdateScoreText(FindObjectOfType<GameManager>().score);
                requireMoney *= requireMoneyIncreaseRate;
            }

            if (currentLevel >= maxLevel)
            {
                purchaseButton.enabled = false;
                purchaseButton.GetComponent<Image>().color = Color.gray;
            }
            
            requireMoneyText.text = "$" + requireMoney;
            currentLevelText.text = "Lv" + currentLevel;
        }
    }
}