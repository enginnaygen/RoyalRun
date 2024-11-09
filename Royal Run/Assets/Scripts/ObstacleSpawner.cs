using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float spawnIntervalTime = 1;

    int obstacleSpawned = 0;
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
        while(obstacleSpawned < 5)
        {
            yield return new WaitForSeconds(spawnIntervalTime);
            GameObject obstacle = Instantiate(obstaclePrefab, transform.position,Quaternion.identity);
            obstacleSpawned++;
        }
    }
}
