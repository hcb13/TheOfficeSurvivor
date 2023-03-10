using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField]
    private Animator animator;

    public void OnMovement(InputAction.CallbackContext value)
    {
        float movementInput = value.ReadValue<Vector2>().magnitude;

        animator.SetBool("IsIdle", movementInput <= 0);

        animator.SetBool("IsUp", value.ReadValue<Vector2>().y > 0);

        animator.SetFloat("IsLeft", value.ReadValue<Vector2>().x);

    }
}
