using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathRoom_Duck : MonoBehaviour
{
    // Ű �Է¿� ���� ���� 4����
    public GameObject[] Ducks = new GameObject[4];
    public AudioClip[] DuckSounds = new AudioClip[4];
    AudioSource duckSource;

    // ���� ����
    [SerializeField]
    public AudioClip[] tracks = new AudioClip[3];
    AudioSource trackSource;
    int trackNumber = 0;
    // Ű �Է� ������ üũ�ϴ� �迭
    public char[] keyOrder = new char[4];
    public int indexCount = 0;
    // ȿ����
    public AudioClip effect;
    AudioSource effectSource;
    // �κ�
    Inventory myInv;
    bool isVailid;
    // Start is called before the first frame update
    void Start()
    {
        duckSource = GetComponent<AudioSource>();
        trackSource = GetComponent<AudioSource>();
        effectSource = GetComponent<AudioSource>();
        myInv = GameObject.Find("Inventory").GetComponent<Inventory>();
        // Ʈ�� �ѹ� ���ϱ�(���ǿ� �ѹ�)
        trackNumber = Random.Range(0, 3);
        isVailid = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            duckSource.clip = DuckSounds[0];
            duckSource.loop = false;
            duckSource.mute = false;
            duckSource.Play();
            if (indexCount < 4)
            {
                keyOrder[indexCount] = 'z';
                indexCount += 1;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            duckSource.clip = DuckSounds[1];
            duckSource.loop = false;
            duckSource.mute = false;
            duckSource.Play();
            if (indexCount < 4)
            {
                keyOrder[indexCount] = 'x';
                indexCount++;
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            duckSource.clip = DuckSounds[2];
            duckSource.loop = false;
            duckSource.mute = false;
            duckSource.Play();
            if (indexCount < 4)
            {
                keyOrder[indexCount] = 'c';
                indexCount++;
            }
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            duckSource.clip = DuckSounds[3];
            duckSource.loop = false;
            duckSource.mute = false;
            duckSource.Play();
            if (indexCount < 4)
            {
                keyOrder[indexCount] = 'v';
                indexCount++;
            }
        }
        if (isVailid == false 
            && keyOrder[0] != ' ' && keyOrder[1] != ' ' && keyOrder[2] != ' ' && keyOrder[3] != ' ')
        {
            orderCheck();
            initInputArray();
        }
    }
    public void selectTrack()
    {
        trackSource.clip = tracks[trackNumber];
        trackSource.loop = false;
        trackSource.mute = false;
        trackSource.Play();
    }
    
    void orderCheck()
    {
        if(trackNumber == 0)
        {
            if (keyOrder[0] == 'c' && keyOrder[1] == 'x' && keyOrder[2] == 'v' && keyOrder[3] == 'z')
            {
                Debug.Log("--------------------Correct Track Number 0 !!!------------------");
                myInv.setInventory("isDuck");
                isVailid = true;
            }
        }
        else if(trackNumber == 1)
        {
            if (keyOrder[0] == 'x' && keyOrder[1] == 'v' && keyOrder[2] == 'c' && keyOrder[3] == 'z')
            {
                Debug.Log("--------------------Correct Track Number 1 !!!------------------");
                myInv.setInventory("isDuck");
                isVailid = true;
            }
        }
        else if(trackNumber == 2)
        {
            if (keyOrder[0] == 'c' && keyOrder[1] == 'v' && keyOrder[2] == 'z' && keyOrder[3] == 'x')
            {
                Debug.Log("--------------------Correct Track Number 2 !!!------------------");
                myInv.setInventory("isDuck");
                isVailid = true;
            }
        }
    }

    void initInputArray()
    {
        // ���� �÷��̾ �Է��� ������ Ʋ���� ��� �ٽ� �迭�� �ʱ�ȭ �����ִ� ����
        if ((keyOrder[0] != ' ' && keyOrder[1] != ' ' && 
            keyOrder[2] != ' ' && keyOrder[3] != ' ') && isVailid == false)
        {
            for (int i = 0; i < 4; i++)
                keyOrder[i] = ' ';
            indexCount = 0;
        }
        effectSource.clip = effect;
        effectSource.loop = false;
        effectSource.mute = false;
        effectSource.Play();
    }
}
