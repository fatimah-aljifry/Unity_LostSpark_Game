using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderZonePuzzle : MonoBehaviour
{
    public RectTransform mover;       // The moving button
    public RectTransform targetZone;  // The green zone
    public Button stopButton;

    public Button closeButton;

    public GameObject image1;         // The initial image
    public GameObject image2;
    public GameObject panel;
    public AudioClip boostSound;  // Sound effect for the boost
    private AudioSource audioSource;  // Audio source to play the sound

    public float speed = 100f;
    private bool movingRight = true;
    private bool isMoving = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        stopButton.onClick.AddListener(CheckIfInZone);
        image2.SetActive(false);
        closeButton.onClick.AddListener(CloseAllImages); 
    }

    void Update()
    {
        if (!isMoving) return;

        float moveAmount = speed * Time.unscaledDeltaTime;

        if (movingRight)
            mover.anchoredPosition += new Vector2(moveAmount, 0);
        else
            mover.anchoredPosition -= new Vector2(moveAmount, 0);

        // Bounce at edges of the bar
        float barLeft = -((mover.parent as RectTransform).rect.width / 2);
        float barRight = -barLeft;

        if (mover.anchoredPosition.x >= barRight - mover.rect.width / 2)
            movingRight = false;
        else if (mover.anchoredPosition.x <= barLeft + mover.rect.width / 2)
            movingRight = true;
    }

    void CheckIfInZone()
    {
        isMoving = false;

        float moverLeft = mover.anchoredPosition.x - mover.rect.width / 2;
        float moverRight = mover.anchoredPosition.x + mover.rect.width / 2;

        float targetLeft = targetZone.anchoredPosition.x - targetZone.rect.width / 2;
        float targetRight = targetZone.anchoredPosition.x + targetZone.rect.width / 2;

        if (moverRight > targetLeft && moverLeft < targetRight)
        {
            audioSource.PlayOneShot(boostSound);
            image1.SetActive(false);
            image2.SetActive(true);
        }
        else {
            StartCoroutine(StopMovementForSeconds(1f));
        }
    }
    private IEnumerator StopMovementForSeconds(float waitTime)
    {
        isMoving = false;
        yield return new WaitForSecondsRealtime(waitTime); // unaffected by timeScale
        isMoving = true;
    }
    void CloseAllImages()  // 👈 new method
    {
        panel.SetActive(false);
        image1.SetActive(false);
        image2.SetActive(true);
        closeButton.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }
}

