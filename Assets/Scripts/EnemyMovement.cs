using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Rigidbody")]
    [SerializeField] private Rigidbody2D rb2D;

    [Header("Movement")]
    [SerializeField] private float speed;
    private float Aspeed;
    private float Bspeed;

    [Header("Path")]
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    private bool AtoB;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2D.position = new Vector2(pointA.position.x, rb2D.position.y);
        Bspeed=speed;
        Aspeed=(-Bspeed);
        AtoB=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(AtoB)
        {
            if(rb2D.position.x > pointB.position.x)
            {
                rb2D.velocity = new Vector2(Aspeed , rb2D.velocity.y);
            }
            else
            {
                AtoB=false;
            }
        }
        if(!AtoB)
        {
            if(rb2D.position.x < pointA.position.x)
            {
                rb2D.velocity = new Vector2 (Bspeed, rb2D.velocity.y);
            }
            else
            {
                AtoB=true;
            }
        }
    }
}
