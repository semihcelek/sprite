using SemihCelek.Sprinter.Player;
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
            PlayerHealthController.OnUpdateHealthGui += UiHealthUpdater;
        }

        private void OnDestroy()
        {
            PlayerHealthController.OnUpdateHealthGui -= UiHealthUpdater;
        }

        private void UiHealthUpdater(int score)
        {
            healthText.text = score.ToString();
        }
    }
}