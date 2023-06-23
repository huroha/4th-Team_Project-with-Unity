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
    //  대화 ui
    public Game_Manager manager;

    public static PlayerActor instance;


    // 기본적인 변수들
    // Slide
    public bool isSlide = false;
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
    public GameObject myOven;
    private void Awake()
    {
        if(PlayerActor.instance == null)
        {
            PlayerActor.instance = this;
        }
    }
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // 오브젝트 사용 여부
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
        if (vDown && v == 1) // 위쪽
            dirVec = Vector3.up;
        else if (vDown && v == -1) // 아래쪽
            dirVec = Vector3.down;
        else if (hDown && h == 1) // 오른쪽
            dirVec = Vector3.right;
        else if (hDown && h == -1) // 위쪽
            dirVec = Vector3.left;

      

        //Scan Object
        if (Input.GetKeyDown(KeyCode.E) && scanObject != null)
        {
            //manager.Action(scanObject);
            PressEKey();
         

            if(scanObject.layer == 3) // 오브젝트 일 때
            {
                myInv.setInventory(scanObject.tag); // 어떤 물체인지 정보를 넘겨서 그 아이템 개수를 증가시키기 위한 매개변수
                //scanObject.GetComponent<ObjData>().setIsUsed();
                Debug.Log("set Inven");
                // key++; key 값을 높여줘야함 그래야 나중에 문을 열 때 개수로 판단

                
            }
            if (scanObject.CompareTag("cook") && GlobalDataControl.Instance.isCookOver == false) // 주방 에서 음식을 조리할 때 // 작동을 안하네 왜?
            {
                inven.SetActive(false);
                myCook.SetActive(true);
                speed = 0f;
            }
            else if (scanObject.CompareTag("Oven") && GlobalDataControl.Instance.isCookOver == true && GlobalDataControl.Instance.isOvenOver == false) // 이건 아예 멈춰버리네..
            {
                inven.SetActive(false);
                myOven.SetActive(true);
                speed = 0f;
            }
        }
        Debug.Log("name is : " + scanObject);
    }
    
    private void FixedUpdate()
    {
        // Move
        
        Vector2 moveVec = isHorizontal ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;

        //Slide(슬라이딩 시 움직임 제한)

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
    // 슬라이딩 관련 , (왼,아래) = 마이너스 , (오,위) = 플러스
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SlidingTile" && isFirstSliding == false)
        {
            isSlide = true;
            dir = isHorizontal ? new Vector2(collision.transform.position.x - rigid.transform.position.x, 0)
                : new Vector2(0, (collision.transform.position.y - rigid.transform.position.y));
            isFirstSliding = true;
            // 플레이어가 바라보는 방향으로 벡터가 정해짐 , 만약 플레이어가 key를 유지하지 않을 시 세로 움직임
        }
        
    }
    */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SlidingTile")
        {
            isSlide = true;
            /*
            dir = isHorizontal ? new Vector2(rigid.transform.position.x - collision.transform.position.x, 0)
                : new Vector2(0, (rigid.transform.position.y - collision.transform.position.y));
            */
            if (h < 0) // 좌
            {
                dir = Vector2.left;
            }
            else if(h > 0) // 우
            {
                dir = Vector2.right;

            }
            else if(v < 0) // 하
            {
                dir = Vector2.down;
            }
            else if(v > 0) // 상
            {
                dir = Vector2.up;
            }
            
            
            Debug.Log(dir);
            // 플레이어가 바라보는 방향으로 벡터가 정해짐 , 나가는 방향이니까 여기선 반대로
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

    public void PressEKey()
    {
        manager.Action(scanObject);
    }
}
