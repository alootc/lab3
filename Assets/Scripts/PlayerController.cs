using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int health = 100;
    [SerializeField] private int Coins = 0;

    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpForce = 1.0f;

    [Header("Grounded")]
    [SerializeField] private float distance = 0.5f;
    [SerializeField] private LayerMask groundLayer;

    
    private Rigidbody2D rb;

    [SerializeField] private float horizontal;

    public static event Action<int> onPlayerDamage;
    public static event Action<int> onPlayerGetCoin;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //onPlayerDamage = TakeDamage;
    }

    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void TakeDamage(int damage)
    {
        health = Mathf.Clamp(health - damage, 0, 100);

        onPlayerDamage?.Invoke(health);
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance, groundLayer);
        return hit.collider != null;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
        else if (collision.CompareTag("Coin"))
        {
            Coins += 10;
            onPlayerGetCoin?.Invoke(Coins);

            Destroy(collision.gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = IsGrounded() ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * distance);
    }
}
