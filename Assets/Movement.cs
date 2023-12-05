using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 30;
    Vector2 currentDir;
    Vector2 nextDir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckCollision(currentDir))
        {
            currentDir = nextDir;
            nextDir = Vector2.zero;
        }

        if (nextDir != Vector2.zero && !CheckCollision(nextDir))
        {
            currentDir = nextDir;
            nextDir = Vector2.zero;
        }
        else
        {
            rb.MovePosition(rb.position + currentDir * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (CheckCollision(Vector2.up)) nextDir = Vector2.up;
            else currentDir = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (CheckCollision(Vector2.down)) nextDir = Vector2.down;
            else currentDir = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (CheckCollision(Vector2.left)) nextDir = Vector2.left;
            else currentDir = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (CheckCollision(Vector2.right)) nextDir = Vector2.right;
            else currentDir = Vector2.right;
        }


    }

    bool CheckCollision(Vector2 dir)
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(rb.position, new Vector2(0.9f, 0.9f), 0f, dir, 0.1f);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.rigidbody.CompareTag("Wall"))
                return true;
        }
        return false;
    }

    // IEnumerator MovementCoroutine()
    // {
    //     while(true)
    //     {
    //         if(CheckCollision(currentDir))
    //         {
    //             currentDir = nextDir2;
    //             nextDir2 = Vector2.zero;
    //         } 
    //         else
    //         {
    //             rb.MovePosition(rb.position + currentDir * Time.deltaTime);
    //         }
    //     }
    // }
}
