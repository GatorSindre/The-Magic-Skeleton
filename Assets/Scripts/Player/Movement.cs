using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float walkingSpeed = 5;
    public Rigidbody2D rb;
    public ParticleSystem sprintParticles;

    public InputAction MoveAction;
    public InputAction SprintAction;
    void OnEnable()
    {
        MoveAction.Enable();
        SprintAction.Enable();
    }
    void OnDisable()
    {
        MoveAction.Disable();
        SprintAction.Disable();
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (SprintAction.WasPressedThisFrame())
        {
            sprintParticles.Play();
        }
        if (SprintAction.WasReleasedThisFrame())
        {
            sprintParticles.Stop();
        }
    }
    void FixedUpdate()
    {
        Vector2 movement = MoveAction.ReadValue<Vector2>();

        if (movement.magnitude > 1)
            movement.Normalize();

        rb.linearVelocity = movement * walkingSpeed;
    }
}