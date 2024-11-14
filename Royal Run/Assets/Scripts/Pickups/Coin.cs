using UnityEngine;

public class Coin : Pickup
{
    [SerializeField] int increaseScoreAmount = 100;

    ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }
    protected override void OnPickup()
    {
        scoreManager.ChangeScore(increaseScoreAmount);
    }
}
