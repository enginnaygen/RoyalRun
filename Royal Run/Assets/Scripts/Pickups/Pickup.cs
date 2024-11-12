using Unity.Hierarchy;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{

    const string playerTag = "Player";

    [SerializeField] float rotationSpeed = 100f;

    private void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(playerTag))
        {
            OnPickup();
            Destroy(gameObject);

        }
    }

    protected abstract void OnPickup();
}
