
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class JongAvatarController : UdonSharpBehaviour
{
    public buttonController buttonCtr;
    public GameObject attiAvatar;
    public GameObject jongAvatar;

    void Interact()
    {
        buttonCtr.look = false;
        attiAvatar.SetActive(true);
        jongAvatar.SetActive(false);
    }
}
