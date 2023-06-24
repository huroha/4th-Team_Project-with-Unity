using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Teleport : MonoBehaviour
{
    // test
    Scene scene;
    static bool isSceneMoved = false;
    public string SceneName;
    // sound
    SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        scene = SceneManager.GetActiveScene();
        if (scene.name != "startRoom")
        {
            isSceneMoved = true;
            soundManager.setSource("door");
            soundManager.getDoor().Play();
        }   
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneName == "LivingRoom")
        { 
            SceneManager.LoadScene("Kitchen&LivingRoom"); 
        }
        else if(SceneName == "BathRoom")
        {
            SceneManager.LoadScene("BathRoom");
        }
        else if (SceneName == "InnerRoom")
        {
            SceneManager.LoadScene("InnerRoom");
        }
        else if (SceneName == "Entrance")
        {
            SceneManager.LoadScene("Entrance");
        }
        else if (SceneName == "Yard")
        {
            SceneManager.LoadScene("Yard");
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
