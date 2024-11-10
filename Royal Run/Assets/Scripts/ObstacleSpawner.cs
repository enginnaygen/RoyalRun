using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] float spawnIntervalTime = 1;
    [SerializeField] Transform obstacleParent;
    [SerializeField] float spawnWidth = 4f;

    void Start()
    {
        StartCoroutine(CreateObstacle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CreateObstacle()
    {
        while(true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnWidth, spawnWidth), transform.position.y, transform.position.z);
            int randomObstacleNumber = Random.Range(0, obstaclePrefabs.Length);

            yield return new WaitForSeconds(spawnIntervalTime);

            Instantiate(obstaclePrefabs[randomObstacleNumber], spawnPosition, Random.rotation, obstacleParent);
        }
    }
}
