
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class AudioTriggerController : UdonSharpBehaviour
{
    public bool isTrigger = false;
    public bool isFade = false;
    public AudioSource audioSource;

    private void Update()
    {
        if (isTrigger)
        {
            if (isFade)
            {
                FadeOut();
            }
            else
            {
                FadeIn();
            }
        }
    }

    public virtual void OnPlayerRespawn(VRC.SDKBase.VRCPlayerApi player)
    {
        if (player.isLocal || player.isMaster)
        {
            isTrigger = false;
            isFade = false;
        }
    }

    private void FadeOut()
    {
        if (audioSource.volume > 0.001f)
        {
            audioSource.volume -= Time.deltaTime / 2.5f;
        }
        else if (audioSource.volume <= 0.001f)
        {
            isTrigger = false;
        }
    }

    private void FadeIn()
    {
        if (audioSource.volume < 0.999f)
        {
            audioSource.volume += Time.deltaTime / 2.5f;
        }
        else if (audioSource.volume >= 0.999f)
        {
            isTrigger = false;
        }
    }
}
