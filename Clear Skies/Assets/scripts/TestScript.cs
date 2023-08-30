using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private float TimeToKill = 3f;
    private void Start()
    {
        StartCoroutine(KillObject());
    }

    private IEnumerator KillObject()
    {
        yield return new WaitForSecondsRealtime(TimeToKill);
        Destroy(gameObject);
    }
}
