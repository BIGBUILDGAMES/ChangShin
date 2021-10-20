
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class OpeningCotroller : UdonSharpBehaviour
{
    public GameObject background;
    public Material dataMat;
    public Texture openingTex;

    private bool onOff;
    private bool isAudio;
    private float currtTime;
    private float transparency;

    // Change Tex
    private bool isIntro;
    public Texture[] introDataTex;
    private int currtTex;
    public int introTexCount;
    private float delay;
    public float introLimitTime;
    public GameObject darkroom;

    public GameObject playcanvas;
    public AudioSource audioSource;
    public AudioController audioController;

    private void OnEnable()
    {
        currtTime = 0;
        currtTex = 0;
        delay = 0;
        onOff = true;
        isIntro = false;
        isAudio = false;

        audioSource.volume = 1.0f;
        transparency = 1;
        dataMat.SetFloat("_Transparency", transparency);
        dataMat.SetTexture("_tex", openingTex);

        playcanvas.SetActive(false);
        background.SetActive(true);

        audioController.BGMOpening();
    }

    private void Update()
    {
        if (!isIntro)
        {
            LogosUpdate();
        }
        else
        {
            IntroUpdate();
        }
    }

    private void LogosUpdate()
    {
        currtTime += Time.deltaTime;

        if (onOff)
        {
            if (currtTime >= 2.0f)
            {
                transparency -= Time.deltaTime;
                dataMat.SetFloat("_Transparency", transparency);
            }

            if (transparency <= 0)
                onOff = false;
        }
        else
        {
            if (currtTime >= 7.0f)
            {
                transparency += Time.deltaTime;
                dataMat.SetFloat("_Transparency", transparency);
            }

            if (transparency >= 1)
            {
                currtTime = 0.0f;
                transparency = 0.0f;
                dataMat.SetTexture("_tex", introDataTex[currtTex]);
                dataMat.SetFloat("_Transparency", transparency);

                isIntro = true;
            }
        }
    }

    private void IntroUpdate()
    {
        if (delay < 1.0f)
        {
            delay += Time.deltaTime;
        }

        if (delay >= 1.0f)
        {
            currtTime += Time.deltaTime;

            if (currtTime >= 3.15f && currtTex <= 1)
            {
                currtTex++;
                dataMat.SetTexture("_tex", introDataTex[currtTex]);
                currtTime = 0;
                if (currtTex == 1) audioSource.Play();
            }

            if (currtTime >= introLimitTime && currtTex > 1 && currtTex < introTexCount)
            {
                currtTex++;
                dataMat.SetTexture("_tex", introDataTex[currtTex]);
                currtTime = 0;
            }

            if (currtTime >= introLimitTime && currtTex == introTexCount && transparency < 1f)
            {
                isAudio = true;
                transparency += Time.deltaTime / 2.5f;

                dataMat.SetFloat("_Transparency", transparency);
                if (transparency >= 1)
                {
                    transparency = 1f;
                    currtTime = 0f;
                }
            }

            if (isAudio && audioSource.volume > 0f)
            {
                audioSource.volume -= Time.deltaTime / 2.5f;
            }

            if (transparency == 1f && currtTime >= 2f)
            {
                audioSource.volume = 1.0f;
                audioController.BGMPlaying();
                audioSource.Play();
                background.SetActive(false);
                darkroom.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
