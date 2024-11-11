using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab;

    [SerializeField] float[] lanes = { -2.5f, 0f, 2.5f };
    [SerializeField] float appleSpawnChance = .3f;
    [SerializeField] float coinSpawnChance = .5f;
    [SerializeField] float coinSeperationLeght = 2.5f;

    List<int> avaliableLanes = new List<int> { 0, 1, 2 };

    void Start()
    {
        SpawnFence();
        SpawnApple();
        SpawnCoin();
    }

    void SpawnFence()
    {
        int fenceToSpawn = Random.Range(0, lanes.Length);

        for (int i = 0; i < fenceToSpawn; i++)
        {
            if (avaliableLanes.Count <= 0) break;
            int selectedLane = SelectLane();

            Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPos, Quaternion.identity, this.transform);
        }

    }

    void SpawnApple()
    {
        if (Random.value > appleSpawnChance) return;
        if (avaliableLanes.Count <= 0) return;

        int selectedLane = SelectLane();

        Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Instantiate(applePrefab, spawnPos, Quaternion.identity, this.transform);
    }

    void SpawnCoin()
    {
        if (Random.value > coinSpawnChance) return;
        if (avaliableLanes.Count <= 0) return;

        int selectedLane = SelectLane();


        int coinsToSpawn = Random.Range(0, 6);
        float topOfChunkPosZ = transform.position.z + (2 * coinSeperationLeght);

        for (int i = 0; i < coinsToSpawn; i++)
        {
            float spawnPositionZ = topOfChunkPosZ - (i * coinSeperationLeght);
            Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y, spawnPositionZ);
            Instantiate(coinPrefab, spawnPos, Quaternion.identity, this.transform);

        }
    }


    private int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, avaliableLanes.Count);
        int selectedLane = avaliableLanes[randomLaneIndex];

        avaliableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }
}
