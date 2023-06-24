using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cook : MonoBehaviour
{
    public float noteSpeed = 200f;
    Rigidbody2D myNote;
    Vector2 noteInitPos;
    bool isTrigger = false;
    // Cook의 조리를 멈추는데 필요한 변수들
    public GameObject myInv;
    public GameObject myContainer;
    public GameObject myData;
    // 영역 체크를 위한 변수
    public GameObject[] correctAreaOb = new GameObject[7];
    RectTransform[] correctAreaRect = new RectTransform[7];
    Vector2[] rangePosStartX = new Vector2[7];
    Vector2[] rangePosEndX = new Vector2[7];
    bool isCorOb1 = false;
    bool isCorOb2 = false;
    bool isCorOb3 = false;
    bool isCorOb4 = false;
    public bool isCookOver = false;
    // 연출을 위한 변수
    public GameObject[] vegetables = new GameObject[4];
    //
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
                                            ,correctAreaRect[i].localPosition.y);
            rangePosEndX[i] = new Vector2(correctAreaRect[i].localPosition.x + correctAreaRect[i].rect.width / 2
                                            , correctAreaRect[i].localPosition.y);
        }
        noteInitPos = myNote.transform.position;

        soundManager.setAudioSource(false, 0);
        soundManager.getBg().Play();
    }

    // Update is called once per frame
    void Update()
    {
        isCookOver = GlobalDataControl.Instance.isCookOver;
        if (!isTrigger)
        {
            myNote.transform.Translate(new Vector3(noteSpeed * Time.deltaTime, 0f, 0f));
        }
        else
        {
            myNote.transform.Translate(new Vector3(noteSpeed * Time.deltaTime * -1f, 0f, 0f));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            checkIsValid();
        }
        if(isCookOver)
        {
            myInv.SetActive(true);
            myContainer.SetActive(false);
            myData.GetComponent<ObjData>().changeIsUsed();
            myData.GetComponent<ObjData>().setIsUsed();
            savePlayerData();
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
        if (correctAreaOb[0].activeSelf == true && correctAreaOb[1].activeSelf == true && correctAreaOb[2].activeSelf == true) // 1 PHAZE
        {
            if (transform.localPosition.x >= rangePosStartX[0].x && transform.localPosition.x <= rangePosEndX[0].x)
            {
                isCorOb1 = true;
                vegetables[0].SetActive(true);
                soundManager.setAudioSource(true, 0);
                soundManager.getAs().Play();
            }
            else if (transform.localPosition.x >= rangePosStartX[1].x && transform.localPosition.x <= rangePosEndX[1].x)
            {
                isCorOb2 = true;
                vegetables[1].SetActive(true);
                soundManager.setAudioSource(true, 0);
                soundManager.getAs().Play();
            }
            else if (transform.localPosition.x >= rangePosStartX[2].x && transform.localPosition.x <= rangePosEndX[2].x)
            {
                isCorOb3 = true;
                vegetables[2].SetActive(true);
                soundManager.setAudioSource(true, 0);
                soundManager.getAs().Play();
            }
        }
        else if (correctAreaOb[3].activeSelf == true && correctAreaOb[4].activeSelf == true && correctAreaOb[5].activeSelf == true && correctAreaOb[6].activeSelf == true) // 2 PHAZE
        {
            if (transform.localPosition.x >= rangePosStartX[3].x && transform.localPosition.x <= rangePosEndX[3].x)
            {
                isCorOb1 = true;
                soundManager.setAudioSource(true, 0);
                soundManager.getAs().Play();
            }
            else if (transform.localPosition.x >= rangePosStartX[4].x && transform.localPosition.x <= rangePosEndX[4].x)
            {
                isCorOb2 = true;
                soundManager.setAudioSource(true, 0);
                soundManager.getAs().Play();
            }
            else if (transform.localPosition.x >= rangePosStartX[5].x && transform.localPosition.x <= rangePosEndX[5].x)
            {
                isCorOb3 = true;
                soundManager.setAudioSource(true, 0);
                soundManager.getAs().Play();
            }
            else if (transform.localPosition.x >= rangePosStartX[6].x && transform.localPosition.x <= rangePosEndX[6].x)
            {
                isCorOb4 = true;
                vegetables[3].SetActive(true);
                soundManager.setAudioSource(true, 0);
                soundManager.getAs().Play();
            }

            if (isCorOb1 == true && isCorOb2 == true && isCorOb3 == true && isCorOb4 == true)
            {
                isCookOver = true;
            }
        }
        changeTiming();
    }
    // 다른 영역으로 변경
    void changeTiming()
    {
        if (isCorOb1 == true && isCorOb2 == true && isCorOb3 == true)
        {
            if(correctAreaOb[0].activeSelf == true && correctAreaOb[1].activeSelf == true && correctAreaOb[2].activeSelf == true) // 1 페이즈 종료
            {
                Debug.Log("==========1페이즈 종료==========");
                correctAreaOb[0].SetActive(false);
                correctAreaOb[1].SetActive(false);
                correctAreaOb[2].SetActive(false);
                correctAreaOb[3].SetActive(true);
                correctAreaOb[4].SetActive(true);
                correctAreaOb[5].SetActive(true);
                correctAreaOb[6].SetActive(true);
            }
            isCorOb1 = false;
            isCorOb2 = false;
            isCorOb3 = false;
            noteInitPos = myNote.transform.position;
        }
    }
    public void savePlayerData()
    {
        GlobalDataControl.Instance.isCookOver = isCookOver;

    }
}
