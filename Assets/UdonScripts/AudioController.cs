
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class AudioController : UdonSharpBehaviour
{
    private AudioSource audioSource;
    public AudioClip openingClip;
    public AudioClip playingClips;
    public AudioClip endingClips;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {

    }

    public void BGMOpening()
    {
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.clip = openingClip;
    }

    public void BGMPlaying()
    {
        audioSource.Stop();
        audioSource.loop = true;
        audioSource.clip = playingClips;
    }

    public void BGMEnding()
    {
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.clip = endingClips;
    }
}

