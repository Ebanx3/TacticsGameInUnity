using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 camPosition;

    // float maxZoom = 5.5f;
    // float minZoom = 9.0f;

    float timeTouchStart = 0;

    Vector2 previousFramePosition = new Vector2();

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);


        }
        else if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                timeTouchStart = Time.time;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                timeTouchStart = 0;
            }
            Vector2 mov = previousFramePosition - touch.position;
            previousFramePosition = touch.position;
            if ((touch.phase == TouchPhase.Moved) && (Time.time - timeTouchStart >= 0.1f))
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x + (mov.x * Time.deltaTime * 0.3f), -7, 6), Mathf.Clamp(transform.position.y + (mov.y * Time.deltaTime * 0.3f), -7, -4.5f), -10);
            }
        }
        if (Input.GetMouseButton(0))
        {

            if (Input.GetMouseButtonDown(0))
            {
                timeTouchStart = Time.time;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                timeTouchStart = 0;
            }
            Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 mov = previousFramePosition - mousePos;
            previousFramePosition = mousePos;
            if ((Input.GetMouseButton(0)) && (Time.time - timeTouchStart >= 0.3f))
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x + (mov.x * Time.deltaTime * 0.3f), -7, 6), Mathf.Clamp(transform.position.y + (mov.y * Time.deltaTime * 0.3f), -7, -4.5f), -10);
            }
        }
    }

    private float DistanceBetweenPosition(Touch touch1, Touch touch2)
    {
        float distance = 0;

        return distance;
    }
}
