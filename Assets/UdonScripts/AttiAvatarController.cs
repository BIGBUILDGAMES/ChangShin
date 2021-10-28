
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class AttiAvatarController : UdonSharpBehaviour
{
    public buttonController buttonCtr;
    public DoorController doorCtr;
    public GameObject jongAvatar;
    public GameObject attiAvatar;

    void Interact()
    {
        buttonCtr.look = true;
        doorCtr.CloseDoor();
        jongAvatar.SetActive(true);
        attiAvatar.SetActive(false);
    }

    public virtual void OnPlayerRespawn(VRC.SDKBase.VRCPlayerApi player)
    {
        if (player.isLocal || player.isMaster)
        {
            jongAvatar.SetActive(true);
            attiAvatar.SetActive(false);
        }
    }
}
