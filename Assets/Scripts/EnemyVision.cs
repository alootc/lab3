using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private float speed;
    [SerializeField] private float rangeVision;
    [SerializeField] private LayerMask layer;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (CheckRangePlayer())
        {
            Vector2 dir = target.position - transform.position;

            rb.velocity = new Vector2(dir.normalized.x * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private bool CheckRangePlayer()
    {
        Vector2 dir = target.position - transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(dir.normalized.x, 0), rangeVision, layer);
        
        if(hit.collider != null)
        {
            return hit.collider.gameObject.CompareTag("Player");
        }
        return false;
    }
}
