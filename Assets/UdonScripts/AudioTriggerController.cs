
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class AudioTriggerController : UdonSharpBehaviour
{
    public bool isAudio;
    private bool isTrigger;
    public AudioSource audioSource;

    void Start()
    {
        isAudio = false;
        isTrigger = false;
    }

    public virtual void OnPlayerTriggerEnter(VRC.SDKBase.VRCPlayerApi player)
    {
        if (player.isLocal || player.isMaster)
        {
            isTrigger = true;
        }
    }

    private void Update()
    {
        if (isTrigger && !isAudio && audioSource.volume > 0f)
        {
            audioSource.volume -= Time.deltaTime / 2.5f;
        }
    }

    public virtual void OnPlayerRespawn(VRC.SDKBase.VRCPlayerApi player)
    {
        if (player.isLocal || player.isMaster)
        {
            isAudio = false;
            isTrigger = false;
        }
    }
}
