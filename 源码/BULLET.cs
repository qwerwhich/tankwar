using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BULLET_01 : MonoBehaviour
{
    public float movespeed = 10;
    public bool isPlayerBullect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * movespeed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.tag)
        {
            case "Tank":
                if(!isPlayerBullect)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);//kill bullet
                }
                break;
            case "Heart":
                collision.SendMessage("Died");
                Destroy(gameObject);//kill bullet

                break;
            case "Enemy":
                if (isPlayerBullect)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);//kill bullet
                }
                break;
            case "Wall":
                Destroy(collision.gameObject);//kill wall
                Destroy(gameObject);//kill bullet
                break;
            case "Barrier":
                collision.SendMessage("PlayAudio");
                Destroy(gameObject);//kill bullet

                break;
            default:
                break;
        }
    }
}
