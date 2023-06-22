using UnityEngine;

public class Solo_Talk : MonoBehaviour
{
    public int is_first = 0;
    public GameObject obj;
    public GameObject obj2;
    public int obj_count = 0;

    public static Solo_Talk instance;
    private void Awake()
    {
        if (Solo_Talk.instance == null)
        {
            Solo_Talk.instance = this;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (is_first == 0)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("»•¿„∏ª Ω««‡");
                PlayerActor.instance.PressEKey();
            }
        }
   
    }

    public void DestoyThis()
    {
        if (obj_count == 0)
        {
            obj.SetActive(false);
            obj_count++;
        }
        else
        {
            obj2.SetActive(false);
        }
    }
}
