using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CinemachineUIManager : MonoBehaviour
{
    public GameObject Letter;
    public Button closeButton;
    // Start is called before the first frame update
    void Start()
    {
        Letter.SetActive(false);
        CinemachineController.OnCinemachineFinished += ShowUI;
    }
    public void onClickButton()
    {
        Letter.SetActive(false);
    }
    private void OnDestroy()
    {
        CinemachineController.OnCinemachineFinished -= ShowUI;
    }
    private void ShowUI()
    {
        Letter.SetActive(true);
    }
}
