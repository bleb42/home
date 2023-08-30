using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private float _changingVolumeSpeed;

    private AudioSource _audioSource;
    private bool _isThiefInside = false;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    private void Update()
    {
        if (_isThiefInside == true)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1, 1 / _changingVolumeSpeed * Time.deltaTime);
        }
        else
        {
            _audioSource.volume =
                Mathf.MoveTowards(_audioSource.volume, 0, 1 / _changingVolumeSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ThiefController>())
        {
            _audioSource.enabled = true;
            _isThiefInside = true;
            _audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ThiefController>())
        {
            _isThiefInside = false;
        }
    }
}
