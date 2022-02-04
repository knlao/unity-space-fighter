using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float bulletSpeed;

    private float reachPoint;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        reachPoint = transform.position.y + 10;
    }

    private void Update()
    {
        rb.velocity = Vector3.up * bulletSpeed;
        if (Mathf.Abs(transform.position.y) >= reachPoint)
        {
            Destroy(gameObject);
        }
    }
}
