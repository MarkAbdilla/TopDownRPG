using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform lookAt;
    [SerializeField] float boundX = 0.15f;
    [SerializeField] float boundY = 0.05f;
    
    Vector3 delta;

    void LateUpdate()
    {
        delta = Vector3.zero;
        CheckX();
        CheckY();

        transform.position += new Vector3(CheckX(), CheckY(), 0);
    }

    private float CheckX()
    {
        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }
        return delta.x;
    }

    private float CheckY()
    {
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.x < lookAt.position.x)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }
        return delta.y;
    }
}
