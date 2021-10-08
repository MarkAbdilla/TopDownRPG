using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    BoxCollider2D boxColldier;

    Vector3 moveDelta;

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

        transform.Translate(GetMoveDelta() * Time.deltaTime);
    }

    private Vector3 GetMoveDelta()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x, y, 0);

        return moveDelta;
    }
}
