using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float bulletSpeed;

    private float reachPoint;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        reachPoint = Mathf.Abs(transform.position.y) + 10;
        print(transform.rotation.eulerAngles.normalized);
    }

    private void Update()
    {
        rb.velocity = Vector3.up * bulletSpeed;
        if (Mathf.Abs(transform.position.y) >= reachPoint)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Bullet") || collision.gameObject.CompareTag("Player Bullet"))
        {
                print("BOOM!");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
