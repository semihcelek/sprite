using SemihCelek.Sprinter.Player.PlayerHealth;
using TMPro;
using UnityEngine;

namespace SemihCelek.Sprinter.UserInterfaces
{
    public class DisplayPlayerHealthController : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text healthText;

        private void Awake()
        {
            healthText.text = "0";
            PlayerHealth.OnUpdateHealthGui += UiHealthUpdater;
        }

        private void OnDestroy()
        {
            PlayerHealth.OnUpdateHealthGui -= UiHealthUpdater;
        }

        private void UiHealthUpdater(int score)
        {
            healthText.text = score.ToString();
        }
    }
}