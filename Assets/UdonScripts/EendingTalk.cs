
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class EendingTalk : UdonSharpBehaviour
{
    public GameObject talk;
    public ParticleSystem particleObject;
    public AudioSource audioSource;
    public AudioController audioController;

    void Start()
    {
        particleObject.Stop();
    }

    public void Talk()
    {
        talk.SetActive(true);
    }

    public void UnTalk()
    {
        talk.SetActive(false);
        particleObject.Play();
    }

    public void EndingAudio()
    {
        audioSource.volume = 1.0f;
        audioController.BGMEnding();
        audioSource.Play();
    }

    public virtual void OnPlayerRespawn(VRC.SDKBase.VRCPlayerApi player)
    {
        if (player.isLocal || player.isMaster)
        {
            particleObject.Stop();
        }
    }
}
