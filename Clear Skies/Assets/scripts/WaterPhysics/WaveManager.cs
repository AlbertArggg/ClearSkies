using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WaveVector4
{
    public float WaveDirection;
    public float WaveLength;
    public float amplitude;
    public float Speed;
}

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    
    public float Speed = 0.1f;
    public Vector2 Offset = new Vector2(0f, 0f);

    public WaveVector4 waveAValues;
    public WaveVector4 waveBValues;
    public WaveVector4 waveCValues;
    
    private Vector4 waveA;
    private Vector4 waveB;
    private Vector4 waveC;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        
        else if (instance != this)
            Destroy(this);

        StartCoroutine(AdjustWaves());
    }

    IEnumerator AdjustWaves()
    {
        while (true)
        {
            waveA = new Vector4
            (
                waveAValues.WaveDirection,
                waveAValues.WaveLength,
                waveAValues.amplitude,
                waveAValues.Speed
            );
            waveB = new Vector4
            (
                waveBValues.WaveDirection,
                waveBValues.WaveLength,
                waveBValues.amplitude,
                waveBValues.Speed
            );
            waveC = new Vector4
            (
                waveCValues.WaveDirection,
                waveCValues.WaveLength,
                waveCValues.amplitude,
                waveCValues.Speed
            );
            yield return new WaitForSeconds(1);   
        }
    }

    private void Update()
    {
        Offset += Time.deltaTime * Speed * new Vector2(1.0f, 1.0f);
    }

    public float GetWaveHeight(float x, float z)
    {
        float offsetX = x + Offset.x;
        float offsetZ = z + Offset.y;

        Vector3 point = new Vector3(offsetX, 0, offsetZ);
        float height = 0;

        height += GerstnerWaveHeight(waveA, point);
        height += GerstnerWaveHeight(waveB, point);
        height += GerstnerWaveHeight(waveC, point);

        return height;
    }

    private float GerstnerWaveHeight(Vector4 waveParams, Vector3 point)
    {
        float k = 2 * Mathf.PI / waveParams.y;
        float c = waveParams.w;
        float a = waveParams.z;
        float dotProduct = waveParams.x * point.x + point.z;
        float phase = k * dotProduct - c * Time.time;

        float height = a * Mathf.Sin(phase);
        return height;
    }
}
