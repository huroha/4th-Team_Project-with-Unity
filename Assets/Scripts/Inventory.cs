using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 내일 할거 : 인벤토리 정상화(0번에 계속 문제 발생)
public class Inventory : MonoBehaviour
{
    // 스프라이트 변경을 위한 변수
    GameObject[] invArray = new GameObject[7];
    Image[] inventory = new Image[7];
    PlayerActor player;

    // 인벤토리의 아이템 개수를 위한 변수
    Text[] myText = new Text[7];
    public PlayerData myData;

    // 인벤토리 정렬을 위한 변수
    public bool isGetKey;
    public bool isGetBathRoomItem;
    public bool isGetInnerRoomItem;
    public bool isGetKitchenItem;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Player").GetComponent<PlayerActor>(); // 플레이어를 등록
        //myData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        isGetKey = GlobalDataControl.Instance.isGetKey;
        isGetBathRoomItem = GlobalDataControl.Instance.isGetBathRoomItem;
        isGetInnerRoomItem = GlobalDataControl.Instance.isGetInnerRoomItem;
        isGetKitchenItem = GlobalDataControl.Instance.isGetKitchenItem;

        for (int i = 0;i < 7;i++)
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
    }

    // Inventory System (만약 sprite가 같은게 있다면 추가를 하지 않음)

    public void setInventory(string itemName)
    {
        // 함수로 inventory에 스프라이트 넣는 알고리즘 뺏음 + 인벤토리 idx를 리턴시킴
        int itemIdx = setInventorySprite(itemName);
        Debug.Log("아이템 넘버는 : " + itemIdx);
            // 아이템을 검사해서 개수를 증가시켜주는 알고리즘
            switch (itemName)
            {
                case "isKey": // key
                    //Debug.Log("Key Add , " + myData.getKeyCount());
                    myText[itemIdx].text = myData.getKeyCount().ToString(); // 데이터가 저장되도 바로 반영이 안됨(조건안맞아서)
                    isGetKey = true;
                    if (myData.getKeyCount() < 3) // key 개수는 최대 3개
                    {         
                        myData.addKeyCount(); // key 개수 1 증가
                        myText[itemIdx].text = myData.getKeyCount().ToString();
                    }
                    break;
                case "isDuck": // 욕실 - 오리인형
                myText[itemIdx].text = myData.getBrItemCount().ToString(); // 데이터가 저장되도 바로 반영이 안됨(조건안맞아서)
                isGetBathRoomItem = true;
                if (myData.getBrItemCount() < 1) // key 개수는 최대 3개
                    {
                        myData.addBrItemCount(); // key 개수 1 증가
                        myText[itemIdx].text = myData.getBrItemCount().ToString();
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
            // 만약 i번 인벤토리 칸이 active = false 일때 => 인벤토리 활성화 여부를 따져서 같은칸에 여러가지 아이템이 들어가는것을 방지
            // isConflict = false 일 때 => 중복을 체크해서 만약 똑같은 아이템이 인벤토리에 존재한다면 아이템을 넣지 않음
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
            
            // 씬 전환 했을때의 경우
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
                Debug.Log("야이 시발럼아");
                Debug.Log("자 i 는 : " + i + "이고 태그는 : " + 
                    itemName + "이고 스프라이트 이름은 : " + inventory[i].sprite.name + "이야");
                // 스프라이트 이름까지 체크해주어야 순서가 뒤바뀌어도 정상적으로 작동함
                if (itemName == "isKey" && isGetKey == true && inventory[i].sprite.name == "Img_Key")
                {
                    Debug.Log("이건 열쇠잖아");
                    invArray[i].SetActive(true);
                    inventory[i].sprite = Resources.Load<Sprite>("Img_Key");
                    //inventory[i].sprite = player.getScanOb().GetComponent<SpriteRenderer>().sprite;
                    Debug.Log("Set inventory : " + inventory[i].sprite.name);
                    itemIdx = i;
                    break;
                }
                else if (itemName == "isDuck" && isGetKitchenItem == true && inventory[i].sprite.name == "Img_Duck")
                {
                    Debug.Log("이게 오리야");
                    invArray[i].SetActive(true);
                    inventory[i].sprite = Resources.Load<Sprite>("Img_Duck");
                    //inventory[i].sprite = player.getScanOb().GetComponent<SpriteRenderer>().sprite;
                    Debug.Log("Set inventory : " + inventory[i].sprite.name);
                    itemIdx = i;
                    break;
                }
            }
            
            // 0~7 까지 전부 중복되서 칸을 차지하지 않게끔
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
