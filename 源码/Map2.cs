using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map2 : MonoBehaviour
{
    public float wallnum = 60;
    public float barriernum = 30;
    public float rivernum = 20;
    public float grassnum = 20;
    public GameObject[] item;//装饰地图初始化所以需要的数组
    //0 herat
    //1 wall
    //2 barrier
    //3 born
    //4 river
    //5 grass
    //6 airwall

    private List<Vector3> itemPositionList = new List<Vector3>();   //已有东西列表

    private void Awake()//实例化地图
    {
        Iintmap();
    }

    private void Iintmap()//地图调用生成函数
    {
        CreatItem(item[0], new Vector3(0, -8, 0), Quaternion.identity);//heart
        CreatItem(item[1], new Vector3(-1, -8, 0), Quaternion.identity);
        CreatItem(item[1], new Vector3(1, -8, 0), Quaternion.identity);
        CreatItem(item[1], new Vector3(-1, -7, 0), Quaternion.identity);
        CreatItem(item[1], new Vector3(0, -7, 0), Quaternion.identity);
        CreatItem(item[1], new Vector3(1, -7, 0), Quaternion.identity);//wall round heart

        for (int i = -11; i <= 11; i++)
        {
            CreatItem(item[6], new Vector3(i, 9, 0), Quaternion.identity);
            CreatItem(item[6], new Vector3(i, -9, 0), Quaternion.identity);
        }
        for (int i = -8; i <= 8; i++)
        {
            CreatItem(item[6], new Vector3(11, i, 0), Quaternion.identity);
            CreatItem(item[6], new Vector3(-11, i, 0), Quaternion.identity);
        }//create airwall

        //create player1
        GameObject go = Instantiate(item[3], new Vector3(-2, -8, 0), Quaternion.identity);
        go.GetComponent<born2>().creattank = true;

        //create player2
        GameObject go2 = Instantiate(item[3], new Vector3(2, -8, 0), Quaternion.identity);
        go2.GetComponent<born2>().creattank2 = true;

        //产生敌人
        CreatItem(item[3], new Vector3(-10, 8, 0), Quaternion.identity);
        CreatItem(item[3], new Vector3(0, 8, 0), Quaternion.identity);
        CreatItem(item[3], new Vector3(10, 8, 0), Quaternion.identity);

        InvokeRepeating("CreatEnemy", 10, 10);

        //create anything
        for (int i = 0; i < wallnum; i++)
        {
            CreatItem(item[1], CreatRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < barriernum; i++)
        {
            CreatItem(item[2], CreatRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < rivernum; i++)
        {
            CreatItem(item[4], CreatRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < grassnum; i++)
        {
            CreatItem(item[5], CreatRandomPosition(), Quaternion.identity);
        }
    }

    private void CreatItem(GameObject createGameObject, Vector3 createPosition, Quaternion createRotation)//封装在父类里
    {
        GameObject itemGo = Instantiate(createGameObject, createPosition, createRotation);
        itemGo.transform.SetParent(gameObject.transform);
        itemPositionList.Add(createPosition);
    }

    private Vector3 CreatRandomPosition()//产生随机物品位置方法
    {
        while (true)
        {
            Vector3 createPosition = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8), 0);
            if (!haveposition(createPosition))
            {
                return createPosition;
            }
        }
    }

    private bool haveposition(Vector3 createPos)//判断当前位置是否存在物品
    {
        for (int i = 0; i < itemPositionList.Count; i++)
        {
            if (createPos == itemPositionList[i])
            {
                return true;
            }
        }
        return false;
    }

    private void CreatEnemy()//产生敌人
    {
        int num = Random.Range(0, 3);
        Vector3 Enemypos = new Vector3();
        if (num == 0)
        {
            Enemypos = new Vector3(-10, 8, 0);
        }
        else if (num == 1)
        {
            Enemypos = new Vector3(0, 8, 0);
        }
        else
        {
            Enemypos = new Vector3(10, 8, 0);
        }
        CreatItem(item[3], Enemypos, Quaternion.identity);
    }
}
