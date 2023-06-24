using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    public GameObject optionUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButton()
    {
        SceneManager.LoadScene("StartRoom");
    }

    public void OnOptionButton()
    {
        optionUI.SetActive(true);
    }

    public void OnCloseButton()
    {
        optionUI.SetActive(false);
        
    }
    public void OnGoToTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void OnEscapeButton()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit(); // 어플리케이션 종료
    #endif
    }
}
