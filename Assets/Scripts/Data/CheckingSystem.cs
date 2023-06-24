using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingSystem : MonoBehaviour
{
    public Game_Manager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalDataControl.Instance.bathRoom_itemCount == 1 && GlobalDataControl.Instance.kitchenRoom_itemCount == 1 
            && GlobalDataControl.Instance.innerRoom_itemCount == 1)
        {
            if (gameObject.GetComponent<ObjData>().id != 600)
                gameObject.GetComponent<ObjData>().id = 600; // 250 으로 변경        
        }

        if(gm.isAction == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                gm.isAction = false;
                Destroy(gameObject, 0.5f);
            }
        }
    }
}
