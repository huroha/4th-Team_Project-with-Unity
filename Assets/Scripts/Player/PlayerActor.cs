using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : MonoBehaviour
{


    Rigidbody2D rigid;

    float h;
    float v;

    public float speed = 3.8f;
    bool isHorizontal;

    Animator anim;
    //  ��ȭ ui
    public Game_Manager manager;


    // �⺻���� ������
    // Slide
    bool isSlide = false;
    Vector2 sliding;
    Vector2 dir;
    public float slidingSpeed = 300f;
    // Scan
    Vector3 dirVec;
    GameObject scanObject;
    // For get items
    // Inventory
    public GameObject inven;
    public Inventory myInv;

    // Cook
    public GameObject myCook;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // ������Ʈ ��� ����
    public bool isUsed = false;

    // Update is called once per frame
    void Update()
    {
        // Move Value
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        // Check Button Down & Up
        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical");

        // Check Horizontal Move
        if (hDown)
            isHorizontal = true;
        else if (vDown)
            isHorizontal = false;
        else if (hUp || vUp)
            isHorizontal = h != 0;

        //Animation
        if(anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if(anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
            anim.SetBool("isChange", false);

        //Direction(For Scan)
        if (vDown && v == 1) // ����
            dirVec = Vector3.up;
        else if (vDown && v == -1) // �Ʒ���
            dirVec = Vector3.down;
        else if (hDown && h == 1) // ������
            dirVec = Vector3.right;
        else if (hDown && h == -1) // ����
            dirVec = Vector3.left;

        //Scan Object
        if (Input.GetKeyDown(KeyCode.E) && scanObject != null)
        {
            manager.Action(scanObject);

            if(scanObject.layer == 3) // ������Ʈ �� ��
            {
                myInv.setInventory(scanObject.tag); // � ��ü���� ������ �Ѱܼ� �� ������ ������ ������Ű�� ���� �Ű�����
                scanObject.GetComponent<ObjData>().setIsUsed();
                Debug.Log("set Inven");
                // key++; key ���� ��������� �׷��� ���߿� ���� �� �� ������ �Ǵ�
            }
            if(scanObject.CompareTag("cook")) // �ֹ� ���� ������ ������ ��
            {
                inven.SetActive(false);
                myCook.SetActive(true);
            }
        }
    }

    private void FixedUpdate()
    {
        // Move
        
        Vector2 moveVec = isHorizontal ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;

        //Slide(�����̵� �� ������ ����)

        if(isSlide)
        {
            speed = 0f;
            InvokeRepeating("OnSliding", 0f, 0.5f);
        }
        else
        {
            speed = 3.8f;
        }

        //Ray(For Scan)
        Debug.DrawRay(rigid.position,dirVec * 0.7f,new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SlidingTile")
        {
            isSlide = true;
            dir = isHorizontal ? new Vector2(collision.transform.position.x - rigid.transform.position.x, 0)
                : new Vector2(0, (collision.transform.position.y - rigid.transform.position.y));
            // �÷��̾ �ٶ󺸴� �������� ���Ͱ� ������
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isSlide)
        {
            isSlide = false;
            StopSliding();
        }
    }

    void OnSliding()
    {
        sliding = dir * slidingSpeed;
        rigid.AddForce(sliding);
    }
    void StopSliding()
    {
        CancelInvoke("OnSliding");
    }

    public GameObject getScanOb()
    {
        return scanObject;
    }
}
