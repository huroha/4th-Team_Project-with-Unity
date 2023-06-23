using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // 전체 아이템 관리
    // 개수 체크
    public int keyCount; // 현관문 열쇠, 총 3개 필요
    public int bathRoom_itemCount; // 욕실 오리인형
    public int innerRoom_itemCount; // 안방 애착인형
    public int kitchenRoom_itemCount; // 사료
    public int startRoom_itemCount;
    // Start is called before the first frame update
    void Start()
    {       
        // 게임 시작시 아이템 값 초기화(만약 후에 진행상황 저장기능이 필요하면 빼주어야함)
        keyCount = GlobalDataControl.Instance.keyCount;
        bathRoom_itemCount = GlobalDataControl.Instance.bathRoom_itemCount;
        innerRoom_itemCount = GlobalDataControl.Instance.innerRoom_itemCount;
        kitchenRoom_itemCount = GlobalDataControl.Instance.kitchenRoom_itemCount;
        startRoom_itemCount = GlobalDataControl.Instance.startRoom_itemCount; ;
}

    // Update is called once per frame
    void Update()
    {
        savePlayerData();
    }
    // Save data to global control (인벤토리 데이터 관리)
    public void savePlayerData()
    {
        GlobalDataControl.Instance.keyCount = keyCount;
        GlobalDataControl.Instance.bathRoom_itemCount = bathRoom_itemCount;
        GlobalDataControl.Instance.innerRoom_itemCount = innerRoom_itemCount;
        GlobalDataControl.Instance.kitchenRoom_itemCount = kitchenRoom_itemCount;
        GlobalDataControl.Instance.startRoom_itemCount = startRoom_itemCount;
    }

    public int getKeyCount()
    {
        return keyCount;
    }
    public int getBrItemCount()
    {
        return bathRoom_itemCount;
    }
    public int getIrItemCount()
    {
        return innerRoom_itemCount;
    }
    public int getKrItemCount()
    {
        return kitchenRoom_itemCount;
    }
    public int getSrItemCount()
    {
        return startRoom_itemCount;
    }
    public void addKeyCount() // 열쇠 개수
    {
        keyCount++;
    }
    public void addBrItemCount() // 욕실 오리인형 개수
    {
        bathRoom_itemCount++;
    }
    public void addIrItemCount() // 안방 애착인형 개수
    {
        innerRoom_itemCount++;
    }
    public void addKrItemCount() // 주방 사료 개수
    {
        kitchenRoom_itemCount++;
    }
    public void addSrItemCount() // 주방 사료 개수
    {
        startRoom_itemCount++;
    }
}
