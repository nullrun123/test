using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public Transform SpawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 10f;

    public List<TextMeshProUGUI> waveCountdownTexts;

    private int waveIndex = 0;

    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        foreach (TextMeshProUGUI text in waveCountdownTexts)
        {
            text.text = countdown.ToString("00.00");
        }
    }

    IEnumerator SpawnWave()
    {
        PlayerState.Rounds++;

        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
        
            GameObject randomEnemy = wave.GetRandomEnemy();
            SpawnEnemy(randomEnemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;

        if (waveIndex == waves.Length)
        {
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, SpawnPoint.position, SpawnPoint.rotation);
        EnemiesAlive++;
    }
}
