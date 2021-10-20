
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PlayButtonController : UdonSharpBehaviour
{
    public GameObject opening;

    void Interact()
    {
        opening.SetActive(true);
    }
}
