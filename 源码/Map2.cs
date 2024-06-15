using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map2 : MonoBehaviour
{
    public float wallnum = 60;
    public float barriernum = 30;
    public float rivernum = 20;
    public float grassnum = 20;
    public GameObject[] item;//װ�ε�ͼ��ʼ��������Ҫ������
    //0 herat
    //1 wall
    //2 barrier
    //3 born
    //4 river
    //5 grass
    //6 airwall

    private List<Vector3> itemPositionList = new List<Vector3>();   //���ж����б�

    private void Awake()//ʵ������ͼ
    {
        Iintmap();
    }

    private void Iintmap()//��ͼ�������ɺ���
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

        //��������
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

    private void CreatItem(GameObject createGameObject, Vector3 createPosition, Quaternion createRotation)//��װ�ڸ�����
    {
        GameObject itemGo = Instantiate(createGameObject, createPosition, createRotation);
        itemGo.transform.SetParent(gameObject.transform);
        itemPositionList.Add(createPosition);
    }

    private Vector3 CreatRandomPosition()//���������Ʒλ�÷���
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

    private bool haveposition(Vector3 createPos)//�жϵ�ǰλ���Ƿ������Ʒ
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

    private void CreatEnemy()//��������
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
