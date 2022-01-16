using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;

    private float timeSinceLastEnemy = 0;
    private float enemyCooldown = 2f;
    private int spawnCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        Spawn(enemy);
    }

    private void FixedUpdate()
    {
        timeSinceLastEnemy += Time.fixedDeltaTime;
        if (timeSinceLastEnemy > enemyCooldown)
        {
            timeSinceLastEnemy = 0;
            Spawn(enemy);
        }
    }

    private void Spawn(GameObject obj)
    {
        spawnCount += 1;
        transform.position = new Vector3(Random.Range(-29f, 29f), transform.position.y, transform.position.z);
        Instantiate(obj, transform.position, transform.rotation);

        if (spawnCount == 10)
        {
            enemyCooldown = 1.7f;
        }
        else if (spawnCount == 20)
        {
            enemyCooldown = 1.2f;
        }
        else if (spawnCount == 30)
        {
            enemyCooldown = .7f;
        }
        else if (spawnCount == 45)
        {
            enemyCooldown = .5f;
        }
    }
}
