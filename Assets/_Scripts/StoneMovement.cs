using UnityEngine;

public class StoneMovement : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (RoadMovement.CanMovement)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 2.0f);
        }
    }
}