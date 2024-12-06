using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 50;
    public float horizontalSpeed = 3;
    public float rightLimit = 9.5f;
    public float leftLimit = -9.5f;

    private Vector2 touchStartPosition;
    private Vector2 touchEndPosition;
    private bool isSwiping = false;

    void Update()
    {
        // Move the player forward
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

        // Keyboard input for horizontal movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > leftLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < rightLimit)
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
            }
        }

        // Touch input for swipe detection
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPosition = touch.position;
                    isSwiping = true;
                    break;

                case TouchPhase.Moved:
                    touchEndPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    if (isSwiping)
                    {
                        Vector2 swipeDirection = touchEndPosition - touchStartPosition;

                        // Determine if swipe is horizontal
                        if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
                        {
                            if (swipeDirection.x > 0) // Swipe right
                            {
                                if (this.gameObject.transform.position.x < rightLimit)
                                {
                                    transform.Translate(Vector3.right * horizontalSpeed);
                                }
                            }
                            else if (swipeDirection.x < 0) // Swipe left
                            {
                                if (this.gameObject.transform.position.x > leftLimit)
                                {
                                    transform.Translate(Vector3.left * horizontalSpeed);
                                }
                            }
                        }
                        isSwiping = false;
                    }
                    break;
            }
        }
    }
}
