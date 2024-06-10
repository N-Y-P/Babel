using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleUIManager : MonoBehaviour
{
    public static BattleUIManager Instance { get; private set; }

    [Header("���� ���� UI Text ����")]
    public TMP_Text enemyText;
    public TMP_Text playerText_1;
    public TMP_Text playerText_2;
    public TMP_Text expText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DisplayEnemyDamage(float damage)
    {
        enemyText.text = $"-{damage:F1}";
    }

    public void DisplayPlayerDamage(float damage)
    {
        playerText_1.text = $"-{damage:F1}";
    }

    public void DisplayExperienceGained(int exp)
    {
        expText.text = $"+{exp} ����";
    }

    public void ClearCombatTexts()
    {
        enemyText.text = "";
        playerText_1.text = "";
        expText.text = "";
    }
}
