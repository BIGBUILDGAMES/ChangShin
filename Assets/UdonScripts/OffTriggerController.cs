
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class OffTriggerController : UdonSharpBehaviour
{
    public GameObject onTrigger;
    public GameObject anotherOnTrigger;
    public GameObject anotherOffTrigger;
    public GameObject[] models;


    public virtual void OnPlayerTriggerEnter(VRC.SDKBase.VRCPlayerApi player)
    {
        if (player.isLocal || player.isMaster)
        {
            onTrigger.SetActive(true);
            if (anotherOffTrigger != null)
                anotherOffTrigger.SetActive(true);
            if (anotherOnTrigger != null)
                anotherOnTrigger.SetActive(false);

            for (int i = 0; i < models.Length; i++)
            {
                models[i].SetActive(false);
            }

            gameObject.SetActive(false);
        }
    }
}
