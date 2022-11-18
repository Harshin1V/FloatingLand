using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyRb;
    public GameObject powerUpRb;
    PlayerController _player;
    float spawnRange = 9;
    public int enemyCount = 0;
    public int waveCount = 0;

    private void Start()
    {
        waveCount = 1;
        SpawnEnemy(waveCount);
        Instantiate(powerUpRb, GenerateRandomPos(),transform.rotation);
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount==0 && !_player.gameOver)
        {
            waveCount++;
            SpawnEnemy(waveCount);
            Instantiate(powerUpRb, GenerateRandomPos(), transform.rotation);
        }
    }
    void SpawnEnemy(int numEnemies)
    {
        for(int i=0;i<numEnemies;i++)
        {
            Instantiate(enemyRb, GenerateRandomPos(), transform.rotation);
        }
    }
    Vector3 GenerateRandomPos()
    {
        float posX = Random.Range(-spawnRange, spawnRange);
        float posY = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(posX, 0, posY);
        return randomPos;
    }
}
