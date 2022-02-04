using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class Enemy : MonoBehaviour
{
    public float force;
    public bool canShoot = false;
    public GameObject bullet;
    public GameObject[] gunTypes;
    public int  currentGunType = 0;
    public float fireRate;
    public GameObject explosion;

    public int damage;
    public int score;
    

    private Rigidbody rb;
    private float nextShootTime;

    private float reachPoint;
    
    private float h, v;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        reachPoint = transform.position.y + 15;
    }
    
    private void Update()
    {
        rb.velocity = Vector3.down * force;
        
        if (canShoot && Time.time >= nextShootTime)
        {
            nextShootTime = Time.time + fireRate;
            ShootBullet();
        }
        
        if (Mathf.Abs(transform.position.y) >= reachPoint)
        {
            Destroy(gameObject);
        }
        
    }
    
    private void ShootBullet()
    {
        Transform[] guns = gunTypes[currentGunType-1].GetComponentsInChildren<Transform>();
        for (int i = 1; i < guns.Length; i++)
        {
            Instantiate(bullet, guns[i].position, new Quaternion(0, 0, 0, 0));
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        print(other.gameObject.name);
        
        if (other.gameObject.CompareTag("Player Bullet"))
        {
            Instantiate(explosion, transform.position, new Quaternion(0, 0, 0, 0));
            FindObjectOfType<GameManager>().AddScore(score);
            FindObjectOfType<SFX>().PlaySFX(1);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }        

        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(explosion, transform.position, new Quaternion(0, 0, 0, 0));
            FindObjectOfType<GameManager>().DoDamage(damage/2);
            FindObjectOfType<SFX>().PlaySFX(1);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player Base"))
        {
            FindObjectOfType<GameManager>().DoDamage(damage);
        }
        
    }
}
