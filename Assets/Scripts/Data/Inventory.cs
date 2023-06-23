using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 내일 할거 : 인벤토리 정상화(0번에 계속 문제 발생)
public class Inventory : MonoBehaviour
{
    // 스프라이트 변경을 위한 변수
    GameObject[] invArray = new GameObject[5];
    public Image[] inventory = new Image[5];
    PlayerActor player;
    // 인벤토리 UI 유지를 위한 변수
    public bool[] isActive = new bool[5];
    Teleport myTp;
    // 인벤토리의 아이템 개수를 위한 변수
    public Text[] myText = new Text[5];
    PlayerData myData;
    public bool getAllItems = false;
    public int keyIndex;
    public int duckIndex;
    public int dollIndex;
    public int foodIndex;
    public int letterIndex;
    // 인벤토리 정렬을 위한 변수
    public bool isGetKey;
    public bool isGetBathRoomItem;
    public bool isGetInnerRoomItem;
    public bool isGetKitchenItem;
    public bool isGetLetter;

    void Start()
    {
        Debug.Log("============== 인벤토리 시작 ================");
        player = GameObject.Find("Player").GetComponent<PlayerActor>(); // 플레이어를 등록
        //myTp = GameObject.Find("Door").GetComponent<Teleport>();
        myData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        isGetKey = GlobalDataControl.Instance.isGetKey;
        isGetBathRoomItem = GlobalDataControl.Instance.isGetBathRoomItem;
        isGetInnerRoomItem = GlobalDataControl.Instance.isGetInnerRoomItem;
        isGetKitchenItem = GlobalDataControl.Instance.isGetKitchenItem;
        isGetLetter = GlobalDataControl.Instance.isGetLetter;

        for (int i = 0;i < 5;i++)
        {
            // 인벤토리 각 칸 설정
            invArray[i] = transform.GetChild(i).gameObject; // 자식을 번호로 찾음
            inventory[i] = invArray[i].GetComponent<Image>();
            myText[i] = invArray[i].GetComponentInChildren<Text>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        savePlayerData();
            // 활성화 여부 관리
            invArray[keyIndex].SetActive(GlobalDataControl.Instance.invActive[keyIndex]);
            invArray[duckIndex].SetActive(GlobalDataControl.Instance.invActive[duckIndex]);
            invArray[dollIndex].SetActive(GlobalDataControl.Instance.invActive[dollIndex]);
            invArray[foodIndex].SetActive(GlobalDataControl.Instance.invActive[foodIndex]);
            invArray[letterIndex].SetActive(GlobalDataControl.Instance.invActive[letterIndex]);
            // 이미지 관리
            inventory[keyIndex].sprite = GlobalDataControl.Instance.invImage[keyIndex];
            inventory[duckIndex].sprite = GlobalDataControl.Instance.invImage[duckIndex];
            inventory[dollIndex].sprite = GlobalDataControl.Instance.invImage[dollIndex];
            inventory[foodIndex].sprite = GlobalDataControl.Instance.invImage[foodIndex];
            inventory[letterIndex].sprite = GlobalDataControl.Instance.invImage[letterIndex];
            // 텍스트 관리
            myText[keyIndex].text = GlobalDataControl.Instance.invText[keyIndex];
            myText[duckIndex].text = GlobalDataControl.Instance.invText[duckIndex];
            myText[dollIndex].text = GlobalDataControl.Instance.invText[dollIndex];
            myText[foodIndex].text = GlobalDataControl.Instance.invText[foodIndex];
            myText[letterIndex].text = GlobalDataControl.Instance.invText[letterIndex];
            // 인덱스 관리
            keyIndex = GlobalDataControl.Instance.keyIndex;
            duckIndex = GlobalDataControl.Instance.duckIndex;
            dollIndex = GlobalDataControl.Instance.dollIndex;
            foodIndex = GlobalDataControl.Instance.foodIndex;
            letterIndex = GlobalDataControl.Instance.letterIndex;
    }

    // Inventory System (만약 sprite가 같은게 있다면 추가를 하지 않음)

    public void setInventory(string itemName)
    {
        checkAllItems();
        // 함수로 inventory에 스프라이트 넣는 알고리즘 뺏음 + 인벤토리 idx를 리턴시킴
        setInventorySprite(itemName);
            // 아이템을 검사해서 개수를 증가시켜주는 알고리즘
            switch (itemName)
            {
                case "isKey": // key                  
                    myText[keyIndex].text = myData.getKeyCount().ToString(); // 데이터가 저장되도 바로 반영이 안됨(조건안맞아서)
                    //isGetKey = true;
                    if (myData.getKeyCount() < 1 && player.getScanOb().GetComponent<ObjData>().getIsUsed() == false && getAllItems == true) // key 개수는 최대 3개
                    {
                        isGetKey = true;
                        myData.addKeyCount(); // key 개수 1 증가
                        myText[keyIndex].text = myData.getKeyCount().ToString();
                        saveInvenText(keyIndex);
                    }
                    break;
                case "isDuck": // 욕실 - 오리인형
                    myText[duckIndex].text = myData.getBrItemCount().ToString(); // 데이터가 저장되도 바로 반영이 안됨(조건안맞아서)
                    //isGetBathRoomItem = true;
                    if (myData.getBrItemCount() < 1) // key 개수는 최대 3개
                    {
                        isGetBathRoomItem = true;
                        myData.addBrItemCount(); // key 개수 1 증가
                        myText[duckIndex].text = myData.getBrItemCount().ToString();
                        saveInvenText(duckIndex);
                        Debug.Log("오리덕");
                    }
                    break;
                case "isDoll": // 안방 - 애착인형
                    myText[dollIndex].text = myData.getIrItemCount().ToString(); ; // 데이터가 저장되도 바로 반영이 안됨(조건안맞아서)
                    //isGetInnerRoomItem = true;
                    if (myData.getIrItemCount() < 1) // key 개수는 최대 3개
                    {
                        isGetInnerRoomItem = true;
                        myData.addIrItemCount(); // key 개수 1 증가
                        myText[dollIndex].text = myData.getIrItemCount().ToString();
                        saveInvenText(dollIndex);
                    }
                    break;
                case "isFood": // 주방 - 사료
                    myText[foodIndex].text = myData.getKrItemCount().ToString(); ; // 데이터가 저장되도 바로 반영이 안됨(조건안맞아서)
                    //isGetKitchenItem = true;
                    if (myData.getKrItemCount() < 1) // key 개수는 최대 3개
                    {
                        isGetKitchenItem = true;
                        myData.addKrItemCount(); // key 개수 1 증가
                        myText[foodIndex].text = myData.getKrItemCount().ToString();
                        saveInvenText(foodIndex);
                    }
                    break;
                case "isLetter": // 주방 - 사료
                    myText[letterIndex].text = myData.getSrItemCount().ToString(); ; // 데이터가 저장되도 바로 반영이 안됨(조건안맞아서)
                    //isGetKitchenItem = true;
                    if (myData.getSrItemCount() < 1) // key 개수는 최대 3개
                    {
                        isGetLetter = true;
                        myData.addSrItemCount(); // key 개수 1 증가
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
            // 만약 i번 인벤토리 칸이 active = false 일때 => 인벤토리 활성화 여부를 따져서 같은칸에 여러가지 아이템이 들어가는것을 방지
            // isConflict = false 일 때 => 중복을 체크해서 만약 똑같은 아이템이 인벤토리에 존재한다면 아이템을 넣지 않음
            if (player.getScanOb() != null)
            {   // 인벤토리에 아이템을 처음 배치하는 경우
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
                        // 1차적으로 인벤토리에서의 위치가 정해짐
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
                        // 1차적으로 인벤토리에서의 위치가 정해짐
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
                        // 1차적으로 인벤토리에서의 위치가 정해짐
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

                        // 1차적으로 인벤토리에서의 위치가 정해짐
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

                        // 1차적으로 인벤토리에서의 위치가 정해짐
                        break;
                    }
                }
                // 인벤토리에 아이템이 이미 존재하는 경우
                else if (invArray[i].activeInHierarchy == true) 
                {
                    // 스프라이트 이름까지 체크해주어야 순서가 뒤바뀌어도 정상적으로 작동함
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
                // 인벤토리에 아이템을 처음 배치하는 경우
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
                        // 1차적으로 인벤토리에서의 위치가 정해짐
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
                        // 1차적으로 인벤토리에서의 위치가 정해짐
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
                        // 1차적으로 인벤토리에서의 위치가 정해짐
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
                        // 1차적으로 인벤토리에서의 위치가 정해짐
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

                        // 1차적으로 인벤토리에서의 위치가 정해짐
                        break;
                    }
                }
                // 씬 전환 했을때의 경우
                // 인벤토리에 아이템이 이미 존재하는 경우
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
            // 0~7 까지 전부 중복되서 칸을 차지하지 않게끔
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
    
    // 공통적으로 itemIndex 정보를 매개변수로 받아들여야 한다.
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
