
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ChageTexture : UdonSharpBehaviour
{
    public GameObject background;
    public GameObject darkroom;
    public GameObject playcanvas;

    public Texture[] dataTex;
    private int currtTex;
    public int limitTex;

    public Material dataMat;
    public float limitTime;
    private float currtTime;
    private float delay;

    private void OnEnable()
    {
        currtTime = 0;
        currtTex = 0;
        delay = 0;
        dataMat.SetTexture("_tex", dataTex[currtTex]);
        playcanvas.SetActive(false);
    }

    public void Update()
    {
        if (delay < 2.0f)
        {
            delay += Time.deltaTime;
        }

        if (delay >= 2.0f)
        {
            currtTime += Time.deltaTime;

            if (currtTime >= limitTime && currtTex < limitTex)
            {
                dataMat.SetTexture("_tex", dataTex[currtTex]);
                currtTex++;
                currtTime = 0;
            }

            if (currtTex >= limitTex && currtTime >= limitTime)
            {
                background.SetActive(false);
                darkroom.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
