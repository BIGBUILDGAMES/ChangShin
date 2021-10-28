
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class StartMissionFade : UdonSharpBehaviour
{
    public Material dataMat;

    private float currtTime;
    private float transparency;

    private bool fade = true;

    private void OnEnable()
    {
        fade = true;
        currtTime = 0f;
        transparency = 1f;
        dataMat.SetFloat("_Transparency", transparency);
    }

    private void Update()
    {
        if (fade)
        {
            FadeIn();
        }
        else
        {
            FadeOut();
        }
    }

    private void FadeOut()
    {
        currtTime += Time.deltaTime;

        if (currtTime >= 3.0f)
        {
            transparency += Time.deltaTime;
            dataMat.SetFloat("_Transparency", transparency);
            if (transparency >= 0.999f)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void FadeIn()
    {
        currtTime += Time.deltaTime;

        if (currtTime >= 1.0f)
        {
            if (transparency > 0.25f)
            {
                transparency -= Time.deltaTime;
                dataMat.SetFloat("_Transparency", transparency);
            }
            else if (transparency <= 0.25f)
            {
                fade = false;
                currtTime = 0.0f;
            }
        }
    }
}
