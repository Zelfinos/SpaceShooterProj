using UnityEngine;

public class WallMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    void Update()
    {
        transform.Translate(new Vector2(0, -speed) *  Time.deltaTime);  
    }
}
