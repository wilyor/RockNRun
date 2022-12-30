using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class EnemyHordeCreator : MonoBehaviour
{
    public string horde;
    public char separationChar = '-';
    public bool creating = false;
    Coroutine monsterGenerationcoroutine;
    EnemyGenerator enemyGenerator;
    SongListReader songlistReader;

    private void Start()
    {
        enemyGenerator = GetComponent<EnemyGenerator>();
        songlistReader = GetComponent<SongListReader>();
    }

    void Selectsong()
    {
        horde = songlistReader.SelectSong(0).notesEasy;
    }
    IEnumerator GenerateMonsters()
    {
        (string enemyName, float timeToBorn) nextEncounter = RetrieveNextEnemy();
        yield return new WaitForSeconds(nextEncounter.timeToBorn);
        if (nextEncounter.enemyName != null) {
            if (enemyGenerator) enemyGenerator.SelectEnemy(nextEncounter.enemyName);
            monsterGenerationcoroutine = StartCoroutine(GenerateMonsters());
        }
        else
        {
            StopCreation();
        }
    }

    public (string, float) RetrieveNextEnemy()
    {
        if(horde.Length > 0)
        {
            string nextEnemy = RetrieveEnemy();
            float nextTime = RetrieveTime();
            return (nextEnemy, nextTime);
        }
        return (null, 0);
    }

    string RetrieveEnemy()
    {
        string nextEnemy = horde.Substring(0, horde.IndexOf(separationChar));
        horde = horde.Substring(horde.IndexOf(separationChar) + 1);
        return nextEnemy;
    }

    float RetrieveTime()
    {
        string nextTimeStr = horde.Contains(separationChar) ? horde.Substring(0, horde.IndexOf(separationChar)) : horde;
        float nextTime = float.Parse(nextTimeStr);
        horde = horde.Contains(separationChar) ? horde.Substring(horde.IndexOf(separationChar) + 1) :  "";
        return nextTime;
    }

    [ContextMenu("StopCreation")]
    public void StopCreation()
    {
        if (creating)
        {
            StopCoroutine(monsterGenerationcoroutine);
            creating = false;
        }
    }

    [ContextMenu("StartCreation")]
    public void StartMonsterCreation()
    {
        if (!creating)
        {
            Selectsong();
            creating = true;
            monsterGenerationcoroutine = StartCoroutine(GenerateMonsters());
        }
    }

}
