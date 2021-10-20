
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MirrorTriggerController : UdonSharpBehaviour
{
    public GameObject mirror;

    public virtual void OnPlayerTriggerEnter(VRC.SDKBase.VRCPlayerApi player)
    {
        mirror.SetActive(true);
    }

    public virtual void OnPlayerTriggerExit(VRC.SDKBase.VRCPlayerApi player)
    {
        mirror.SetActive(false);
    }
}
