
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class japangi : UdonSharpBehaviour
{
    public ObjectPool opool;
    public Animator animator;


    void Interact()
    {
        animator.SetTrigger("buttonTrigger");
        opool.ActiveObject();
    }
}
