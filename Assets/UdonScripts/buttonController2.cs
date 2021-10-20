
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class buttonController2 : UdonSharpBehaviour
{
    public bool look;
    public DoorController doorCtr;
    public GameObject warningCanvas;
    public GameObject jdDol;

    void Start()
    {
        look = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == jdDol)
        {
            doorCtr.ToggleDoor();
        }
        else
        {
            warningCanvas.SetActive(true);
        }
    }
}
