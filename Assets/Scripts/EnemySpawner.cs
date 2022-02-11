using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPref;
    public GameObject enemyFollowPref;
    public GameObject[] paths;
    public Vector2 spawnX;
    public Vector2 spawnRate;
    public float increaseRateRatio;
    public float increaseTimeBetween;

    private float nextSpawnTime;
    private float nextIncreaseTime;

    private void Start()
    {
        nextIncreaseTime = Time.time + increaseTimeBetween;
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + Random.Range(spawnRate.x, spawnRate.y);
        }
        if (Time.time >= nextIncreaseTime)
        {
            spawnRate.x *= 1 / increaseRateRatio;
            spawnRate.y *= 1 / increaseRateRatio;
            nextIncreaseTime = Time.time + increaseTimeBetween;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 pos = transform.position;
        if (Random.Range(0, 1f) < 0.1)
        {
            GameObject newEnemy = Instantiate(enemyFollowPref,
                new Vector3(Random.Range(spawnX.x, spawnX.y), 
                    pos.y, 
                    pos.z), 
                new Quaternion(0, 0, 0, 0));
            newEnemy.GetComponent<FollowPath>().targets = paths[Random.Range(0, paths.Length)];
        }
        else
        {
            GameObject newEnemy = Instantiate(enemyPref,
                        new Vector3(Random.Range(spawnX.x, spawnX.y), 
                            pos.y, 
                            pos.z), 
                        new Quaternion(0, 0, 0, 0));
            if (Random.Range(0, 1f) < 0.1)
            {
                newEnemy.GetComponent<Enemy>().canShoot = true;
            }
            
            // newEnemy.GetComponent<Enemy>().canShoot = true;
        }
    }
}
