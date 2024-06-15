using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{
    private Vector3 bullectEulerAngles;
    private float Timecd;//����ʱ��
    public float hlock;//ˮƽ�ٶ�
    public float vlock;//��ֱ�ٶ�
    private bool isDefended=true;// �޵б�������
    private float DefendTimeVal=3;//�޵�ʱ��

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
        //�����Ƿ����
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
        //����cd
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
    //tank�Ĺ�������
    private void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullectPrefab, transform.position,Quaternion.Euler(transform.eulerAngles+ bullectEulerAngles));
            Timecd = 0;
        }
    }
    //tank���ƶ�����
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

        if (h == 0 && v == 0)//AKF�����
        {
            vlock = 0;
            hlock = 0;
        }

        if (h != 0 && v == 0)//���򵥼�
        {
            hlock = 4;
            vlock = 1;
        }
        else if (h == 0 && v != 0)//���򵥼�
        {
            hlock = 1;
            vlock = 4;
        }
        else if (h != 0 && v != 0)//˫��
        {
            if (vlock * hlock == 0)//������Է�ֹAFK�����˫���밴����б��
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
    //tank����������
    private void Die()
    {
        if(isDefended)
        {
            return;
        }
        PlayerMananger.Instance.isdied=true;
        //������ը��Ч
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        //����
        Destroy(gameObject);
    }

}
