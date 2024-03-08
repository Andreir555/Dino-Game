using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGameOver : MonoBehaviour
{
    [SerializeField]
    private AudioClip deathClip;
    [SerializeField]
    private AudioSource audioSource;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Setup()
    {
        gameObject.SetActive(true);
        audioSource.Play();
    }

}
