using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public string ID;
    public Player Player;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            switch(ID)
            {
                case "0001":                        // Маленькое зелье здоровья
                    if (Player.HP < Player.MaxHP)
                    {
                        Player.HP = Player.HP + 1;
                        Destroy(this.gameObject);
                    }
                    break;
                case "0002":                        // Среднее зелье здоровья
                    if (Player.HP < Player.MaxHP)
                    {
                        Player.HP = Player.HP + 2;
                        Destroy(this.gameObject);
                    }
                    break;
                default:
                    print("Item not found");
                    break;
            }
        }
    }
}
