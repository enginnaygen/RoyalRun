using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float spawnIntervalTime = 1;

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
            yield return new WaitForSeconds(spawnIntervalTime);
            GameObject obstacle = Instantiate(obstaclePrefab, transform.position,Random.rotation);
        }
    }
}
