using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingPaddle : MonoBehaviour
{

    void FixedUpdate()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (mousePosition.y >= -3.7f && mousePosition.y <= 4)
        {
            if (mousePosition.x <= 6.92f && mousePosition.x >= -6.9f)
            {
                if (transform.position.x <= 6.93 && transform.position.x >= -6.89)
                    transform.position = new Vector2(mousePosition.x, -3.5f);
            }
        }
    }

    public void SetStartPosition()
    {
        transform.position = new Vector2(0f, transform.position.y);
    }
  
}
