
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class AudioOnTrigger : UdonSharpBehaviour
{
    public GameObject offTrigger;
    public AudioTriggerController atc;

    public virtual void OnPlayerTriggerEnter(VRC.SDKBase.VRCPlayerApi player)
    {
        if (player.isLocal || player.isMaster)
        {
            atc.isTrigger = true;
            atc.isFade = false;
            offTrigger.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
