using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject[] powerUpItems;
    public Vector2 dropRate;

    private float nextShootTime;

    private void Update()
    {
        if (Time.time >= nextShootTime)
        {
            DropPowerUp();
            nextShootTime = Time.time + Random.Range(dropRate.x, dropRate.y);
        }
    }

    private void DropPowerUp()
    {
        GameObject item = powerUpItems[Random.Range(0, powerUpItems.Length - 1)];
        Vector2 spawnX = FindObjectOfType<EnemySpawner>().spawnX;
        Instantiate(item,
            new Vector3(Random.Range(spawnX.x, spawnX.y), 
                FindObjectOfType<EnemySpawner>().transform.position.y, 
                FindObjectOfType<EnemySpawner>().transform.position.z), 
            new Quaternion(0, 0, 0, 0));
    }

}
