using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Teleport : MonoBehaviour
{
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (scene.name == "BathRoom")
        { 
            SceneManager.LoadScene("Kitchen"); 
        }
        else if(scene.name == "Kitchen")
        {
            SceneManager.LoadScene("BathRoom");
        }
    }

}
