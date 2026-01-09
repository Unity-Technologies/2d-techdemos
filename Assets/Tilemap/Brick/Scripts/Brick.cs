using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class Brick : MonoBehaviour 
{
    public float moveSpeed = 1.0f;

    Rigidbody2D rb;

    InputAction moveAction;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        var move = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = move.x * Vector3.right * moveSpeed;
    }
}
