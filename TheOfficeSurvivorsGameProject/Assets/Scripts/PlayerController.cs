using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField]
    private float speed;

    [Header("Dependencies")]
    [SerializeField]
    private Rigidbody2D _rigidbody;

    private Vector2 _movementInput;

    private void FixedUpdate()
    {
        _rigidbody.velocity = _movementInput * speed;
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        _movementInput = value.ReadValue<Vector2>();
    }
}
