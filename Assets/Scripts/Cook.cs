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
    // 영역 체크를 위한 변수
    public GameObject[] correctAreaOb = new GameObject[6];
    RectTransform[] correctAreaRect = new RectTransform[6];
    Vector2[] rangePosStartX = new Vector2[6];
    Vector2[] rangePosEndX = new Vector2[6];
    bool isCorOb1 = false;
    bool isCorOb2 = false;
    bool isCookOver = false;
    // Start is called before the first frame update
    Text tempText;
    void Start()
    {
        myNote = GetComponent<Rigidbody2D>();
        tempText = GameObject.Find("tempTxt").GetComponent<Text>();
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

    }

    // Update is called once per frame
    void Update()
    {
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
        if (correctAreaOb[0].activeSelf == true && correctAreaOb[1].activeSelf == true)
        {
            if (transform.localPosition.x >= rangePosStartX[0].x && transform.localPosition.x <= rangePosEndX[0].x)
            {
                tempText.text = "첫번째 영역";
                isCorOb1 = true;
            }

            else if (transform.localPosition.x >= rangePosStartX[1].x && transform.localPosition.x <= rangePosEndX[1].x)
            { 
                tempText.text = "두번째 영역";
                isCorOb2 = true;
            }
            else
                tempText.text = "다른 영역";
        }
        else if (correctAreaOb[2].activeSelf == true && correctAreaOb[3].activeSelf == true)
        {
            if (transform.localPosition.x >= rangePosStartX[2].x && transform.localPosition.x <= rangePosEndX[2].x)
            {
                tempText.text = "첫번째 영역";
                isCorOb1 = true;
            }
            else if (transform.localPosition.x >= rangePosStartX[3].x && transform.localPosition.x <= rangePosEndX[3].x)
            {
                tempText.text = "두번째 영역";
                isCorOb2 = true;
            }
            else
                tempText.text = "다른 영역";
        }
        else if (correctAreaOb[4].activeSelf == true && correctAreaOb[5].activeSelf == true)
        {
            if (transform.localPosition.x >= rangePosStartX[4].x && transform.localPosition.x <= rangePosEndX[4].x)
            {
                tempText.text = "첫번째 영역";
                isCorOb1 = true;
            }
            else if (transform.localPosition.x >= rangePosStartX[5].x && transform.localPosition.x <= rangePosEndX[5].x)
            {
                tempText.text = "두번째 영역";
                isCorOb2 = true;
            }
            else
                tempText.text = "다른 영역";
            if (isCorOb1 == true && isCorOb2 == true)
                isCookOver = true;
        }
        Debug.Log("첫번째 영역은 : " + isCorOb1 + "두번째 영역은 : " + isCorOb2);
        changeTiming();
    }
    // 다른 영역으로 변경
    void changeTiming()
    {
        if (isCorOb1 == true && isCorOb2 == true)
        {
            Debug.Log("ChangeTiming Start");
            if(correctAreaOb[0].activeSelf == true && correctAreaOb[1].activeSelf == true)
            {
                Debug.Log("Change 0,1 to 2,3");
                correctAreaOb[0].SetActive(false);
                correctAreaOb[1].SetActive(false);
                correctAreaOb[2].SetActive(true);
                correctAreaOb[3].SetActive(true);
            }
            else if(correctAreaOb[2].activeSelf == true && correctAreaOb[3].activeSelf == true)
            {
                Debug.Log("Change 2,3 to 4,5");
                correctAreaOb[2].SetActive(false);
                correctAreaOb[3].SetActive(false);
                correctAreaOb[4].SetActive(true);
                correctAreaOb[5].SetActive(true);
            }
            isCorOb1 = false;
            isCorOb2 = false;
        }
    }
}
