using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathRoom_triggerBox : MonoBehaviour
{
    BathRoom_Duck mainDuck;
    // Start is called before the first frame update
    void Start()
    {
        mainDuck = GameObject.Find("DuckManager").GetComponent<BathRoom_Duck>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        mainDuck.selectTrack();
    }
}
