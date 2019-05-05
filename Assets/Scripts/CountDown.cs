using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CountDown : MonoBehaviour
{
    public AudioClip[] clipNumbers;

    private Animator animator;
    private AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;

    }
    // Update is called once per frame
    public void finishCountdown()
    {
        GameManager.instance.StartGame();
    }

    public void PlaySound(int numberValue)
    {
        audioSource.clip = clipNumbers[numberValue];
        audioSource.Play();
    }
}
