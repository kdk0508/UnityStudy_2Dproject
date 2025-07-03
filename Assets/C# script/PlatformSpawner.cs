using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public int count = 3;

    public float timeBetMin = 1.5f;
    public float timeBetMax = 2.5f;
    private float timeBetSpawn;

    public float yMin = -3.5f;
    public float yMax = 1.5f;
    private float xPos = 20f;

    private GameObject[] platform;
    private int currentindex;

    private Vector2 poolPos = new Vector2(0, -25);
    private float lastSpawnTme;
    // Start is called before the first frame update
    void Start()
    {
        platform = new GameObject[count];

        for(int i = 0; i < count; i++)
        {
            platform[i] = Instantiate(platformPrefab, poolPos, Quaternion.identity);
        }

        timeBetSpawn = 0f;
        lastSpawnTme = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isGameOver()) { return; }

        if(Time.time >= lastSpawnTme + timeBetSpawn)
        {
            lastSpawnTme = Time.time;
            timeBetSpawn = Random.Range(timeBetMin, timeBetMax);
        }
    }
}
