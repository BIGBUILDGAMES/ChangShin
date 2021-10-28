
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class StartButtonController : UdonSharpBehaviour
{
    public DoorController doorCtr;
    public Animator animator;

    void Interact()
    {
        animator.SetTrigger("buttonTrigger");

        doorCtr.ToggleDoor();

    }
}
