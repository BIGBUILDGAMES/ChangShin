
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class AvatarPedestalController : UdonSharpBehaviour
{
    public GameObject jongAvatar;
    public GameObject attiAvatar;
    public buttonController buttonCtr;

    public virtual void OnPlayerRespawn(VRC.SDKBase.VRCPlayerApi player)
    {
        buttonCtr.look = true;
        attiAvatar.SetActive(false);
        jongAvatar.SetActive(true);
    }
}
