using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���� �Ұ� : �κ��丮 ����ȭ(0���� ��� ���� �߻�)
public class Inventory : MonoBehaviour
{
    // ��������Ʈ ������ ���� ����
    GameObject[] invArray = new GameObject[5];
    public Image[] inventory = new Image[5];
    PlayerActor player;
    // �κ��丮 UI ������ ���� ����
    public bool[] isActive = new bool[5];
    Teleport myTp;
    // �κ��丮�� ������ ������ ���� ����
    public Text[] myText = new Text[5];
    PlayerData myData;
    public bool getAllItems = false;
    public int keyIndex;
    public int duckIndex;
    public int dollIndex;
    public int foodIndex;
    public int letterIndex;
    // �κ��丮 ������ ���� ����
    public bool isGetKey;
    public bool isGetBathRoomItem;
    public bool isGetInnerRoomItem;
    public bool isGetKitchenItem;
    public bool isGetLetter;

    void Start()
    {
        Debug.Log("============== �κ��丮 ���� ================");
        player = GameObject.Find("Player").GetComponent<PlayerActor>(); // �÷��̾ ���
        //myTp = GameObject.Find("Door").GetComponent<Teleport>();
        myData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        isGetKey = GlobalDataControl.Instance.isGetKey;
        isGetBathRoomItem = GlobalDataControl.Instance.isGetBathRoomItem;
        isGetInnerRoomItem = GlobalDataControl.Instance.isGetInnerRoomItem;
        isGetKitchenItem = GlobalDataControl.Instance.isGetKitchenItem;
        isGetLetter = GlobalDataControl.Instance.isGetLetter;

        for (int i = 0;i < 5;i++)
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
            // Ȱ��ȭ ���� ����
            invArray[keyIndex].SetActive(GlobalDataControl.Instance.invActive[keyIndex]);
            invArray[duckIndex].SetActive(GlobalDataControl.Instance.invActive[duckIndex]);
            invArray[dollIndex].SetActive(GlobalDataControl.Instance.invActive[dollIndex]);
            invArray[foodIndex].SetActive(GlobalDataControl.Instance.invActive[foodIndex]);
            invArray[letterIndex].SetActive(GlobalDataControl.Instance.invActive[letterIndex]);
            // �̹��� ����
            inventory[keyIndex].sprite = GlobalDataControl.Instance.invImage[keyIndex];
            inventory[duckIndex].sprite = GlobalDataControl.Instance.invImage[duckIndex];
            inventory[dollIndex].sprite = GlobalDataControl.Instance.invImage[dollIndex];
            inventory[foodIndex].sprite = GlobalDataControl.Instance.invImage[foodIndex];
            inventory[letterIndex].sprite = GlobalDataControl.Instance.invImage[letterIndex];
            // �ؽ�Ʈ ����
            myText[keyIndex].text = GlobalDataControl.Instance.invText[keyIndex];
            myText[duckIndex].text = GlobalDataControl.Instance.invText[duckIndex];
            myText[dollIndex].text = GlobalDataControl.Instance.invText[dollIndex];
            myText[foodIndex].text = GlobalDataControl.Instance.invText[foodIndex];
            myText[letterIndex].text = GlobalDataControl.Instance.invText[letterIndex];
            // �ε��� ����
            keyIndex = GlobalDataControl.Instance.keyIndex;
            duckIndex = GlobalDataControl.Instance.duckIndex;
            dollIndex = GlobalDataControl.Instance.dollIndex;
            foodIndex = GlobalDataControl.Instance.foodIndex;
            letterIndex = GlobalDataControl.Instance.letterIndex;
    }

    // Inventory System (���� sprite�� ������ �ִٸ� �߰��� ���� ����)

    public void setInventory(string itemName)
    {
        checkAllItems();
        // �Լ��� inventory�� ��������Ʈ �ִ� �˰��� ���� + �κ��丮 idx�� ���Ͻ�Ŵ
        setInventorySprite(itemName);
            // �������� �˻��ؼ� ������ ���������ִ� �˰���
            switch (itemName)
            {
                case "isKey": // key                  
                    myText[keyIndex].text = myData.getKeyCount().ToString(); // �����Ͱ� ����ǵ� �ٷ� �ݿ��� �ȵ�(���Ǿȸ¾Ƽ�)
                    //isGetKey = true;
                    if (myData.getKeyCount() < 1 && player.getScanOb().GetComponent<ObjData>().getIsUsed() == false && getAllItems == true) // key ������ �ִ� 3��
                    {
                        isGetKey = true;
                        myData.addKeyCount(); // key ���� 1 ����
                        myText[keyIndex].text = myData.getKeyCount().ToString();
                        saveInvenText(keyIndex);
                    }
                    break;
                case "isDuck": // ��� - ��������
                    myText[duckIndex].text = myData.getBrItemCount().ToString(); // �����Ͱ� ����ǵ� �ٷ� �ݿ��� �ȵ�(���Ǿȸ¾Ƽ�)
                    //isGetBathRoomItem = true;
                    if (myData.getBrItemCount() < 1) // key ������ �ִ� 3��
                    {
                        isGetBathRoomItem = true;
                        myData.addBrItemCount(); // key ���� 1 ����
                        myText[duckIndex].text = myData.getBrItemCount().ToString();
                        saveInvenText(duckIndex);
                        Debug.Log("������");
                    }
                    break;
                case "isDoll": // �ȹ� - ��������
                    myText[dollIndex].text = myData.getIrItemCount().ToString(); ; // �����Ͱ� ����ǵ� �ٷ� �ݿ��� �ȵ�(���Ǿȸ¾Ƽ�)
                    //isGetInnerRoomItem = true;
                    if (myData.getIrItemCount() < 1) // key ������ �ִ� 3��
                    {
                        isGetInnerRoomItem = true;
                        myData.addIrItemCount(); // key ���� 1 ����
                        myText[dollIndex].text = myData.getIrItemCount().ToString();
                        saveInvenText(dollIndex);
                    }
                    break;
                case "isFood": // �ֹ� - ���
                    myText[foodIndex].text = myData.getKrItemCount().ToString(); ; // �����Ͱ� ����ǵ� �ٷ� �ݿ��� �ȵ�(���Ǿȸ¾Ƽ�)
                    //isGetKitchenItem = true;
                    if (myData.getKrItemCount() < 1) // key ������ �ִ� 3��
                    {
                        isGetKitchenItem = true;
                        myData.addKrItemCount(); // key ���� 1 ����
                        myText[foodIndex].text = myData.getKrItemCount().ToString();
                        saveInvenText(foodIndex);
                    }
                    break;
                case "isLetter": // �ֹ� - ���
                    myText[letterIndex].text = myData.getSrItemCount().ToString(); ; // �����Ͱ� ����ǵ� �ٷ� �ݿ��� �ȵ�(���Ǿȸ¾Ƽ�)
                    //isGetKitchenItem = true;
                    if (myData.getSrItemCount() < 1) // key ������ �ִ� 3��
                    {
                        isGetLetter = true;
                        myData.addSrItemCount(); // key ���� 1 ����
                        myText[letterIndex].text = myData.getSrItemCount().ToString();
                        saveInvenText(letterIndex);
                    }
                    break;
        }
        Debug.Log("item name is : "+ itemName);
    }

    private void setInventorySprite(string itemName)
    {
        for (int i = 0; i < 5; i++)
        {
            // ���� i�� �κ��丮 ĭ�� active = false �϶� => �κ��丮 Ȱ��ȭ ���θ� ������ ����ĭ�� �������� �������� ���°��� ����
            // isConflict = false �� �� => �ߺ��� üũ�ؼ� ���� �Ȱ��� �������� �κ��丮�� �����Ѵٸ� �������� ���� ����
            if (player.getScanOb() != null)
            {   // �κ��丮�� �������� ó�� ��ġ�ϴ� ���
                if (invArray[i].activeInHierarchy == false)
                {
                    if (itemName == "isKey" && isGetKey == false && getAllItems == true)
                    {
                        
                        Debug.Log("-------------------KEY false & false & false--------------------");
                        invArray[i].SetActive(true);
                        inventory[i].sprite = Resources.Load<Sprite>("Img_Key");
                        Debug.Log("Set inventory : " + inventory[i].sprite.name);
                        keyIndex = i;
                        saveInvenActive(keyIndex);
                        saveInvenImage(keyIndex);
                        saveInvenIndex(keyIndex, "key");
                        // 1�������� �κ��丮������ ��ġ�� ������
                        break;
                    }
                    else if (itemName == "isDuck" && isGetKitchenItem == false)
                    {
                        Debug.Log("-------------------DUCK false & false & false--------------------");
                        invArray[i].SetActive(true);
                        inventory[i].sprite = Resources.Load<Sprite>("Img_Duck");
                        Debug.Log("Set inventory : " + inventory[i].sprite.name);
                        duckIndex = i;
                        saveInvenActive(duckIndex);
                        saveInvenImage(duckIndex);
                        saveInvenIndex(duckIndex, "duck");
                        // 1�������� �κ��丮������ ��ġ�� ������
                        break;
                    }
                    else if (itemName == "isDoll" && isGetInnerRoomItem == false)
                    {
                        Debug.Log("-------------------DOLL false & false & false--------------------");
                        invArray[i].SetActive(true);
                        inventory[i].sprite = Resources.Load<Sprite>("Img_Doll");
                        Debug.Log("Set inventory : " + inventory[i].sprite.name);
                        dollIndex = i;
                        saveInvenActive(dollIndex);
                        saveInvenImage(dollIndex);
                        saveInvenIndex(dollIndex, "doll");
                        // 1�������� �κ��丮������ ��ġ�� ������
                        break;
                    }
                    else if (itemName == "isFood" && isGetKitchenItem == false)
                    {
                        Debug.Log("-------------------FOOD false & false & false--------------------");
                        invArray[i].SetActive(true);
                        inventory[i].sprite = Resources.Load<Sprite>("Img_Food");
                        Debug.Log("Set inventory : " + inventory[i].sprite.name);
                        foodIndex = i;
                        saveInvenActive(foodIndex);
                        saveInvenImage(foodIndex);
                        saveInvenIndex(foodIndex, "food");

                        // 1�������� �κ��丮������ ��ġ�� ������
                        break;
                    }
                    else if (itemName == "isLetter" && isGetLetter == false)
                    {
                        Debug.Log("-------------------FOOD false & false & false--------------------");
                        invArray[i].SetActive(true);
                        inventory[i].sprite = Resources.Load<Sprite>("Img_Letter");
                        Debug.Log("Set inventory : " + inventory[i].sprite.name);
                        letterIndex = i;
                        saveInvenActive(letterIndex);
                        saveInvenImage(letterIndex);
                        saveInvenIndex(letterIndex, "letter");

                        // 1�������� �κ��丮������ ��ġ�� ������
                        break;
                    }
                }
                // �κ��丮�� �������� �̹� �����ϴ� ���
                else if (invArray[i].activeInHierarchy == true) 
                {
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
                    else if (itemName == "isDoll" && isGetInnerRoomItem == true && inventory[dollIndex].sprite.name == "Img_Doll")
                    {
                        Debug.Log("-------------------DOLL true & true & true--------------------");
                        invArray[dollIndex].SetActive(true);
                        inventory[dollIndex].sprite = Resources.Load<Sprite>("Img_Doll");
                        Debug.Log("Set inventory : " + inventory[dollIndex].sprite.name);
                        break;
                    }
                    else if (itemName == "isFood" && isGetKitchenItem == true && inventory[foodIndex].sprite.name == "Img_Food")
                    {
                        Debug.Log("-------------------FOOD false & true & true--------------------");
                        invArray[foodIndex].SetActive(true);
                        inventory[foodIndex].sprite = Resources.Load<Sprite>("Img_Food");
                        Debug.Log("Set inventory : " + inventory[foodIndex].sprite.name);
                        break;
                    }
                    else if (itemName == "isLetter" && isGetLetter == true && inventory[letterIndex].sprite.name == "Img_Letter")
                    {
                        Debug.Log("-------------------Letter false & true & true--------------------");
                        invArray[letterIndex].SetActive(true);
                        inventory[letterIndex].sprite = Resources.Load<Sprite>("Img_Letter");
                        Debug.Log("Set inventory : " + inventory[letterIndex].sprite.name);
                        break;
                    }
                }
            }
            else if (player.getScanOb() == null)
            {
                // �κ��丮�� �������� ó�� ��ġ�ϴ� ���
                if (invArray[i].activeInHierarchy == false)
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
                        saveInvenIndex(keyIndex, "key");
                        // 1�������� �κ��丮������ ��ġ�� ������
                        break;
                    }
                    else if (itemName == "isDuck" && isGetBathRoomItem == false)
                    {
                        Debug.Log("-------------------DUCK false & false & false--------------------");
                        invArray[i].SetActive(true);
                        inventory[i].sprite = Resources.Load<Sprite>("Img_Duck");
                        Debug.Log("Set inventory : " + inventory[i].sprite.name);
                        duckIndex = i;
                        saveInvenActive(duckIndex);
                        saveInvenImage(duckIndex);
                        saveInvenIndex(duckIndex, "duck");
                        // 1�������� �κ��丮������ ��ġ�� ������
                        break;
                    }
                    else if (itemName == "isDoll" && isGetInnerRoomItem == false)
                    {
                        Debug.Log("-------------------DOLL false & false & false--------------------");
                        invArray[i].SetActive(true);
                        inventory[i].sprite = Resources.Load<Sprite>("Img_Doll");
                        Debug.Log("Set inventory : " + inventory[i].sprite.name);
                        dollIndex = i;
                        saveInvenActive(dollIndex);
                        saveInvenImage(dollIndex);
                        saveInvenIndex(dollIndex, "doll");
                        // 1�������� �κ��丮������ ��ġ�� ������
                        break;
                    }
                    else if (itemName == "isFood" && isGetKitchenItem == false)
                    {
                        Debug.Log("-------------------FOOD false & false & false--------------------");
                        invArray[i].SetActive(true);
                        inventory[i].sprite = Resources.Load<Sprite>("Img_Food");
                        Debug.Log("Set inventory : " + inventory[i].sprite.name);
                        foodIndex = i;
                        saveInvenActive(foodIndex);
                        saveInvenImage(foodIndex);
                        saveInvenIndex(foodIndex, "food");
                        // 1�������� �κ��丮������ ��ġ�� ������
                        break;
                    }
                    else if (itemName == "isLetter" && isGetLetter == false)
                    {
                        Debug.Log("-------------------FOOD false & false & false--------------------");
                        invArray[i].SetActive(true);
                        inventory[i].sprite = Resources.Load<Sprite>("Img_Letter");
                        Debug.Log("Set inventory : " + inventory[i].sprite.name);
                        letterIndex = i;
                        saveInvenActive(letterIndex);
                        saveInvenImage(letterIndex);
                        saveInvenIndex(letterIndex, "letter");

                        // 1�������� �κ��丮������ ��ġ�� ������
                        break;
                    }
                }
                // �� ��ȯ �������� ���
                // �κ��丮�� �������� �̹� �����ϴ� ���
                else if (invArray[i].activeInHierarchy == true)
                {
                    if (itemName == "isKey" && isGetKey == true && inventory[keyIndex].sprite.name == "Img_Key")
                    {
                        Debug.Log("-------------------KEY false & true & true--------------------");
                        invArray[keyIndex].SetActive(true);
                        inventory[keyIndex].sprite = Resources.Load<Sprite>("Img_Key");
                        Debug.Log("Set inventory : " + inventory[keyIndex].sprite.name);
                        break;
                    }
                    else if (itemName == "isDuck" && isGetBathRoomItem == true && inventory[duckIndex].sprite.name == "Img_Duck")
                    {
                        Debug.Log("-------------------DUCK false & true & true--------------------");
                        invArray[duckIndex].SetActive(true);
                        inventory[duckIndex].sprite = Resources.Load<Sprite>("Img_Duck");
                        Debug.Log("Set inventory : " + inventory[duckIndex].sprite.name);
                        break;
                    }
                    else if (itemName == "isDoll" && isGetInnerRoomItem == true && inventory[dollIndex].sprite.name == "Img_Doll")
                    {
                        Debug.Log("-------------------DOLL false & true & true--------------------");
                        invArray[dollIndex].SetActive(true);
                        inventory[dollIndex].sprite = Resources.Load<Sprite>("Img_Doll");
                        Debug.Log("Set inventory : " + inventory[dollIndex].sprite.name);
                        break;
                    }
                    else if (itemName == "isFood" && isGetKitchenItem == true && inventory[foodIndex].sprite.name == "Img_Food")
                    {
                        Debug.Log("-------------------FOOD false & true & true--------------------");
                        invArray[foodIndex].SetActive(true);
                        inventory[foodIndex].sprite = Resources.Load<Sprite>("Img_Food");
                        Debug.Log("Set inventory : " + inventory[foodIndex].sprite.name);
                        break;
                    }
                    else if (itemName == "isLetter" && isGetLetter == true && inventory[letterIndex].sprite.name == "Img_Letter")
                    {
                        Debug.Log("-------------------Letter false & true & true--------------------");
                        invArray[letterIndex].SetActive(true);
                        inventory[letterIndex].sprite = Resources.Load<Sprite>("Img_Letter");
                        Debug.Log("Set inventory : " + inventory[letterIndex].sprite.name);
                        break;
                    }
                }
            }
            // 0~7 ���� ���� �ߺ��Ǽ� ĭ�� �������� �ʰԲ�
        }
    }
    void checkAllItems()
    {
        if(myData.getBrItemCount() == 1 && myData.getBrItemCount() == 1 && myData.getIrItemCount() == 1)
        {
            getAllItems = true;
        }
    }
    public void savePlayerData()
    {
        GlobalDataControl.Instance.isGetKey = isGetKey;
        GlobalDataControl.Instance.isGetBathRoomItem = isGetBathRoomItem;
        GlobalDataControl.Instance.isGetInnerRoomItem = isGetInnerRoomItem;
        GlobalDataControl.Instance.isGetKitchenItem = isGetKitchenItem;
        GlobalDataControl.Instance.isGetLetter = isGetLetter;
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
    public void saveInvenIndex(int index,string itemName)
    {
        if(itemName == "key")
        {
            GlobalDataControl.Instance.keyIndex = keyIndex;
        }
        else if(itemName == "duck")
        {
            GlobalDataControl.Instance.duckIndex = duckIndex;
        }
        else if(itemName == "doll")
        {
            GlobalDataControl.Instance.dollIndex = dollIndex;
        }
        else if (itemName == "food")
        {
            GlobalDataControl.Instance.foodIndex = foodIndex;
        }
        else if (itemName == "letter")
        {
            GlobalDataControl.Instance.letterIndex = letterIndex;
        }

    }
}
