
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class EndingLogoOpen : UdonSharpBehaviour
{
    private bool logoBool;
    public GameObject logo;

    void Start()
    {
        logoBool = false;
    }

    private void Update()
    {
        if(logoBool)
        {
            logo.SetActive(true);
            logoBool = false;
        }
    }

    public void AniEvent()
    {
        logoBool = true;
    }

}
