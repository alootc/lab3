using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimple : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Transform targetA;
    [SerializeField] private Transform targetB;

    private Vector2 isGoal;

    void Start()
    {
        isGoal = targetA.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == targetA.position)
        {
            isGoal = targetB.position;
        }
        else if(transform.position == targetB.position)
        {
            isGoal = targetA.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, isGoal, speed * Time.deltaTime);
    }
}
