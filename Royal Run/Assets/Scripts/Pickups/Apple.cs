using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float increseSpeed = .5f;

    LevelGenerator levelGenerator;

    private void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }
    protected override void OnPickup()
    {
        levelGenerator.ChangeMoveSpeedChunk(increseSpeed);

    }
}
