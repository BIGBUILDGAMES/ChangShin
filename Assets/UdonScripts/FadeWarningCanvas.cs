
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class FadeWarningCanvas : UdonSharpBehaviour
{
    public Material dataMat;

    private float currtTime;
    private float transparency;

    private void OnEnable()
    {
        currtTime = 0f;
        transparency = 0.25f;
        dataMat.SetFloat("_Transparency", transparency);
    }

    private void Update()
    {
        currtTime += Time.deltaTime;

        if (currtTime >= 3.0f)
        {
            transparency += Time.deltaTime;
            dataMat.SetFloat("_Transparency", transparency);
        }

        if (transparency >= 0.999f)
        {
            gameObject.SetActive(false);
        }

    }
}
