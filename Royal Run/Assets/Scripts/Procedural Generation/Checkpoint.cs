using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    [SerializeField] float increaseTime = 5f;
    [SerializeField] float decreaseSpawnTimeAmount = .1f;

    GameManager gameManager;
    ObstacleSpawner obstacleSpawner;

    const string player = "Player";

    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(player))
        {
            gameManager.IncreaseTime(increaseTime);
            obstacleSpawner.DesreaseSpawnTime(decreaseSpawnTimeAmount);

        }

    }
}
