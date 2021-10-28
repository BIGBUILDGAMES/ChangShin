
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class LookAtPlayer : UdonSharpBehaviour
{
    private Vector3 playerPos;
    VRCPlayerApi playerApi;

    private void Start()
    {
        playerApi = Networking.LocalPlayer;
        playerPos = playerApi.GetPosition();
    }

    private void Update()
    {
        Vector3 vec = playerPos - transform.position;
        vec.Normalize();
        Quaternion q = Quaternion.LookRotation(vec);
        transform.rotation = q;
    }
}
