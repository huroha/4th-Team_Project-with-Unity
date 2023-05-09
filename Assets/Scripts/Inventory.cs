using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���� �Ұ� : �κ��丮 ����ȭ(0���� ��� ���� �߻�)
public class Inventory : MonoBehaviour
{
    // ��������Ʈ ������ ���� ����
    GameObject[] invArray = new GameObject[7];
    Image[] inventory = new Image[7];
    PlayerActor player;

    // �κ��丮�� ������ ������ ���� ����
    Text[] myText = new Text[7];
    public PlayerData myData;

    // �κ��丮 ������ ���� ����
    public bool isGetKey;
    public bool isGetBathRoomItem;
    public bool isGetInnerRoomItem;
    public bool isGetKitchenItem;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Player").GetComponent<PlayerActor>(); // �÷��̾ ���
        //myData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        isGetKey = GlobalDataControl.Instance.isGetKey;
        isGetBathRoomItem = GlobalDataControl.Instance.isGetBathRoomItem;
        isGetInnerRoomItem = GlobalDataControl.Instance.isGetInnerRoomItem;
        isGetKitchenItem = GlobalDataControl.Instance.isGetKitchenItem;

        for (int i = 0;i < 7;i++)
        {
            // �κ��丮 �� ĭ ����
            invArray[i] = transform.GetChild(i).gameObject; // �ڽ��� ��ȣ�� ã��
            inventory[i] = invArray[i].GetComponent<Image>();
            myText[i] = invArray[i].GetComponentInChildren<Text>();
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
        int itemIdx = setInventorySprite(itemName);
        Debug.Log("������ �ѹ��� : " + itemIdx);
            // �������� �˻��ؼ� ������ ���������ִ� �˰���
            switch (itemName)
            {
                case "isKey": // key
                    //Debug.Log("Key Add , " + myData.getKeyCount());
                    myText[itemIdx].text = myData.getKeyCount().ToString(); // �����Ͱ� ����ǵ� �ٷ� �ݿ��� �ȵ�(���Ǿȸ¾Ƽ�)
                    isGetKey = true;
                    if (myData.getKeyCount() < 3) // key ������ �ִ� 3��
                    {         
                        myData.addKeyCount(); // key ���� 1 ����
                        myText[itemIdx].text = myData.getKeyCount().ToString();
                    }
                    break;
                case "isDuck": // ��� - ��������
                myText[itemIdx].text = myData.getBrItemCount().ToString(); // �����Ͱ� ����ǵ� �ٷ� �ݿ��� �ȵ�(���Ǿȸ¾Ƽ�)
                isGetBathRoomItem = true;
                if (myData.getBrItemCount() < 1) // key ������ �ִ� 3��
                    {
                        myData.addBrItemCount(); // key ���� 1 ����
                        myText[itemIdx].text = myData.getBrItemCount().ToString();
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

    private int setInventorySprite(string itemName)
    {
        bool isConflict = false;
        int itemIdx = 0;
        
         if ((player.getScanOb().tag == "isKey" && isGetKey == true)
                || (player.getScanOb().tag == "isDuck" && isGetBathRoomItem == true))
         {
             isConflict = true;
         }
        
        for (int i = 0; i < 7; i++)
        {
            // ���� i�� �κ��丮 ĭ�� active = false �϶� => �κ��丮 Ȱ��ȭ ���θ� ������ ����ĭ�� �������� �������� ���°��� ����
            // isConflict = false �� �� => �ߺ��� üũ�ؼ� ���� �Ȱ��� �������� �κ��丮�� �����Ѵٸ� �������� ���� ����
            if (invArray[i].activeInHierarchy == false && isConflict == false)
            {
                if (itemName == "isKey")
                {
                    invArray[i].SetActive(true);
                    inventory[i].sprite = Resources.Load<Sprite>("Img_Key");
                    //inventory[i].sprite = player.getScanOb().GetComponent<SpriteRenderer>().sprite;
                    Debug.Log("Set inventory : " + inventory[i].sprite.name);
                    itemIdx = i;
                    break;
                }
                else if(itemName == "isDuck")
                {
                    invArray[i].SetActive(true);
                    inventory[i].sprite = Resources.Load<Sprite>("Img_Duck");
                    //inventory[i].sprite = player.getScanOb().GetComponent<SpriteRenderer>().sprite;
                    Debug.Log("Set inventory : " + inventory[i].sprite.name);
                    itemIdx = i;
                    break;
                }

            }
            
            // �� ��ȯ �������� ���
            else if (invArray[i].activeInHierarchy == false && isConflict == true)
            {
                if (itemName == "isKey" && isGetKey == true)
                {
                    invArray[i].SetActive(true);
                    inventory[i].sprite = Resources.Load<Sprite>("Img_Key");
                    //inventory[i].sprite = player.getScanOb().GetComponent<SpriteRenderer>().sprite;
                    Debug.Log("Set inventory : " + inventory[i].sprite.name);
                    itemIdx = i;
                    Debug.Log("get key NOPE");
                    break;
                }
                else if (itemName == "isDuck" && isGetKitchenItem == true)
                {
                    invArray[i].SetActive(true);
                    inventory[i].sprite = Resources.Load<Sprite>("Img_Duck");
                    //inventory[i].sprite = player.getScanOb().GetComponent<SpriteRenderer>().sprite;
                    Debug.Log("Set inventory : " + inventory[i].sprite.name);
                    itemIdx = i;
                    Debug.Log("get key NOPE");
                    break;
                }
            }

            else if (invArray[i].activeInHierarchy == true && isConflict == true)
            {
                Debug.Log("���� �ù߷���");
                Debug.Log("�� i �� : " + i + "�̰� �±״� : " + 
                    itemName + "�̰� ��������Ʈ �̸��� : " + inventory[i].sprite.name + "�̾�");
                // ��������Ʈ �̸����� üũ���־�� ������ �ڹٲ� ���������� �۵���
                if (itemName == "isKey" && isGetKey == true && inventory[i].sprite.name == "Img_Key")
                {
                    Debug.Log("�̰� �����ݾ�");
                    invArray[i].SetActive(true);
                    inventory[i].sprite = Resources.Load<Sprite>("Img_Key");
                    //inventory[i].sprite = player.getScanOb().GetComponent<SpriteRenderer>().sprite;
                    Debug.Log("Set inventory : " + inventory[i].sprite.name);
                    itemIdx = i;
                    break;
                }
                else if (itemName == "isDuck" && isGetKitchenItem == true && inventory[i].sprite.name == "Img_Duck")
                {
                    Debug.Log("�̰� ������");
                    invArray[i].SetActive(true);
                    inventory[i].sprite = Resources.Load<Sprite>("Img_Duck");
                    //inventory[i].sprite = player.getScanOb().GetComponent<SpriteRenderer>().sprite;
                    Debug.Log("Set inventory : " + inventory[i].sprite.name);
                    itemIdx = i;
                    break;
                }
            }
            
            // 0~7 ���� ���� �ߺ��Ǽ� ĭ�� �������� �ʰԲ�
        }
        return itemIdx;
    }
    void itemCheckSystem(string itemName)
    {

    }
    public void savePlayerData()
    {
        GlobalDataControl.Instance.isGetKey = isGetKey;
        GlobalDataControl.Instance.isGetBathRoomItem = isGetBathRoomItem;
        GlobalDataControl.Instance.isGetInnerRoomItem = isGetInnerRoomItem;
        GlobalDataControl.Instance.isGetKitchenItem = isGetKitchenItem;
    }
}
