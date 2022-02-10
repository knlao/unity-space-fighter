using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace PowerUps
{
    public class Nuke : MonoBehaviour
    {
        private Vector3 target = new Vector3(0, 0, 0);
        public float damping = 1;

        public GameObject explosion;

        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, target, damping * Time.deltaTime);
            
            if (Vector3.Distance(new Vector3(0, 0, 0), transform.position) <= 1)
            {
                Instantiate(explosion);
                FindObjectOfType<NukeSFX>().PlaySFX(0);
                Collider[] enemies = Physics.OverlapSphere(transform.position, 100);
                foreach (Collider enemy in enemies)
                {
                    if (enemy.CompareTag("Enemy"))
                    {
                        FindObjectOfType<GameManager>().AddScore(100);
                        FindObjectOfType<UIManager>().UpdateScoreText(FindObjectOfType<GameManager>().score);
                        Destroy(enemy.gameObject);
                    }
                }
                
                Destroy(gameObject);
            }
        }
    }
}