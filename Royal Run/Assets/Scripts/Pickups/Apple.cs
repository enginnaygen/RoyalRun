using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float increseSpeed = .5f;

    LevelGenerator levelGenerator;

    public void Init(LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;
    }
    protected override void OnPickup()
    {
        levelGenerator.ChangeMoveSpeedChunk(increseSpeed);

    }
}
