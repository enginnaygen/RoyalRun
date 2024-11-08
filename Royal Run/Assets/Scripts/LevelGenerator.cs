using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunksAmount = 12;
    [SerializeField] Transform chunkParent;
    void Start()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            float spawnPositionZ = transform.position.z + i * 10;
            Instantiate(chunkPrefab, transform.position +new Vector3(0,0,spawnPositionZ), Quaternion.identity, chunkParent);

        }
    }

    void Update()
    {
        
    }


}
