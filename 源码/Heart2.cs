using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart2 : MonoBehaviour
{
    private SpriteRenderer sr;
    public GameObject explosionPrefab;
    //
    public AudioClip Die;//“Ù–ß
    //
    public Sprite BrokenSprite;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Died()//heart die
    {
        sr.sprite = BrokenSprite;
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        PlayerMananger2.Instance.gg = true;
        AudioSource.PlayClipAtPoint(Die, transform.position);
    }
}
