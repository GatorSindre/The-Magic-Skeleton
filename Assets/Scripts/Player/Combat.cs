using UnityEngine;
using UnityEngine.InputSystem;

public class Combat : MonoBehaviour
{
    public InputAction Attack;
    void OnEnable()
    {
        Attack.Enable();
    }
    void OnDisable()
    {
        Attack.Disable();
    }
    void Update()
    {
        if (Attack.WasPressedThisFrame())
        {
            Debug.Log("Attack");
            
        }
    }
}