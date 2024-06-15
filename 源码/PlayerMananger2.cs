using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMananger2 : MonoBehaviour
{
    //����
    public int lifevalue = 3;
    public int lifevalue2 = 3;

    public int playerscore = 0;

    public bool isdied;//paly1
    public bool isdied2;//play2
    public bool gg = false;

    //����
    public GameObject Born;
    public Text scoretest;
    public Text lifetest;
    public Text lifetest2;
    public GameObject ggUI;

    //����
    public static PlayerMananger2 instance;

    public static PlayerMananger2 Instance
    {
        get
        {
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gg)
        {
            ggUI.SetActive(true);
            Invoke("truntothemenu", 1);
            return;
        }
        if (isdied)
        {
            recover();
        }
        if (isdied2)
        {
            recover2();
        }
        scoretest.text = playerscore.ToString();
        lifetest.text = lifevalue.ToString();
        lifetest2.text = lifevalue2.ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void recover()
    {
        if (lifevalue <= 0)
        {
            gg = true;
            //gameover
            Invoke("truntothemenu", 1);
        }
        else
        {
            lifevalue--;
            GameObject go = Instantiate(Born, new Vector3(-2, -8, 0), Quaternion.identity);
            go.GetComponent<born2>().creattank = true;
            isdied = false;
        }
    }
    private void recover2()
    {
        if (lifevalue2 <= 0)
        {
            gg = true;
            //gameover
            Invoke("truntothemenu", 1);
        }
        else
        {
            lifevalue2--;
            GameObject go2 = Instantiate(Born, new Vector3(2, -8, 0), Quaternion.identity);
            go2.GetComponent<born2>().creattank2 = true;
            isdied2 = false;
        }
    }

    private void truntothemenu()
    {
        SceneManager.LoadScene(0);
    }
}
