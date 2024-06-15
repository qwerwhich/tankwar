using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMananger : MonoBehaviour
{ 
    //属性
    public int lifevalue = 3;
    public int playerscore = 0;
    public bool isdied;//paly1
    public bool gg=false;

    //引用
    public GameObject Born;
    public Text scoretest;
    public Text lifetest;
    public GameObject ggUI;

    //单例
    public static PlayerMananger instance;

    public static PlayerMananger Instance
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
        if(gg)
        {
            ggUI.SetActive(true);
            Invoke("truntothemenu", 1);
            return;
        }
        if(isdied)
        {
            recover();
        }
        scoretest.text = playerscore.ToString();
        lifetest.text = lifevalue.ToString();
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
            Invoke("truntothemenu",1);
        }
        else
        {
            lifevalue--;
            GameObject go = Instantiate(Born, new Vector3(-2, -8, 0), Quaternion.identity);
            go.GetComponent<born>().creattank = true;
            isdied = false;
        }
    }

    private void truntothemenu()
    {
        SceneManager.LoadScene(0);
    }
}
