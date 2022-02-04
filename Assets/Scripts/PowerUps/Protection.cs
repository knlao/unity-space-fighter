using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PowerUps
{
    public class Protection : MonoBehaviour
    {
        public int heal = 20;
        public int dropSpeed = 1;
        public float rotateSpeed = 1;
        
        private Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.down * dropSpeed;
            rb.AddTorque(new Vector3(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f)) * rotateSpeed);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                FindObjectOfType<GameManager>().DoDamage(-heal);
                Destroy(this.gameObject);
            }
        }
    }
}