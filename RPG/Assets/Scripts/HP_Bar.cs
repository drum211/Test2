using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Bar : MonoBehaviour
{
    public Sprite[] Frame;
    private SpriteRenderer spr;
    public Player plr;
    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        spr.sprite = Frame[plr.HP];
    }
}
