using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{

    [SerializeField] float collsionCooldown = 1f;
    [SerializeField] Animator animator;
    [SerializeField] float decreaseSpeedAmount = -2f; 

    const string hitTrigger = "Hit";
    float timer = 0;

    LevelGenerator levelGenerator;

    private void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }
    private void Update()
    {
        timer += Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(timer > collsionCooldown)
        {
            levelGenerator.ChangeMoveSpeedChunk(decreaseSpeedAmount);
            animator.SetTrigger(hitTrigger);
            timer = 0f;

        }

    }

    
}
