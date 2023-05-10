using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GlobalDataControl : MonoBehaviour
{
    public static GlobalDataControl Instance;

    // 전체 아이템 관리
    // 개수 체크
    public int keyCount = 0; // 현관문 열쇠, 총 3개 필요
    public int bathRoom_itemCount = 0; // 욕실 오리인형
    public int innerRoom_itemCount = 0; // 안방 애착인형
    public int kitchenRoom_itemCount = 0; // 사료
    // 아이템 중복 체크
    public bool isGetKey = false;
    public bool isGetBathRoomItem = false;
    public bool isGetInnerRoomItem = false;
    public bool isGetKitchenItem = false;
    // UI 유지
    public bool[] invActive = new bool[4];
    public Sprite[] invImage = new Sprite[4];
    public string[] invText = new string[4];

    void Awake()
    {
        // 게임 시작시 아이템 값 초기화(만약 후에 진행상황 저장기능이 필요하면 빼주어야함)

        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
