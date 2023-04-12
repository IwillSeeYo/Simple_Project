using System;
using System.Collections;
using UnityEngine;

public class SpawnDelay : MonoBehaviour, IDelaySpawn
{
    public event Action Spawn;

    private Coroutine _delayCoroutine;

    public void StartDelay(float minDelay, float maxDelay)
    {
        if (_delayCoroutine != null)
        {
            StopDelay();
        }

        _delayCoroutine = StartCoroutine(DelayCoroutine(minDelay, maxDelay));
    }

    public void StopDelay()
    {
        if (_delayCoroutine != null)
        {
            StopCoroutine(_delayCoroutine);
            _delayCoroutine = null;
        }
    }

    private IEnumerator DelayCoroutine(float minDelay, float maxDelay)
    {
        var delay = new WaitForSeconds(UnityEngine.Random.Range(minDelay, maxDelay));

        while (true) 
        {
            yield return delay;

            Spawn?.Invoke();
        }
    }
}