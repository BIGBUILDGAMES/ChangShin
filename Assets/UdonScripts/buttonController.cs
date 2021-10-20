using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class buttonController : UdonSharpBehaviour
{
    public bool look;
    public DoorController doorCtr;
    public GameObject warningCanvas;
    public Animator animator;

    void Start()
    {
        look = true;
    }

    void Interact()
    {
        animator.SetTrigger("buttonTrigger");

        if (!look)
        {
            doorCtr.ToggleDoor();
        }
        else
        {
            warningCanvas.SetActive(true);
        }
    }
}
