using UnityEngine;

public class AlienMover : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float directionChangeInterval = 3f; // Time in seconds between direction changes
    private Vector3 moveDirection;
    private float timer;

    void Start()
    {
        ChooseNewDirection();
        timer = directionChangeInterval;
    }

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            ChooseNewDirection();
            timer = directionChangeInterval;
        }
    }

    void ChooseNewDirection()
    {
        // Pick a new random flat direction
        moveDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Reflect direction when hitting something
        moveDirection = Vector3.Reflect(moveDirection, collision.contacts[0].normal);
    }
}
