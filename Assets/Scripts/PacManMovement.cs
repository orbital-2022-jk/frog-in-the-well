using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManMovement : MonoBehaviour
{
    public Vector3[] points; // In the editor, put your rectangle coordinates in here
    public Animator animator;
    public float movement_speed;
    private int nextPointIndex = 0;

    void Update()
    {
        // check if reached next point
        var reachedNextPoint = transform.position == points[nextPointIndex];

        if (reachedNextPoint)
        {
            // update index
            nextPointIndex++;

            // circular index
            if (nextPointIndex >= points.Length)
            {
                nextPointIndex = 0;
            }

            // update animation
            animator.SetInteger("index", nextPointIndex);
        }

        // move pacman
        transform.position = Vector3.MoveTowards(
            transform.position,
            points[nextPointIndex],
            movement_speed * Time.deltaTime
        );
    }
}
