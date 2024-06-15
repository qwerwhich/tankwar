using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class born : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject[] enemyPrefablist;
    public bool creattank;
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
        if(creattank) 
        {
        Instantiate(PlayerPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            int num = Random.Range(0, 4);
            Instantiate(enemyPrefablist[num], transform.position, Quaternion.identity);
        }
    }
}
