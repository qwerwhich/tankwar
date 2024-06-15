using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{
    private Vector3 bullectEulerAngles;
    private float Timecd;//攻击时间
    public float hlock;//水平速度
    public float vlock;//垂直速度
    private bool isDefended=true;// 无敌保护属性
    private float DefendTimeVal=3;//无敌时间

    private SpriteRenderer sr;
    public Sprite[] tankSprite;//up right down left
    public GameObject bullectPrefab;
    public GameObject explosionPrefab;
    public GameObject defendeffectPrefab;


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
        //保护是否存在
        if(isDefended)
        {
            defendeffectPrefab.SetActive(true);
            DefendTimeVal -= Time.deltaTime;
            if(DefendTimeVal <= 0)
            {
                isDefended = false;
                defendeffectPrefab.SetActive(false);
            }
        }
        //攻击cd
        if (Timecd > 0.4f)
        {
            Attack();
        }
        else
        {
            Timecd += Time.deltaTime;
        }
    
    }

    private  void FixedUpdate()
    {
        if (PlayerMananger.Instance.gg)
        {
            PlayerMananger.Instance.lifevalue = 0;
        }
        Move();
    }
    //tank的攻击方法
    private void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullectPrefab, transform.position,Quaternion.Euler(transform.eulerAngles+ bullectEulerAngles));
            Timecd = 0;
        }
    }
    //tank的移动方法
    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal1");
        if (h < 0)//left
        {
            sr.sprite = tankSprite[3];
            bullectEulerAngles = new Vector3(0, 0, 90);
        }
        else if (h > 0)//right
        {
            sr.sprite = tankSprite[1];
            bullectEulerAngles = new Vector3(0, 0, -90);
        }
        float v = Input.GetAxisRaw("Vertical1");
        if (v < 0)//down
        {
            sr.sprite = tankSprite[2];
            bullectEulerAngles = new Vector3(0, 0, -180);
        }
        else if (v > 0)//up
        {
            sr.sprite = tankSprite[0];
            bullectEulerAngles = new Vector3(0, 0, 0);
        }

        if (h == 0 && v == 0)//AKF的情况
        {
            vlock = 0;
            hlock = 0;
        }

        if (h != 0 && v == 0)//横向单键
        {
            hlock = 4;
            vlock = 1;
        }
        else if (h == 0 && v != 0)//竖向单键
        {
            hlock = 1;
            vlock = 4;
        }
        else if (h != 0 && v != 0)//双键
        {
            if (vlock * hlock == 0)//这个可以防止AFK后快速双键齐按导致斜走
            {
                //Debug.Log("Surprise mother fucker");
                return;
            }
            else if (hlock > vlock)
                h = 0;
            else if (hlock < vlock)
                v = 0;
        }
        transform.Translate(Vector3.right * h * hlock * Time.fixedDeltaTime, Space.World);
        transform.Translate(Vector3.up * v * vlock * Time.fixedDeltaTime, Space.World);
    }
    //tank的死亡方法
    private void Die()
    {
        if(isDefended)
        {
            return;
        }
        PlayerMananger.Instance.isdied=true;
        //产生爆炸特效
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        //死亡
        Destroy(gameObject);
    }

}
