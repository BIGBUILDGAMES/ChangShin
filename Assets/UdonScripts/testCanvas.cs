
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class testCanvas : UdonSharpBehaviour
{
    private int currtarget;
    public int limitTarget;

    private float currTime;
    public float limitTime;

    public GameObject[] target;

    private void OnEnable()
    {
        currtarget = 0;
        currTime = 0;
        target[currtarget].SetActive(true);
    }

    private void Update()
    { 
        currTime += Time.deltaTime;
        
        if(currTime >= limitTime && currtarget < limitTarget)
        {
            target[currtarget].SetActive(false);
            target[currtarget + 1].SetActive(true);

            currtarget++;
            currTime = 0;
        }

        if(currTime >= limitTime && currtarget >= limitTarget)
        {
            target[currtarget].SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
