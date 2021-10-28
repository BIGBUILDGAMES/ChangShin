
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class AudioOffTrigger : UdonSharpBehaviour
{
    public AudioTriggerController atc;
    public GameObject onTrigger;

    public virtual void OnPlayerTriggerEnter(VRC.SDKBase.VRCPlayerApi player)
    {
        if (player.isLocal || player.isMaster)
        {
            atc.isTrigger = true;
            atc.isFade = true;
            onTrigger.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
