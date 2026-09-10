using System.Numerics;
using UnityEditor.Callbacks;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float walkingSpeed = 5;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new UnityEngine.Vector2(vertical, horizontal);

    }
}