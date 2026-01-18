using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace View
{
    public class HUD : MonoBehaviour {
        public TextMeshProUGUI HealthText;
        public TextMeshProUGUI ScoreText;
        public GameObject GameOverPanel;
        public Button RestartButton;

        private void Start() {
            RestartButton.onClick.AddListener(RestartGame);
            GameOverPanel.SetActive(false);
        }

        private void RestartGame() {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}