
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class EndingFadeController : UdonSharpBehaviour
{
    public GameObject floor;
    public GameObject playButton;
    public GameObject darkRoom;

    public Material dataMat;
    public Texture normalTex;
    public Texture backTex;

    private float minimum;
    private float maximum;
    private bool fade;
    private bool backTrigger;
    private float speed;
    private float scale;

    private float respawnDelay;
    private float delay;

    private bool respawn;
    public AudioSource audioSource;


    void Start()
    {
        minimum = 2.0f;
        maximum = 8.0f;
        speed = 0.05f;
        backTrigger = false;
    }

    private void OnEnable()
    {
        respawn = false;
        fade = true;
        respawn = false;
        scale = 0.0f;
        respawnDelay = 0.0f;
        delay = 0.0f;
        dataMat.SetTexture("_tex", normalTex);
        dataMat.SetFloat("_sizeX", scale);
        dataMat.SetFloat("_sizeY", scale);
    }

    private void Update()
    {
        if(delay < 2.0f)
        {
            delay += Time.deltaTime;
        }

        if (delay >= 2.0f)
        {
            if (fade)
            {
                FadeIn();
            }
            else if (!fade)
            {
                FadeOut();
                if (scale <= 2.01f)
                {
                    respawn = true;
                }
            }
        }

        if (scale >= 7.99f && fade)
        {
            fade = false;
            backTrigger = true;
        }

        if (respawn)
        {
            respawnDelay += Time.deltaTime;

            if (respawnDelay >= 2.0f)
            {
                floor.SetActive(false);
            }

            if(respawnDelay >= 5.0f)
            {
                floor.SetActive(true);

                if (audioSource.volume > 0f)
                    audioSource.volume -= Time.deltaTime / 1.8f;
            }
        }

    }

    private void FadeIn()
    {       
        scale = Mathf.Lerp(scale, maximum, speed);

        dataMat.SetFloat("_sizeX", scale);
        dataMat.SetFloat("_sizeY", scale);
    }    
    
    private void FadeOut()
    {       
        scale = Mathf.Lerp(scale, minimum, speed);

        dataMat.SetFloat("_sizeX", scale);
        dataMat.SetFloat("_sizeY", scale);

        if (backTrigger)
        {
            dataMat.SetTexture("_tex", backTex);
            backTrigger = false;
        }
    }

    public virtual void OnPlayerRespawn(VRC.SDKBase.VRCPlayerApi player)
    {
        if (player.isLocal || player.isMaster)
        {
            playButton.SetActive(true);
            darkRoom.SetActive(true);
            audioSource.volume = 0f;
            gameObject.SetActive(false);
        }
    }
}
