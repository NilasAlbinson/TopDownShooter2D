using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    Vector2 screenBoundery;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 2000f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void Update()
    {
        rb.velocity = moveInput * moveSpeed;
        if (moveInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, moveInput);
            Quaternion rotate = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            rb.MoveRotation(rotate);
        }
        else
        {
            rb.angularDrag = 0;
        }

        screenBoundery = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        transform.position = new Vector2(math.clamp(transform.position.x, -screenBoundery.x, screenBoundery.x), math.clamp(transform.position.y, -screenBoundery.y, screenBoundery.y));
    }
}
