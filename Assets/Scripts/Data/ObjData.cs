using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjData : MonoBehaviour
{
    public int id;
    public bool isNpc;
    public bool isUsed;

    private void Update()
    {
        if (id == 200)
        {
            isUsed= GlobalDataControl.Instance.isUsed[0];
        }
        else if (id == 300)
        {
            isUsed= GlobalDataControl.Instance.isUsed[1];
        }
        else if (id == 400)
        {
            isUsed= GlobalDataControl.Instance.isUsed[2];
        }
        else if (id == 500)
        {
            isUsed= GlobalDataControl.Instance.isUsed[3];
        }
        else if (id == 600)
        {
            isUsed= GlobalDataControl.Instance.isUsed[4];
        }
    }
    public bool getIsUsed()
    {
        return isUsed;
    }
    public void setIsUsed()
    {
        if (id == 200)
        {
            GlobalDataControl.Instance.isUsed[0] = isUsed;
        }
        else if (id == 300)
        {
            GlobalDataControl.Instance.isUsed[1] = isUsed; // cook
        }
        else if (id == 400)
        {
            GlobalDataControl.Instance.isUsed[2] = isUsed; // Oven
        }
        else if (id == 500)
        {
            GlobalDataControl.Instance.isUsed[3] = isUsed;
        }
        else if (id == 600)
        {
            GlobalDataControl.Instance.isUsed[4] = isUsed;
        }
    }

    public void changeIsUsed()
    {
        isUsed = true;
    }
}
