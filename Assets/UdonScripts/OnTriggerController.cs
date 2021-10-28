
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class OnTriggerController : UdonSharpBehaviour
{
    public GameObject offTrigger;
    public GameObject anotherOnTrigger;
    public GameObject anotherOffTrigger;
    public GameObject[] models;

    void Start()
    {
        
    }

    public virtual void OnPlayerTriggerEnter(VRC.SDKBase.VRCPlayerApi player)
    {
        if (player.isLocal || player.isMaster)
        {
            offTrigger.SetActive(true);
            if (anotherOffTrigger != null)
                anotherOffTrigger.SetActive(true);
            if (anotherOnTrigger != null)
                anotherOnTrigger.SetActive(false);

            for (int i = 0; i < models.Length; i++)
            {
                models[i].SetActive(true);
            }

            gameObject.SetActive(false);
        }
    }
}
