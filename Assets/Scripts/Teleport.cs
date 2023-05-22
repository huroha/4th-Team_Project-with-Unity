using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Teleport : MonoBehaviour
{
    // test
    Scene scene;
    static bool isSceneMoved = false;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name != "startRoom")
            isSceneMoved = true;
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

    public bool getSceneMoveCheck()
    {
        return isSceneMoved;
    }
    void changeIsSceneMoved()
    {
        isSceneMoved = true;
    }
}
