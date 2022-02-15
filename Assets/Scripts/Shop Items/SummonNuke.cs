using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace Shop_Items
{
    public class SummonNuke : MonoBehaviour
    {
        public Button purchaseButton;
        public Text requireMoneyText;
        
        public int requireMoney;

        public GameObject nukePrefab;

        public bool isDisabled = false;

        public float reloadTime;
        private float nextEnableTime;

        private void Start()
        {
            purchaseButton.enabled = true;
            requireMoneyText.text = "$" + requireMoney;
        }

        private void Update()
        {
            if (isDisabled && Time.time >= nextEnableTime)
            {
                isDisabled = false;
            }

            purchaseButton.enabled = !isDisabled;
        }

        public void Summon()
        {
            int score = FindObjectOfType<GameManager>().score;
            if (score >= requireMoney)
            {
                Instantiate(nukePrefab, new Vector3(0, -15, 0), Quaternion.Euler(0, 0, 0));
                
                FindObjectOfType<GameManager>().score -= requireMoney;
                FindObjectOfType<UIManager>().UpdateScoreText(FindObjectOfType<GameManager>().score);
            }
            
            requireMoneyText.text = "$" + requireMoney;
            isDisabled = true;
            nextEnableTime = Time.time + reloadTime;
        }
    }
}