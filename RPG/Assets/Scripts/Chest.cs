using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator anim;
    public float maxTime;
    public float curTime = 0;
    public float waitTime;
    private bool Opened = false;
    public GameObject[] items;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (curTime < maxTime)
        {
            curTime = curTime + Time.deltaTime;
        }
        else
        {
            curTime = 0;
        }
        if (curTime > waitTime && !Opened)
        {
            anim.SetInteger("State", 1);
        }
        else if (curTime < waitTime && !Opened)
        {
            anim.SetInteger("State", 0);
        }
        else if (Opened)
        {
            anim.SetInteger("State", 2);
        }
    }
    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player") && !Opened)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Opened = true;
                Instantiate(items[Random.Range(0, items.Length)], transform.position, transform.rotation);
            }
        }
    }
}
