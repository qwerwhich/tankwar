using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class born2 : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject PlayerPrefab2;
    public GameObject[] enemyPrefablist;
    public bool creattank;
    public bool creattank2;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("BornTank", 0.8f);
        Destroy(gameObject, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void BornTank()
    {
        if (creattank)
        {
            Instantiate(PlayerPrefab, transform.position, Quaternion.identity);
        }
        else if (creattank2)
        {
            Instantiate(PlayerPrefab2, transform.position, Quaternion.identity);
        }
        else
        {
            int num = Random.Range(0, 4);
            Instantiate(enemyPrefablist[num], transform.position, Quaternion.identity);
        }
    }
}
