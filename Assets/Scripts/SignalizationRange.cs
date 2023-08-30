using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalizationRange : MonoBehaviour
{
    [SerializeField] private Signalization _signalization;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out Thief thief))
        {
            StartCoroutine(_signalization.SetSignalVolume(1));
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out Thief thief))
        {
            StartCoroutine(_signalization.SetSignalVolume(0));
        }
    }
}
