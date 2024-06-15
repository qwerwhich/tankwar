using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys2 : MonoBehaviour
{
    private Vector3 bullectEulerAngles;
    private float v;
    private float h;
    public float speed = 4;

    private float Timecd;//攻击时间
    private float turnTimeVal = 4;//方向改变时间

    private SpriteRenderer sr;
    public Sprite[] tankSprite;//up right down left
    public GameObject bullectPrefab;
    public GameObject explosionPrefab;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //攻击cd
        if (Timecd >= 1.5f)
        {
            Attack();
        }
        else
        {
            Timecd += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    //tank的攻击方法
    private void Attack()
    {
        Instantiate(bullectPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bullectEulerAngles));
        Timecd = 0;
    }

    //tank的死亡方法
    private void Die()
    {
        //产生爆炸特效
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        //死亡
        Destroy(gameObject);
        PlayerMananger2.Instance.playerscore++;
    }

    //tank的移动方法
    private void Move()
    {
        if (turnTimeVal >= 4)
        {
            int num = Random.Range(0, 8);
            if (num > 5) //down
            {
                v = -1;
                h = 0;
            }
            else if (num == 0)//up
            {
                v = 1;
                h = 0;
            }
            else if (num > 0 && num <= 2)//left
            {
                v = 0;
                h = -1;
            }
            else if (num > 2 && num <= 4)//right
            {
                v = 0;
                h = 1;
            }
            turnTimeVal = 0;
        }
        else
        {
            turnTimeVal += Time.fixedDeltaTime;
        }
        transform.Translate(Vector3.right * h * speed * Time.fixedDeltaTime, Space.World);

        if (h < 0)
        {
            sr.sprite = tankSprite[3];
            bullectEulerAngles = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            sr.sprite = tankSprite[1];
            bullectEulerAngles = new Vector3(0, 0, -90);
        }

        if (h != 0)
        {
            return;
        }

        transform.Translate(Vector3.up * v * speed * Time.fixedDeltaTime, Space.World);

        if (v < 0)
        {
            sr.sprite = tankSprite[2];
            bullectEulerAngles = new Vector3(0, 0, -180);
        }
        else if (v > 0)
        {
            sr.sprite = tankSprite[0];
            bullectEulerAngles = new Vector3(0, 0, 0);
        }

        if (v != 0)
        {
            return;
        }

    }

    //tank碰撞
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            turnTimeVal = 4;
        }
        else if (collision.gameObject.tag == "Barrier")
        {
            turnTimeVal = 4;
        }
    }
}
