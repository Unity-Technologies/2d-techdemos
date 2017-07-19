using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Brick : MonoBehaviour 
{
    public float moveSpeed = 1.0f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = Input.GetAxis("Horizontal") * Vector3.right * moveSpeed;
    }
}
