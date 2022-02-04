using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float force;
    public GameObject bullet;
    public GameObject explosion;
    public GameObject[] gunTypes;
    public int  currentGunType = 0;
    public float fireRate;
    
    private Rigidbody rb;
    private float _h, _v;
    private float nextShootTime;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(_h, _v, 0) * force;
        
        _h *= 1 - Time.deltaTime;
        _v *= 1 - Time.deltaTime;

        if (Time.time >= nextShootTime)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                ShootBullet();
                nextShootTime = Time.time + fireRate;
            }
        }

        Vector3 pos = transform.position;
        transform.position = new Vector3(
            Mathf.Clamp(pos.x, -2.3f, 2.3f), 
            Mathf.Clamp(pos.y, -4, 4),
            pos.z
            );
    }

    private void ShootBullet()
    {
        Transform[] guns = gunTypes[currentGunType-1].GetComponentsInChildren<Transform>();
        FindObjectOfType<SFX>().PlaySFX(0);
        for (int i = 1; i < guns.Length; i++)
        {
            Instantiate(bullet, guns[i].position, new Quaternion(0, 0, 0, 0));
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy Bullet"))
        {
            Instantiate(explosion, transform.position, new Quaternion(0, 0, 0, 0));
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
