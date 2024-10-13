using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnTime = 2;

    private float lastSpawnTime;

    void Start()
    {
        //spawn - copy the object
        Instantiate(pipePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if(lastSpawnTime + spawnTime < Time.time)
        {
            Instantiate(pipePrefab);
            lastSpawnTime = Time.time;
        }
    }
}
