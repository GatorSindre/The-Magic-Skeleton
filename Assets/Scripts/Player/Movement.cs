using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    float walkingSpeed = 8;
    public Rigidbody2D rb;
    ParticleSystem sprintParticles;
    public GameObject sprintParticle;
    
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
        sprintParticles = sprintParticle.GetComponent<ParticleSystem>();
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

        Vector2 movement_left_right = MoveAction.ReadValue<Vector2>();

        if (SprintAction.IsPressed())
        {
            walkingSpeed = 14;

            if (movement_left_right[0] > 0)
            {
                Vector3 currentEuler = transform.eulerAngles;
                currentEuler.x = -6f;
                currentEuler.y = -90f;
                currentEuler.z = 90f;
                sprintParticle.transform.rotation = Quaternion.Euler(currentEuler);
            }
            else if (movement_left_right[0] < 0)
            {
                Vector3 currentEuler = transform.eulerAngles;
                currentEuler.x = -174f;
                currentEuler.y = -90f;
                currentEuler.z = 90f;
                sprintParticle.transform.rotation = Quaternion.Euler(currentEuler);
            }
        } else
            walkingSpeed = 8;
    }
    void FixedUpdate()
    {
        Vector2 movement = MoveAction.ReadValue<Vector2>();

        movement = Vector2.ClampMagnitude(movement, 1);

        rb.linearVelocity = movement * walkingSpeed;
    }
}