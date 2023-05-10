using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GlobalDataControl : MonoBehaviour
{
    public static GlobalDataControl Instance;

    // ��ü ������ ����
    // ���� üũ
    public int keyCount = 0; // ������ ����, �� 3�� �ʿ�
    public int bathRoom_itemCount = 0; // ��� ��������
    public int innerRoom_itemCount = 0; // �ȹ� ��������
    public int kitchenRoom_itemCount = 0; // ���
    // ������ �ߺ� üũ
    public bool isGetKey = false;
    public bool isGetBathRoomItem = false;
    public bool isGetInnerRoomItem = false;
    public bool isGetKitchenItem = false;
    // UI ����
    public bool[] invActive = new bool[4];
    public Sprite[] invImage = new Sprite[4];
    public string[] invText = new string[4];

    void Awake()
    {
        // ���� ���۽� ������ �� �ʱ�ȭ(���� �Ŀ� �����Ȳ �������� �ʿ��ϸ� ���־����)

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
