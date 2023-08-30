using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    [SerializeField] private float _changeVolumeSpeed;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public IEnumerator StartSignal()
    {
        while (_audioSource.volume < 1)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1, _changeVolumeSpeed * Time.deltaTime);
        
            yield return new WaitForEndOfFrame();
        }

        StopCoroutine(StartSignal());
    }

    public IEnumerator EndSignal()
    {
        while (_audioSource.volume > 0)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0, _changeVolumeSpeed * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }

        StopCoroutine(EndSignal());
    }
}
