using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    private float scrollSpeed = 2.0f;
    private Vector2 startPosition;
    private float bgHeight;

    public static bool CanMovement;

    private void Start()
    {
        CanMovement = true;
        startPosition = transform.position;
        bgHeight = GetComponent<BoxCollider2D>().size.y / 2f;
    }

    private void Update()
    {
        MoveBackground();
    }

    private void MoveBackground()
    {
        if (CanMovement)
        {
            transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);
            if (transform.position.y < (startPosition.y - bgHeight))
            {
                RepositionBackground();
            }
        }
    }

    private void RepositionBackground()
    {
        transform.position = startPosition;
    }
}