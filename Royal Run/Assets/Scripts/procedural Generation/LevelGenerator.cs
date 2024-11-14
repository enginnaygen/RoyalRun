using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] CameraController cameraController;
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunksAmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] int chunkLenght = 10;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float minMoveSpeed = 2f;
    //[SerializeField] float maxMoveSpeed = 15f;

    List<GameObject> chunks = new List<GameObject>();
    void Start()
    {
        SpawnStartingChunks();
    }

    void Update()
    {
        MoveChunks();
    }

    public void ChangeMoveSpeedChunk(float speedAdjustAmount)
    {       
        moveSpeed += speedAdjustAmount;

        if (moveSpeed < minMoveSpeed)
        {
            moveSpeed = minMoveSpeed;
        }

        /*if(moveSpeed > maxMoveSpeed)
        {
            moveSpeed = maxMoveSpeed;
        }*/

        Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, Physics.gravity.z - speedAdjustAmount);
        cameraController.ChangeCameraFOV(speedAdjustAmount);
    }
    void SpawnStartingChunks()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            SpawnChunk();

        }
    }

    private void SpawnChunk()
    {
        
        float spawnPositionZ = CalculateChunkPosition();
        GameObject newChunk = Instantiate(chunkPrefab, transform.position + new Vector3(0, 0, spawnPositionZ), Quaternion.identity, chunkParent);

        chunks.Add(newChunk);
    }

    private float CalculateChunkPosition()
    {
        if (chunks.Count == 0)
        {
            return transform.position.z;
        }
        else
        {
            return chunks[chunks.Count - 1].transform.position.z + chunkLenght;
        }
    }

    void MoveChunks()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunks[i].transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));

            if(chunk.transform.position.z <= Camera.main.transform.position.z - chunkLenght)
            {
                chunks.Remove(chunk);
                Destroy(chunk);

                SpawnChunk();
            }
        }
    }


}
