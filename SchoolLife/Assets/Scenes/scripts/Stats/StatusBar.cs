using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class StatusBar : MonoBehaviour
{
    public FloatValue playerHealth;
    public FloatValue playerEnergy;
    public FloatValue playerHappiness;
    public FloatValue playerKnowledge;
    public FloatValue playerMoney;

    public TMP_Text HealthText;
    public TMP_Text KnowledgeLevelText;
    public TMP_Text HappinessText;
    public TMP_Text EnergyText;
    public TMP_Text MoneyText;

    public Image Health;
    public Image KnowledgeLevel;
    public Image Happiness;
    public Image Energy;

    private int maxHealth;
    private int maxKnowledgeLevel;
    private int maxHappiness;
    private int maxEnergy;

    void Start()
    {
        maxHealth = 100;
        maxHappiness = 100;
        maxEnergy = 100;
        maxKnowledgeLevel = 100;
    }

    void Update()
    {
        Health.fillAmount = playerHealth.initialValue / maxHealth;
        HealthText.text = playerHealth.initialValue + " \nHealth";

        Energy.fillAmount = playerEnergy.initialValue / maxEnergy;
        EnergyText.text = playerEnergy.initialValue + " \nEnergy";

        Happiness.fillAmount = playerHappiness.initialValue / maxHappiness;
        HappinessText.text = playerHappiness.initialValue + " \nHappiness";

        KnowledgeLevel.fillAmount = playerKnowledge.initialValue / maxKnowledgeLevel;
        KnowledgeLevelText.text = playerKnowledge.initialValue + " \nKnowledge Level";

        MoneyText.text = playerMoney.initialValue + " \nMoney";
    }
}
