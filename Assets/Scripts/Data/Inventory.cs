using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���� �Ұ� : �κ��丮 ����ȭ(0���� ��� ���� �߻�)
public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    // ��������Ʈ ������ ���� ����
    GameObject[] invArray = new GameObject[4];
    public Image[] inventory = new Image[4];
    PlayerActor player;
    // �κ��丮 UI ������ ���� ����
    public bool[] isActive = new bool[4];
    Teleport myTp;
    // �κ��丮�� ������ ������ ���� ����
    public Text[] myText = new Text[4];
    public PlayerData myData;
    public int keyIndex;
    public int duckIndex;
    public int innerIndex;
    public int kitchenIndex;
    // �κ��丮 ������ ���� ����
    public bool isGetKey;
    public bool isGetBathRoomItem;
    public bool isGetInnerRoomItem;
    public bool isGetKitchenItem;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Debug.Log("============== �κ��丮 ���� ================");
        player = GameObject.Find("Player").GetComponent<PlayerActor>(); // �÷��̾ ���
        myTp = GameObject.Find("TP").GetComponent<Teleport>();
        //myData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        isGetKey = GlobalDataControl.Instance.isGetKey;
        isGetBathRoomItem = GlobalDataControl.Instance.isGetBathRoomItem;
        isGetInnerRoomItem = GlobalDataControl.Instance.isGetInnerRoomItem;
        isGetKitchenItem = GlobalDataControl.Instance.isGetKitchenItem;

        for (int i = 0;i < 4;i++)
        {
            // �κ��丮 �� ĭ ����
            invArray[i] = transform.GetChild(i).gameObject; // �ڽ��� ��ȣ�� ã��
            inventory[i] = invArray[i].GetComponent<Image>();
            myText[i] = invArray[i].GetComponentInChildren<Text>();
        }

        if(myTp.getSceneMoveCheck())
        {
            // Ȱ��ȭ ���� ����
            invArray[keyIndex].SetActive(GlobalDataControl.Instance.invActive[keyIndex]);
            invArray[duckIndex].SetActive(GlobalDataControl.Instance.invActive[duckIndex]);
            // �̹��� ����
            inventory[keyIndex].sprite = GlobalDataControl.Instance.invImage[keyIndex];
            inventory[duckIndex].sprite = GlobalDataControl.Instance.invImage[duckIndex];
            // �ؽ�Ʈ ����
            myText[keyIndex].text = GlobalDataControl.Instance.invText[keyIndex];
            myText[duckIndex].text = GlobalDataControl.Instance.invText[duckIndex];
        }
    }
    // Update is called once per frame
    void Update()
    {
        savePlayerData();
    }

    // Inventory System (���� sprite�� ������ �ִٸ� �߰��� ���� ����)

    public void setInventory(string itemName)
    {
        // �Լ��� inventory�� ��������Ʈ �ִ� �˰��� ���� + �κ��丮 idx�� ���Ͻ�Ŵ
        setInventorySprite(itemName);
            // �������� �˻��ؼ� ������ ���������ִ� �˰���
            switch (itemName)
            {
                case "isKey": // key
                    //Debug.Log("Key Add , " + myData.getKeyCount());
                    myText[keyIndex].text = myData.getKeyCount().ToString(); // �����Ͱ� ����ǵ� �ٷ� �ݿ��� �ȵ�(���Ǿȸ¾Ƽ�)
                    isGetKey = true;
                    if (myData.getKeyCount() < 3) // key ������ �ִ� 3��
                    {         
                        myData.addKeyCount(); // key ���� 1 ����
                        myText[keyIndex].text = myData.getKeyCount().ToString();
                        saveInvenText(keyIndex);
                    }
                    break;
                case "isDuck": // ��� - ��������
                    myText[duckIndex].text = myData.getBrItemCount().ToString(); // �����Ͱ� ����ǵ� �ٷ� �ݿ��� �ȵ�(���Ǿȸ¾Ƽ�)
                    isGetBathRoomItem = true;
                    if (myData.getBrItemCount() < 1) // key ������ �ִ� 3��
                    {
                        myData.addBrItemCount(); // key ���� 1 ����
                        myText[duckIndex].text = myData.getBrItemCount().ToString();
                        saveInvenText(duckIndex);
                    }
                    break;
                case "doll": // �ȹ� - ��������
                    Debug.Log("doll");

                    break;
                case "food": // �ֹ� - ���
                    Debug.Log("food");

                    break;
            }
        Debug.Log("item name is : "+ itemName);
    }

    private void setInventorySprite(string itemName)
    {
        bool isConflict = false;
        
         if ((player.getScanOb().tag == "isKey" && isGetKey == true))
         {
            Debug.Log("----------------KEY �� ���� �ߺ� �߻�-----------------------");
            isConflict = true;
         }
         else if((player.getScanOb().tag == "isDuck" && isGetBathRoomItem == true))
        {
            Debug.Log("----------------DUCK �� ���� �ߺ� �߻�----------------------");
            isConflict = true;
        }
        
        for (int i = 0; i < 4; i++)
        {
            // ���� i�� �κ��丮 ĭ�� active = false �϶� => �κ��丮 Ȱ��ȭ ���θ� ������ ����ĭ�� �������� �������� ���°��� ����
            // isConflict = false �� �� => �ߺ��� üũ�ؼ� ���� �Ȱ��� �������� �κ��丮�� �����Ѵٸ� �������� ���� ����
            if (invArray[i].activeInHierarchy == false && isConflict == false)
            {
                if (itemName == "isKey" && isGetKey == false)
                {
                    Debug.Log("-------------------KEY false & false & false--------------------");
                    invArray[i].SetActive(true);
                    inventory[i].sprite = Resources.Load<Sprite>("Img_Key");
                    Debug.Log("Set inventory : " + inventory[i].sprite.name);
                    keyIndex = i;
                    saveInvenActive(keyIndex);
                    saveInvenImage(keyIndex);
                    // 1�������� �κ��丮������ ��ġ�� ������
                    break;
                }
                else if(itemName == "isDuck" && isGetKitchenItem == false)
                {
                    Debug.Log("-------------------DUCK false & false & false--------------------");
                    invArray[i].SetActive(true);
                    inventory[i].sprite = Resources.Load<Sprite>("Img_Duck");
                    Debug.Log("Set inventory : " + inventory[i].sprite.name);
                    duckIndex = i;
                    saveInvenActive(duckIndex);
                    saveInvenImage(duckIndex);
                    // 1�������� �κ��丮������ ��ġ�� ������
                    break;
                }

            }
            
            // �� ��ȯ �������� ���
            // ������� �������� �κ��丮�� �����Ѵٴ� �������� �����.
            else if (invArray[i].activeInHierarchy == false && isConflict == true)
            {
                if (itemName == "isKey" && isGetKey == true && inventory[keyIndex].sprite.name == "Img_Key")
                {
                    Debug.Log("-------------------KEY false & true & true--------------------");
                    invArray[keyIndex].SetActive(true);
                    inventory[keyIndex].sprite = Resources.Load<Sprite>("Img_Key");
                    Debug.Log("Set inventory : " + inventory[keyIndex].sprite.name);
                    break;
                }
                else if (itemName == "isDuck" && isGetKitchenItem == true && inventory[duckIndex].sprite.name == "Img_Duck")
                {
                    Debug.Log("-------------------DUCK false & true & true--------------------");
                    invArray[duckIndex].SetActive(true);
                    inventory[duckIndex].sprite = Resources.Load<Sprite>("Img_Duck");
                    Debug.Log("Set inventory : " + inventory[duckIndex].sprite.name);
                    break;
                }
            }

            else if (invArray[i].activeInHierarchy == true && isConflict == true)
            {
                /*
                Debug.Log("��Ƽ�꿡 �浹");
                Debug.Log("�� i �� : " + i + "�̰� �±״� : " + 
                    itemName + "�̰� ��������Ʈ �̸��� : " + inventory[i].sprite.name + "�̾�");*/

                // ��������Ʈ �̸����� üũ���־�� ������ �ڹٲ� ���������� �۵���
                if (itemName == "isKey" && isGetKey == true && inventory[keyIndex].sprite.name == "Img_Key")
                {
                    Debug.Log("-------------------KEY true & true & true--------------------");
                    invArray[keyIndex].SetActive(true);
                    inventory[keyIndex].sprite = Resources.Load<Sprite>("Img_Key");
                    Debug.Log("Set inventory : " + inventory[keyIndex].sprite.name);
                    break;
                }
                else if (itemName == "isDuck" && isGetKitchenItem == true && inventory[i].sprite.name == "Img_Duck")
                {
                    Debug.Log("-------------------DUCK true & true & true--------------------");
                    invArray[duckIndex].SetActive(true);
                    inventory[duckIndex].sprite = Resources.Load<Sprite>("Img_Duck");
                    Debug.Log("Set inventory : " + inventory[duckIndex].sprite.name);
                    break;
                }
            }
            
            // 0~7 ���� ���� �ߺ��Ǽ� ĭ�� �������� �ʰԲ�
        }
    }
    public void savePlayerData()
    {
        GlobalDataControl.Instance.isGetKey = isGetKey;
        GlobalDataControl.Instance.isGetBathRoomItem = isGetBathRoomItem;
        GlobalDataControl.Instance.isGetInnerRoomItem = isGetInnerRoomItem;
        GlobalDataControl.Instance.isGetKitchenItem = isGetKitchenItem;
    }
    
    // ���������� itemIndex ������ �Ű������� �޾Ƶ鿩�� �Ѵ�.
    public void saveInvenActive(int index)
    {
        GlobalDataControl.Instance.invActive[index] = invArray[index].activeSelf;
    }
    
    public void saveInvenImage(int index)
    {
        GlobalDataControl.Instance.invImage[index] = inventory[index].sprite;
    }    
    public void saveInvenText(int index)
    {
        GlobalDataControl.Instance.invText[index]= myText[index].text;
    }
}
