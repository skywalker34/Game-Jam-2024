    using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnpoint;
    public GameObject goblinPrefab;
    public int enemyCount = 0;
    public int enemyLimit = 3;

    public float minWait;
    public float maxWait;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount == 0)
        {
            float timer = Random.Range(minWait, maxWait);
            Invoke("spawn", timer);
        }
    }

    void spawn()
    {
        if (enemyCount >= enemyLimit) return;

        Instantiate(goblinPrefab, spawnpoint.position, spawnpoint.rotation);

        enemyCount++;
    }
}
