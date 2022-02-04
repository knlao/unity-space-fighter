using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PowerUps
{
    public class Regeneration : MonoBehaviour
    {
        public int heal = 10;
        public int dropSpeed = 1;
        public float rotateSpeed = 1;
        
        private Rigidbody rb;
        private float reachPoint;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.down * dropSpeed;
            rb.AddTorque(new Vector3(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f)) * rotateSpeed);
            reachPoint = transform.position.y + 15;
        }

        private void Update()
        {
            if (Mathf.Abs(transform.position.y) >= reachPoint)
            {
                Destroy(gameObject);
            }
        }

        // private void OnTriggerEnter(Collider other)
        // {
        //     if (other.CompareTag("Player"))
        //     {
        //         FindObjectOfType<GameManager>().DoDamage(-heal);
        //         Destroy(this.gameObject);
        //         Destroy(this.gameObject);
        //         Destroy(this.gameObject);
        //         Destroy(this.gameObject);
        //         Destroy(this.gameObject);
        //         Destroy(this.gameObject);
        //         Destroy(this.gameObject);
        //         Destroy(this.gameObject);
        //         Destroy(this.gameObject);
        //         Destroy(this.gameObject);
        //     }
        // }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                FindObjectOfType<GameManager>().DoDamage(-heal);
                FindObjectOfType<SFX>().PlaySFX(3);
                Destroy(this.gameObject);
            }
        }
        
        
    }
}