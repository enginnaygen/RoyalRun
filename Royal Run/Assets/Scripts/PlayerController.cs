using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float xClamp, zClamp;

    Vector2 movement;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    void HandleMovement()
    {
        Vector3 currentPositon = rb.position;
        Vector3 moveDirection = new Vector3(movement.x, 0f, movement.y);
        Vector3 newPosition = currentPositon + moveDirection * (moveSpeed * Time.fixedDeltaTime);

        float xClampValue = Mathf.Clamp(newPosition.x, -xClamp, xClamp);
        float zClampValue = Mathf.Clamp(newPosition.z, -zClamp, zClamp);

        newPosition = new Vector3(xClampValue, 0f, zClampValue);

        rb.MovePosition(newPosition);
        //rb.linearVelocity = direction * speed * Time.deltaTime;
    }
}
