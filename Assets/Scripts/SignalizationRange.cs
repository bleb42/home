using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalizationRange : MonoBehaviour
{
    [SerializeField] private Signalization _signalization;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ThiefController>(out ThiefController thief))
        {
            StartCoroutine(_signalization.StartSignal());
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<ThiefController>(out ThiefController thief))
        {
            StartCoroutine(_signalization.EndSignal());
        }
    }
}
