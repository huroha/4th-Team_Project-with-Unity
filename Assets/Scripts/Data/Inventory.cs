using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 내일 할거 : 인벤토리 정상화(0번에 계속 문제 발생)
public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    // 스프라이트 변경을 위한 변수
    GameObject[] invArray = new GameObject[4];
    public Image[] inventory = new Image[4];
    PlayerActor player;
    // 인벤토리 UI 유지를 위한 변수
    public bool[] isActive = new bool[4];
    Teleport myTp;
    // 인벤토리의 아이템 개수를 위한 변수
    public Text[] myText = new Text[4];
    public PlayerData myData;
    public int keyIndex;
    public int duckIndex;
    public int innerIndex;
    public int kitchenIndex;
    // 인벤토리 정렬을 위한 변수
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
        Debug.Log("============== 인벤토리 시작 ================");
        player = GameObject.Find("Player").GetComponent<PlayerActor>(); // 플레이어를 등록
        myTp = GameObject.Find("TP").GetComponent<Teleport>();
        //myData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        isGetKey = GlobalDataControl.Instance.isGetKey;
        isGetBathRoomItem = GlobalDataControl.Instance.isGetBathRoomItem;
        isGetInnerRoomItem = GlobalDataControl.Instance.isGetInnerRoomItem;
        isGetKitchenItem = GlobalDataControl.Instance.isGetKitchenItem;

        for (int i = 0;i < 4;i++)
        {
            // 인벤토리 각 칸 설정
            invArray[i] = transform.GetChild(i).gameObject; // 자식을 번호로 찾음
            inventory[i] = invArray[i].GetComponent<Image>();
            myText[i] = invArray[i].GetComponentInChildren<Text>();
        }

        if(myTp.getSceneMoveCheck())
        {
            // 활성화 여부 관리
            invArray[keyIndex].SetActive(GlobalDataControl.Instance.invActive[keyIndex]);
            invArray[duckIndex].SetActive(GlobalDataControl.Instance.invActive[duckIndex]);
            // 이미지 관리
            inventory[keyIndex].sprite = GlobalDataControl.Instance.invImage[keyIndex];
            inventory[duckIndex].sprite = GlobalDataControl.Instance.invImage[duckIndex];
            // 텍스트 관리
            myText[keyIndex].text = GlobalDataControl.Instance.invText[keyIndex];
            myText[duckIndex].text = GlobalDataControl.Instance.invText[duckIndex];
        }
    }
    // Update is called once per frame
    void Update()
    {
        savePlayerData();
    }

    // Inventory System (만약 sprite가 같은게 있다면 추가를 하지 않음)

    public void setInventory(string itemName)
    {
        // 함수로 inventory에 스프라이트 넣는 알고리즘 뺏음 + 인벤토리 idx를 리턴시킴
        setInventorySprite(itemName);
            // 아이템을 검사해서 개수를 증가시켜주는 알고리즘
            switch (itemName)
            {
                case "isKey": // key
                    //Debug.Log("Key Add , " + myData.getKeyCount());
                    myText[keyIndex].text = myData.getKeyCount().ToString(); // 데이터가 저장되도 바로 반영이 안됨(조건안맞아서)
                    isGetKey = true;
                    if (myData.getKeyCount() < 3) // key 개수는 최대 3개
                    {         
                        myData.addKeyCount(); // key 개수 1 증가
                        myText[keyIndex].text = myData.getKeyCount().ToString();
                        saveInvenText(keyIndex);
                    }
                    break;
                case "isDuck": // 욕실 - 오리인형
                    myText[duckIndex].text = myData.getBrItemCount().ToString(); // 데이터가 저장되도 바로 반영이 안됨(조건안맞아서)
                    isGetBathRoomItem = true;
                    if (myData.getBrItemCount() < 1) // key 개수는 최대 3개
                    {
                        myData.addBrItemCount(); // key 개수 1 증가
                        myText[duckIndex].text = myData.getBrItemCount().ToString();
                        saveInvenText(duckIndex);
                    }
                    break;
                case "doll": // 안방 - 애착인형
                    Debug.Log("doll");

                    break;
                case "food": // 주방 - 사료
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
            Debug.Log("----------------KEY 에 의해 중복 발생-----------------------");
            isConflict = true;
         }
         else if((player.getScanOb().tag == "isDuck" && isGetBathRoomItem == true))
        {
            Debug.Log("----------------DUCK 에 의해 중복 발생----------------------");
            isConflict = true;
        }
        
        for (int i = 0; i < 4; i++)
        {
            // 만약 i번 인벤토리 칸이 active = false 일때 => 인벤토리 활성화 여부를 따져서 같은칸에 여러가지 아이템이 들어가는것을 방지
            // isConflict = false 일 때 => 중복을 체크해서 만약 똑같은 아이템이 인벤토리에 존재한다면 아이템을 넣지 않음
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
                    // 1차적으로 인벤토리에서의 위치가 정해짐
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
                    // 1차적으로 인벤토리에서의 위치가 정해짐
                    break;
                }

            }
            
            // 씬 전환 했을때의 경우
            // 여기부턴 아이템이 인벤토리에 존재한다는 가정으로 진행됨.
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
                Debug.Log("엑티브에 충돌");
                Debug.Log("자 i 는 : " + i + "이고 태그는 : " + 
                    itemName + "이고 스프라이트 이름은 : " + inventory[i].sprite.name + "이야");*/

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
            }
            
            // 0~7 까지 전부 중복되서 칸을 차지하지 않게끔
        }
    }
    public void savePlayerData()
    {
        GlobalDataControl.Instance.isGetKey = isGetKey;
        GlobalDataControl.Instance.isGetBathRoomItem = isGetBathRoomItem;
        GlobalDataControl.Instance.isGetInnerRoomItem = isGetInnerRoomItem;
        GlobalDataControl.Instance.isGetKitchenItem = isGetKitchenItem;
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
}
