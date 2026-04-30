using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 7f;
    public float laneSwitchSpeed = 10f;
    public float[] lanes = { -4f, 0f, 4f };
    public float swipeThresholdPixels = 50f;

    int currentLane = 1;
    Vector2 touchStartPosition;
    bool isSwiping;

    void Start()
    {
        currentLane = ClosestLane(transform.position.x);
    }

    void Update()
    {
        if (!GameState.IsPlaying) return;

        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ShiftLane(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            ShiftLane(+1);
        }

        HandleTouch();

        float targetX = lanes[currentLane];
        Vector3 p = transform.position;
        p.x = Mathf.MoveTowards(p.x, targetX, laneSwitchSpeed * Time.deltaTime);
        transform.position = p;
    }

    void HandleTouch()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);
        switch (touch.phase)
        {
            case TouchPhase.Began:
                touchStartPosition = touch.position;
                isSwiping = true;
                break;

            case TouchPhase.Ended:
            case TouchPhase.Canceled:
                if (!isSwiping) break;
                isSwiping = false;
                Vector2 delta = touch.position - touchStartPosition;
                if (Mathf.Abs(delta.x) < swipeThresholdPixels) break;
                if (Mathf.Abs(delta.x) <= Mathf.Abs(delta.y)) break;
                ShiftLane(delta.x > 0 ? +1 : -1);
                break;
        }
    }

    void ShiftLane(int direction)
    {
        currentLane = Mathf.Clamp(currentLane + direction, 0, lanes.Length - 1);
    }

    int ClosestLane(float x)
    {
        int best = 0;
        float bestDist = Mathf.Abs(x - lanes[0]);
        for (int i = 1; i < lanes.Length; i++)
        {
            float d = Mathf.Abs(x - lanes[i]);
            if (d < bestDist) { bestDist = d; best = i; }
        }
        return best;
    }
}
