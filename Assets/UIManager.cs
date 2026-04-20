using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject endGamePanel;
    public TextMeshProUGUI finalTimeText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameController.gameOver)
        {
            endGamePanel.SetActive(true);
            GameManager.Instance.jogoAtivo = false;
            
            float tempo = GameManager.Instance.GetTempo();
            int min = (int)(tempo / 60);
            int seg = (int)(tempo % 60);
            finalTimeText.text = string.Format("Tempo: {0:00}:{1:00}", min, seg);
        }
    }
}
