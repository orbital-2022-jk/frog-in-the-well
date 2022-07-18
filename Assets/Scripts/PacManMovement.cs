using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManMovement : MonoBehaviour
{
    public Vector3[] points; // In the editor, put your rectangle coordinates in here
    private SpriteRenderer sr;
    public Sprite[] sprites;
    public float movement_speed;
    private int nextPointIndex = 0;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var reachedNextPoint = transform.position == points[nextPointIndex];

        if (reachedNextPoint)
        {
            nextPointIndex++;
            if (nextPointIndex >= points.Length)
            {
                nextPointIndex = 0;
            }
            sr.sprite = sprites[nextPointIndex];
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            points[nextPointIndex],
            movement_speed * Time.deltaTime
        );
    }
}
