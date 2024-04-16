using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public List<Enemy> enemyList;

    public Enemy enemy;
    public Transform spawnLocation;

    public int numberOfEnemies;

    private float _enemyHealth;
    private float _enemyDamage;
    private float _enemySpeed;
    private float _enemyPositionX;

    private void Awake()
    {
        for (int i = 0; i < numberOfEnemies; i++)
            enemyList.Add(enemy);
    }


    void Start()
    {
        foreach (Enemy enemy in enemyList)
        {
            GenerateStats();
            Spawn();
        }
    }

    public void GenerateStats()
    {
        _enemyHealth = Random.Range(25, 100);
        _enemyDamage = Random.Range(5, 25);
        _enemySpeed = Random.Range(1, 5);
        _enemyPositionX = Random.Range(8, 20);
        spawnLocation.position = new Vector3(_enemyPositionX, spawnLocation.position.y, spawnLocation.position.z);
    }
    
    public void Spawn()
    {
        enemy.health = _enemyHealth;
        enemy.damage = _enemyDamage;
        enemy.speed = _enemySpeed;

        enemy = Instantiate(enemy, spawnLocation.position, Quaternion.identity);
    }
}
