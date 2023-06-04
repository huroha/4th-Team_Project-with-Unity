using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjData : MonoBehaviour
{
    public int id;
    public bool isNpc;
    public bool isUsed;
    
    public bool getIsUsed()
    {
        return isUsed;
    }
    public void setIsUsed()
    {
        isUsed = true;
        if (id == 200)
        {
            GlobalDataControl.Instance.isUsed[0] = isUsed;
        }
        else if (id == 300)
        {
            GlobalDataControl.Instance.isUsed[1] = isUsed;
        }
    }
}
