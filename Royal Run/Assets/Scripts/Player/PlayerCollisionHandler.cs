using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{

    [SerializeField] float collsionCooldown = 1f;
    [SerializeField] Animator animator;

    const string hitTrigger = "Hit";
    float timer = 0;
    
    private void Update()
    {
        timer += Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(timer > collsionCooldown)
        {
            animator.SetTrigger(hitTrigger);
            timer = 0f;

        }

    }

    
}
