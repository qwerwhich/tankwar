using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{
    public AudioClip Hit;//��Ч

    private void PlayAudio()
    {
        AudioSource.PlayClipAtPoint(Hit, transform.position);
    }

}
