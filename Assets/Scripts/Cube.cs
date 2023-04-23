using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy;

    private void OnEnable()
    {
        StartCoroutine("LifeDelay");
    }

    private void OnDisable()
    {
        StopCoroutine("LifeDelay");
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
    
    private IEnumerator LifeDelay()
    {
        yield return new WaitForSecondsRealtime(_timeToDestroy);
        
        Deactivate();
    }
    
}
