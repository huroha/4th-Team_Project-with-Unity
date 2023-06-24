using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Chase : MonoBehaviour
{
    
    public GameObject player;
    public float speed;
    public GameObject spirit;
    public Transform spiritPos;
    private float distance;
    SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        soundManager.setSource("chase");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);   // 플레이어 따라감
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);     // 앞을 보면서
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("플레이어 충돌 확인");
            Instantiate(spirit, spiritPos.transform.position, spiritPos.transform.rotation);
            Destroy(spirit);
        }
    }

}
