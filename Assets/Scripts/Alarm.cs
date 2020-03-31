using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private AudioSource _alarmSound;

    private void Start()
    {
        _alarmSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StopCoroutine("FadeOutSound");
        StartCoroutine("RiseSound");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine("RiseSound");
        StartCoroutine("FadeOutSound");
    }

    private IEnumerator RiseSound()
    {
        _alarmSound.Play();
        while (_alarmSound.volume < 1)
        {
            _alarmSound.volume += 0.003f;
            yield return null;
        }
    }

    private IEnumerator FadeOutSound()
    {
        while (_alarmSound.volume > 0)
        {
            _alarmSound.volume -= 0.003f;
            yield return null;
        }
        _alarmSound.Stop();

    }
}
