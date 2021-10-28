
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class EndingTriggerController : UdonSharpBehaviour
{
    private bool aniTrigger;
    private bool hiBool;

    private Animator animator;
    private Animator animator1;
    private Animator animator2;
    private Animator animator3;
    private Animator animator4;

    public GameObject endingEvent;
    public GameObject endingEvent1;
    public GameObject endingEvent2;
    public GameObject endingEvent3;
    public GameObject endingEvent4;


    void Start()
    {
        animator = endingEvent.GetComponent<Animator>();
        animator1 = endingEvent1.GetComponent<Animator>();
        animator2 = endingEvent2.GetComponent<Animator>();
        animator3 = endingEvent3.GetComponent<Animator>();
        animator4 = endingEvent4.GetComponent<Animator>();
    }

    //private void OnEnable()
    //{

    //}

    public virtual void OnPlayerTriggerEnter(VRC.SDKBase.VRCPlayerApi player)
    {
        if (player.isLocal || player.isMaster)
        {
            hiBool = true;
        }
    }

    private void Update()
    {
        if (hiBool && !aniTrigger)
        {
            animator.SetTrigger("hiTrigger");
            animator1.SetTrigger("hiTrigger");
            animator2.SetTrigger("hiTrigger");
            animator3.SetTrigger("hiTrigger");
            animator4.SetTrigger("hiTrigger");

            aniTrigger = true;
        }
    }

    public virtual void OnPlayerRespawn(VRC.SDKBase.VRCPlayerApi player)
    {
        if (player.isLocal || player.isMaster)
        {
            aniTrigger = false;
            hiBool = false;

            animator.SetTrigger("endingTrigger");
            animator1.SetTrigger("endingTrigger");
            animator2.SetTrigger("endingTrigger");
            animator3.SetTrigger("endingTrigger");
            animator4.SetTrigger("endingTrigger");
        }
    }
}
