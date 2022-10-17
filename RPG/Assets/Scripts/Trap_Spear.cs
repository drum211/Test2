using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Spear : MonoBehaviour
{
    private Animator anim;
    public AnimationClip clip;
    public BoxCollider2D cld;
    public float maxTime;
    public float curTime=0;
    public int frame;

    void Start()
    {
        anim = GetComponent<Animator>();
        maxTime = maxTime + clip.length;
        
    }
    void Update()
    {
        float frameTime = clip.length / clip.frameRate * frame;
        if (curTime < maxTime)
        {
            curTime = curTime + Time.deltaTime;
        }
        else
        {
            curTime = 0;
        }
        if (curTime > 3 )
        {
            if (curTime > 3.6 && curTime < 3.8)
            {
                cld.enabled = true;
            }
            else
            {
                cld.enabled = false;
            }
            anim.SetBool("Active", true);
        }
        else
        {
            anim.SetBool("Active", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Player player = coll.gameObject.GetComponent<Player>();
            player.HP = player.HP - 1;
        }
    }
}
