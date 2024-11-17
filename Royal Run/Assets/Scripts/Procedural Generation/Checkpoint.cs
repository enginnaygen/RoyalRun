using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    [SerializeField] float increaseTime = 5f;

    GameManager gameManager;

    const string player = "Player";

    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(player))
        {
            gameManager.IncreaseTime(increaseTime);

        }

    }
}
