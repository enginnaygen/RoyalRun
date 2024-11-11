using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    const string playerTag = "Player";

    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.CompareTag(playerTag))
        {
            Debug.Log(collision.gameObject.name);
        }
    }
}
