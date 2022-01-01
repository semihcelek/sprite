using SemihCelek.Sprinter.Player;
using TMPro;
using UnityEngine;

namespace SemihCelek.Sprinter.UserInterfaces
{
    public class DisplayPlayerHealthController : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _healthText;

        private void Awake()
        {
            _healthText.text = "0";
            PlayerHealthController.OnUpdateHealthGui += UiHealthUpdater;
        }

        private void OnDestroy()
        {
            PlayerHealthController.OnUpdateHealthGui -= UiHealthUpdater;
        }

        private void UiHealthUpdater(int score)
        {
            _healthText.text = score.ToString();
        }
    }
}