using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button closeButton;

    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject panel;
    public AudioClip boostSound;  // Sound effect for the boost
    private AudioSource audioSource;  // Audio source to play the sound


    void Start()
    {
        // Show first image at the beginning
        audioSource = GetComponent<AudioSource>();
        image1.SetActive(true);
        image2.SetActive(false);
        image3.SetActive(false);
        closeButton.gameObject.SetActive(false); // hide close button

        button1.onClick.AddListener(ShowImage2);
        button2.onClick.AddListener(ShowImage3);
        closeButton.onClick.AddListener(CloseAll);
    }

    void ShowImage2()
    {
        image1.SetActive(false);
        image2.SetActive(true);
        image3.SetActive(false);
    }

    void ShowImage3()
    {
        audioSource.PlayOneShot(boostSound);
        image1.SetActive(false);
        image2.SetActive(false);
        image3.SetActive(true);
        closeButton.gameObject.SetActive(true); // show close button
    }

    void CloseAll()
    {
        panel.SetActive(false);
        image1.SetActive(false);
        image2.SetActive(false);
        image3.SetActive(true);
        closeButton.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }
}