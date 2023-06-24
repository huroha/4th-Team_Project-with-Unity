using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public float noteSpeed = 200f;
    Rigidbody2D myNote;
    Vector2 noteInitPos;
    bool isTrigger = false;
    // Cook의 조리를 멈추는데 필요한 변수들
    public GameObject myInv;
    public GameObject myContainer;
    // 영역 체크를 위한 변수
    public GameObject[] correctAreaOb = new GameObject[4];
    RectTransform[] correctAreaRect = new RectTransform[4];
    Vector2[] rangePosStartX = new Vector2[4];
    Vector2[] rangePosEndX = new Vector2[4];
    public bool isCorOb1 = false;
    public bool isCorOb2 = false;
    public bool isCorOb3 = false;
    public bool isCorOb4 = false;
    public bool isOvenOver = false;
    // 애니메이션을 위한 변수
    public GameObject[] ButtonController = new GameObject[2];
    //
    public Cook myCook;
    public GameObject player;
    // 사운드를 위한 변수
    public SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        myNote = GetComponent<Rigidbody2D>();
        // 영역 체크를 위한 기본 설정
        for (int i = 0; i < correctAreaOb.Length; i++)
        {
            correctAreaRect[i] = correctAreaOb[i].GetComponent<RectTransform>();
            // x좌표가 중심이므로 중심에서 start는 너비의 반을 빼고 end는 너비의 반을 더하면 x값의 범위가 형성된다.
            rangePosStartX[i] = new Vector2(correctAreaRect[i].localPosition.x - correctAreaRect[i].rect.width / 2
                                            , correctAreaRect[i].localPosition.y);
            rangePosEndX[i] = new Vector2(correctAreaRect[i].localPosition.x + correctAreaRect[i].rect.width / 2
                                            , correctAreaRect[i].localPosition.y);
        }
        noteInitPos = myNote.transform.position;

        soundManager.setAudioSource(false, 1);
        soundManager.getBg().Play();
    }

    // Update is called once per frame
    void Update()
    {
        isOvenOver = GlobalDataControl.Instance.isOvenOver;

        if (isCorOb1 == true && isCorOb2 == true && isCorOb3 == true && isCorOb4 == true)
            isOvenOver = true;

        if (!isTrigger)
        {
            myNote.transform.Translate(new Vector3(noteSpeed * Time.deltaTime, 0f, 0f));
        }
        else
        {
            myNote.transform.Translate(new Vector3(noteSpeed * Time.deltaTime * -1f, 0f, 0f));
        }
        if (isOvenOver)
        {
            myInv.SetActive(true);
            myContainer.SetActive(false);
            savePlayerData();
            myInv.GetComponent<Inventory>().setInventory("isFood");
            player.GetComponent<PlayerActor>().speed = 3.8f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NoteArea"))
            convertMovingDirection();
    }

    // 노트의 좌,우 음직임
    void convertMovingDirection()
    {
        if (isTrigger)
            isTrigger = false;
        else
            isTrigger = true;
    }

    // 영역 체크
    void checkIsValid()
    {
        if (correctAreaOb[0].activeSelf == true && correctAreaOb[1].activeSelf == true && correctAreaOb[2].activeSelf == true && correctAreaOb[3].activeSelf == true) // 2 PHAZE
        {
            if (transform.localPosition.x >= rangePosStartX[0].x && transform.localPosition.x <= rangePosEndX[0].x)
            {
                isCorOb1 = true;
                if(ButtonController[0].activeSelf == true)
                {
                    ButtonController[0].SetActive(false);
                    ButtonController[1].SetActive(true);
                    soundManager.setAudioSource(true, 1);
                    soundManager.getAs().Play();
                }
                else if(ButtonController[1].activeSelf == true)
                {
                    ButtonController[1].SetActive(false);
                    ButtonController[0].SetActive(true);
                    soundManager.setAudioSource(true, 1);
                    soundManager.getAs().Play();
                }
                
                
            }
            else if (transform.localPosition.x >= rangePosStartX[1].x && transform.localPosition.x <= rangePosEndX[1].x)
            {
                isCorOb2 = true;
                if (ButtonController[0].activeSelf == true)
                {
                    ButtonController[0].SetActive(false);
                    ButtonController[1].SetActive(true);
                    soundManager.setAudioSource(true, 1);
                    soundManager.getAs().Play();
                }
                else if (ButtonController[1].activeSelf == true)
                {
                    ButtonController[1].SetActive(false);
                    ButtonController[0].SetActive(true);
                    soundManager.setAudioSource(true, 1);
                    soundManager.getAs().Play();
                }
            }
            else if (transform.localPosition.x >= rangePosStartX[2].x && transform.localPosition.x <= rangePosEndX[2].x)
            {
                isCorOb3 = true;
                if (ButtonController[0].activeSelf == true)
                {
                    ButtonController[0].SetActive(false);
                    ButtonController[1].SetActive(true);
                    soundManager.setAudioSource(true, 1);
                    soundManager.getAs().Play();
                }
                else if (ButtonController[1].activeSelf == true)
                {
                    ButtonController[1].SetActive(false);
                    ButtonController[0].SetActive(true);
                    soundManager.setAudioSource(true, 1);
                    soundManager.getAs().Play();
                }
            }
            else if (transform.localPosition.x >= rangePosStartX[3].x && transform.localPosition.x <= rangePosEndX[3].x)
            {
                isCorOb4 = true;
                if (ButtonController[0].activeSelf == true)
                {
                    ButtonController[0].SetActive(false);
                    ButtonController[1].SetActive(true);
                    soundManager.setAudioSource(true, 1);
                    soundManager.getAs().Play();
                }
                else if (ButtonController[1].activeSelf == true)
                {
                    ButtonController[1].SetActive(false);
                    ButtonController[0].SetActive(true);
                    soundManager.setAudioSource(true, 1);
                    soundManager.getAs().Play();
                }
            }
        }
    }
    public void savePlayerData()
    {
        GlobalDataControl.Instance.isOvenOver = isOvenOver;
    }
    public void buttonCheck()
    {
        checkIsValid();
    }
}
