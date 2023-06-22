using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public float noteSpeed = 200f;
    Rigidbody2D myNote;
    Vector2 noteInitPos;
    bool isTrigger = false;
    // Cook�� ������ ���ߴµ� �ʿ��� ������
    public GameObject myInv;
    public GameObject myContainer;
    // ���� üũ�� ���� ����
    public GameObject[] correctAreaOb = new GameObject[4];
    RectTransform[] correctAreaRect = new RectTransform[4];
    Vector2[] rangePosStartX = new Vector2[4];
    Vector2[] rangePosEndX = new Vector2[4];
    bool isCorOb1 = false;
    bool isCorOb2 = false;
    bool isCorOb3 = false;
    bool isCorOb4 = false;
    public bool isOvenOver = false;
    // �ִϸ��̼��� ���� ����
    public GameObject[] ButtonController = new GameObject[2];
    //
    public Cook myCook;
    // Start is called before the first frame update
    void Start()
    {
        myNote = GetComponent<Rigidbody2D>();
        // ���� üũ�� ���� �⺻ ����
        for (int i = 0; i < correctAreaOb.Length; i++)
        {
            correctAreaRect[i] = correctAreaOb[i].GetComponent<RectTransform>();
            // x��ǥ�� �߽��̹Ƿ� �߽ɿ��� start�� �ʺ��� ���� ���� end�� �ʺ��� ���� ���ϸ� x���� ������ �����ȴ�.
            rangePosStartX[i] = new Vector2(correctAreaRect[i].localPosition.x - correctAreaRect[i].rect.width / 2
                                            , correctAreaRect[i].localPosition.y);
            rangePosEndX[i] = new Vector2(correctAreaRect[i].localPosition.x + correctAreaRect[i].rect.width / 2
                                            , correctAreaRect[i].localPosition.y);
        }
        noteInitPos = myNote.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        isOvenOver = GlobalDataControl.Instance.isOvenOver;

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
        if (isOvenOver)
        {
            myInv.SetActive(true);
            myContainer.SetActive(false);
            myInv.GetComponent<Inventory>().setInventory("isFood");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NoteArea"))
            convertMovingDirection();
    }

    // ��Ʈ�� ��,�� ������
    void convertMovingDirection()
    {
        if (isTrigger)
            isTrigger = false;
        else
            isTrigger = true;
    }

    // ���� üũ
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
                }
                else if(ButtonController[1].activeSelf == true)
                {
                    ButtonController[1].SetActive(false);
                    ButtonController[0].SetActive(true);
                }
                
                
            }
            else if (transform.localPosition.x >= rangePosStartX[1].x && transform.localPosition.x <= rangePosEndX[1].x)
            {
                isCorOb2 = true;
                if (ButtonController[0].activeSelf == true)
                {
                    ButtonController[0].SetActive(false);
                    ButtonController[1].SetActive(true);
                }
                else if (ButtonController[1].activeSelf == true)
                {
                    ButtonController[1].SetActive(false);
                    ButtonController[0].SetActive(true);
                }
            }
            else if (transform.localPosition.x >= rangePosStartX[2].x && transform.localPosition.x <= rangePosEndX[2].x)
            {
                isCorOb3 = true;
                if (ButtonController[0].activeSelf == true)
                {
                    ButtonController[0].SetActive(false);
                    ButtonController[1].SetActive(true);
                }
                else if (ButtonController[1].activeSelf == true)
                {
                    ButtonController[1].SetActive(false);
                    ButtonController[0].SetActive(true);
                }
            }
            else if (transform.localPosition.x >= rangePosStartX[3].x && transform.localPosition.x <= rangePosEndX[3].x)
            {
                isCorOb4 = true;
                if (ButtonController[0].activeSelf == true)
                {
                    ButtonController[0].SetActive(false);
                    ButtonController[1].SetActive(true);
                }
                else if (ButtonController[1].activeSelf == true)
                {
                    ButtonController[1].SetActive(false);
                    ButtonController[0].SetActive(true);
                }
            }

            if (isCorOb1 == true && isCorOb2 == true && isCorOb3 == true && isCorOb4 == true)
                isOvenOver = true;
        }
    }
    public void savePlayerData()
    {
        GlobalDataControl.Instance.isOvenOver = isOvenOver;
    }
}
