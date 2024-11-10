using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] float[] lanes = { -2.5f, 0f, 2.5f };
    void Start()
    {
        SpawnFence();
    }

    void SpawnFence()
    {
        List<int> avaliableLanes = new List<int> { 0, 1, 2 };
        int fenceToSpawn = Random.Range(0, lanes.Length);

        for (int i = 0; i < fenceToSpawn; i++)
        {
            if (avaliableLanes.Count <= 0) break;

            int randomLaneIndex = Random.Range(0, avaliableLanes.Count);
            int selectedLane = avaliableLanes[randomLaneIndex];

            avaliableLanes.RemoveAt(randomLaneIndex);

            Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPos, Quaternion.identity, this.transform);
        }
        
    }
}
