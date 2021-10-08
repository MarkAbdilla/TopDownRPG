using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    BoxCollider2D boxColldier;

    Vector3 moveDelta;
    RaycastHit2D hit;

    void Start()
    {
       boxColldier = GetComponent<BoxCollider2D>(); 
    }

    void FixedUpdate()
    {
        GetMoveDelta();

        if (GetMoveDelta().x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (GetMoveDelta().x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        hit = Physics2D.BoxCast(transform.position, boxColldier.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        
        if (hit.collider == null)
        {
            transform.Translate(0, GetMoveDelta().y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxColldier.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        
        if (hit.collider == null)
        {
            transform.Translate(GetMoveDelta().x * Time.deltaTime, 0, 0);
        }

    }

    private Vector3 GetMoveDelta()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x, y, 0);

        return moveDelta;
    }
}
