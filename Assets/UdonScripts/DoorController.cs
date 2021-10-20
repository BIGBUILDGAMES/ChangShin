
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class DoorController : UdonSharpBehaviour
{
    private Animator animator;
    private bool onOff;

    void Start()
    {
        onOff = true;
        animator = GetComponent<Animator>();
    }

    public void ToggleDoor()
    {
        if (onOff)
        {
            animator.SetBool("isOpen", true); // 열림
            onOff = false;
        }
        else
        { 
            animator.SetBool("isOpen", false); // 닫힘
            onOff = true;
        }
    }
    
    public void CloseDoor()
    {
        animator.SetBool("isOpen", false); // 닫힘
        onOff = true;
    }

    public virtual void OnPlayerRespawn(VRC.SDKBase.VRCPlayerApi player)
    {
        if (player.isLocal || player.isMaster)
        {
            CloseDoor();
        }
    }
}
