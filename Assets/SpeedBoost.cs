using UnityEngine;
using System.Collections;

public class SpeedBoost : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public float bounceHeight = 0.5f;
    public float bounceSpeed = 2f;
    public float boostAmount = 40f;
    public float boostDuration = 2f;
    public AudioClip boostSound;  // Sound effect for the boost
    private AudioSource audioSource;  // Audio source to play the sound

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Spin
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Bounce
        float newY = startPos.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement movement = other.GetComponent<PlayerMovement>();
            if (movement != null)
            {
                audioSource.PlayOneShot(boostSound);
                StartCoroutine(ApplyBoostAndDestroy(movement));
            }
        }
    }

    private IEnumerator ApplyBoostAndDestroy(PlayerMovement movement)
    {
        // Apply the speed boost
        yield return StartCoroutine(movement.ApplySpeedBoost(boostAmount, boostDuration));
        // Destroy the boost after the coroutine finishes
        Destroy(gameObject);
    }
}