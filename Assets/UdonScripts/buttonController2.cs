
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class buttonController2 : UdonSharpBehaviour
{
    public bool look = false;
    public DoorController doorCtr;
    public GameObject[] jdDol;

    private void OnCollisionEnter(Collision collision)
    {
        if (!look)
        {
            for (int i = 0; i < 10; i++)
            {
                if (collision.gameObject == jdDol[i])
                {
                    doorCtr.ToggleDoor();
                    look = true;
                    return;
                }
            }
        }
    }

    public virtual void OnPlayerRespawn(VRC.SDKBase.VRCPlayerApi player)
    {
        if (player.isLocal || player.isMaster)
        {
            look = false;
        }
    }
}
