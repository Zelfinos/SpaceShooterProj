using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField] 
    private SpriteRenderer surfaceRenderer; // The sprite that defines boundaries
    [SerializeField]
    private float randomDirectionInterval = 3f;
    [SerializeField] 
    private float smoothTurnTime = 0.2f;


    private float minX, maxX; // Movement limits
    private float targetDirection = 1f;
    private float currentDirection = 1f; // Movement direction
    private float nextDirectionChangeTime = 0f;


    private void Start()
    {
        // Calculate boundaries based on the surface sprite
        minX = surfaceRenderer.bounds.min.x;
        maxX = surfaceRenderer.bounds.max.x;
    }

    private void FixedUpdate()
    {
        currentDirection = Mathf.Lerp(currentDirection, targetDirection, smoothTurnTime);

        transform.Translate(Vector2.right * currentDirection * Speed * Time.deltaTime);

        if (transform.position.x <= minX || transform.position.x >= maxX)
        {
            targetDirection *= -1;
        }

        if (Time.time >= nextDirectionChangeTime)
        {
            if (Random.value < 0.2f) // 20% chance every X seconds
            {
                targetDirection *= -1;
            }

            // Schedule the next possible random change
            nextDirectionChangeTime = Time.time + randomDirectionInterval;
        }
    }

}
