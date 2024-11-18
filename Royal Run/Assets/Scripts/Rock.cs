using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{

    [SerializeField] ParticleSystem collisionParticleSystem;
    [SerializeField] float shakeModifier = 10f;
    [SerializeField] float collisionCooldown = 1f;

    AudioSource collisionSFX;
    CinemachineImpulseSource cinemachineImpulseSource;

    float timer;

    private void Awake()
    {
        collisionSFX = GetComponent<AudioSource>();
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (timer > collisionCooldown)
        {
            CameraShake();
            CollisionFX(collision);
            timer = 0;
        }
    }

    private void CameraShake()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = (1f / distance) * shakeModifier;

        shakeIntensity = Mathf.Min(shakeIntensity, 1f);
        cinemachineImpulseSource.GenerateImpulse(shakeIntensity);
    }

    void CollisionFX(Collision collision)
    {
        ContactPoint contactPoint = collision.contacts[0];
        collisionParticleSystem.transform.position = contactPoint.point;       
        collisionParticleSystem.Play();
        collisionSFX.Play();
              
    }
}
