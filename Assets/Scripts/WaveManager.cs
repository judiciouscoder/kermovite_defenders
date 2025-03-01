﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : Singleton<WaveManager>
{
    [SerializeField]
    private Wave[] waves;
    private Wave currentWave;
    private int nextWaveN;
    private float multiplier;

    private void Awake()
    {
        nextWaveN = 0;
        multiplier = 0f;

        NextWave();
    }

    public Wave GetCurrentWave()
    {
        return this.currentWave;
    }
    public float GetMultiplier()
    {
        return this.multiplier;
    }

    public void NextWave()
    {
        if (waves.Length > nextWaveN)
        {
            SetNextHealth();
            currentWave = waves[nextWaveN];
            multiplier += currentWave.multiplier;
            nextWaveN++;
            GameManager.Instance.SetInfoNextWave();
        }
        else
        {
            GameManager.Instance.Victory();
        }
    }

    public int GetWaveN()
    {
        return nextWaveN;
    }

    public bool IsLast()
    {
        return waves.Length <= nextWaveN;
    }

    private void SetNextHealth()
    {
        if (waves.Length > nextWaveN)
        {
            Creep nextCreep = waves[nextWaveN].enemy.GetComponent<Creep>();
            nextCreep.SetHealth(multiplier, nextWaveN);
        }

    }
    public bool IsBoss()
    {
        return currentWave.isBoss;
    }

}
