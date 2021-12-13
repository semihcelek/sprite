using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    // Start is called before the first frame update
    private void Awake()
    {

        healthText.text = "0";
        PlayerHealth.onUpdateHealthGui += UpdateHealthGui;
    }

    private void UpdateHealthGui(int score)
    {
        healthText.text = score.ToString();
    }
}
