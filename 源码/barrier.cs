using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{
    public AudioClip Hit;//“Ù–ß

    private void PlayAudio()
    {
        AudioSource.PlayClipAtPoint(Hit, transform.position);
    }

}
