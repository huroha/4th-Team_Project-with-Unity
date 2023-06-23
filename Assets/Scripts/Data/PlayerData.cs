using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // ��ü ������ ����
    // ���� üũ
    public int keyCount; // ������ ����, �� 3�� �ʿ�
    public int bathRoom_itemCount; // ��� ��������
    public int innerRoom_itemCount; // �ȹ� ��������
    public int kitchenRoom_itemCount; // ���
    public int startRoom_itemCount;
    // Start is called before the first frame update
    void Start()
    {       
        // ���� ���۽� ������ �� �ʱ�ȭ(���� �Ŀ� �����Ȳ �������� �ʿ��ϸ� ���־����)
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
    // Save data to global control (�κ��丮 ������ ����)
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
    public void addKeyCount() // ���� ����
    {
        keyCount++;
    }
    public void addBrItemCount() // ��� �������� ����
    {
        bathRoom_itemCount++;
    }
    public void addIrItemCount() // �ȹ� �������� ����
    {
        innerRoom_itemCount++;
    }
    public void addKrItemCount() // �ֹ� ��� ����
    {
        kitchenRoom_itemCount++;
    }
    public void addSrItemCount() // �ֹ� ��� ����
    {
        startRoom_itemCount++;
    }
}
