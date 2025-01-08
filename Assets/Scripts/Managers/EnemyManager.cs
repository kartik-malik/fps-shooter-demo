using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    [SerializeField] TMP_Text robotsCount;
    [SerializeField] TMP_Text gatesCount;

    const string ROBOT = "ROBOT";
    const string GATE = "GATE";

    [SerializeField]
    Dictionary<string, int> enemiesCount;

    [SerializeField] GameManager gameManager;
    private void Awake()
    {
        enemiesCount = new Dictionary<string, int>
        {
        };
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeEnemyCount(int value, EnemySO enemySO)
    {

        Debug.Log($"{enemySO.enemyName} {value}");
        if (enemiesCount.ContainsKey(enemySO.enemyName))
        {
            enemiesCount[enemySO.enemyName] = enemiesCount[enemySO.enemyName] + value;
        }
        else
        {
            enemiesCount.Add(enemySO.enemyName, value);

        }

        UpdateTextContent();
        CheckPlayerWinCondition();
    }

    void UpdateTextContent()
    {
        if (enemiesCount.ContainsKey(ROBOT))
        {
            robotsCount.text = $"Robots - {enemiesCount[ROBOT]}";
        }

        if (enemiesCount.ContainsKey(GATE))
        {
            gatesCount.text = $"Gates - {enemiesCount[GATE]}";

        }
    }
    void CheckPlayerWinCondition()
    {
        if (enemiesCount.ContainsKey(GATE) && enemiesCount[GATE] == 0)
        {
            gameManager.PlayerWon();
        }
    }
}
