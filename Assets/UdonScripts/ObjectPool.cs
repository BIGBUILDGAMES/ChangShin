
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ObjectPool : UdonSharpBehaviour
{
    private bool isfull = false;
    public DollJong[] poolingObjectArray;
    private Quaternion quater = Quaternion.Euler(new Vector3(0f, 0f, 0f));

    private void Start() 
    {
    }

    public void ActiveObject()
    {
        if (isfull)
        {
            for (int i = 0; i < poolingObjectArray.Length; i++)
            {
                var obj = poolingObjectArray[i];

                if (!obj.isInstan)
                {
                    ReTransObject(obj);

                    if (poolingObjectArray[9].isInstan)
                    {
                        for (int k = 0; k < poolingObjectArray.Length; k++)
                        {
                            poolingObjectArray[k].isInstan = false;
                        }
                    }

                    return;
                }
            }
        }
        else
        {
            for (int i = 0; i < poolingObjectArray.Length; i++)
            {
                var obj = poolingObjectArray[i];

                if (!obj.isInstan)
                {
                    obj.isInstan = true;
                    obj.transform.SetParent(null);
                    obj.gameObject.SetActive(true);

                    if (poolingObjectArray[9].isInstan)
                    {
                        for (int k = 0; k < poolingObjectArray.Length; k++)
                        {
                            poolingObjectArray[k].isInstan = false;
                            isfull = true;
                        }
                    }

                    return;
                }
            }
        }
    }

    public void ReturnObject() 
    {
        for (int k = 0; k < poolingObjectArray.Length; k++)
        {
            var obj = poolingObjectArray[k];

            obj.gameObject.SetActive(false);
            obj.transform.SetParent(transform);
            obj.isInstan = false;
        }

        isfull = false;
    }

    public void ReTransObject(DollJong doll)
    {
        doll.gameObject.transform.position = transform.position;
        doll.gameObject.transform.rotation = quater;
        doll.isInstan = true;
    }

    public virtual void OnPlayerRespawn(VRC.SDKBase.VRCPlayerApi player)
    {
        if (player.isLocal || player.isMaster)
        {
            ReturnObject();
        }
    }

}
