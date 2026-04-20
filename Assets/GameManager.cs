using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;

    private float tempo = 0f;
    private int score = 0;
    public bool jogoAtivo = true;

	[Header("Vidas")]
	public GameObject vida1;
	public GameObject vida2;
	public GameObject vida3;
	private int vidas = 3;

	public Animator playerAnimator;
	
	[Header("Audio")]
	public AudioSource audioSource;
	public AudioClip hitSound;
	
	public GameObject hudPanel;
	
	public TextMeshProUGUI finalScoreText;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (!jogoAtivo) return;
        tempo += Time.deltaTime;
        int min = (int)(tempo / 60);
        int seg = (int)(tempo % 60);
        timerText.text = string.Format("{0:00}:{1:00}", min, seg);
    }

    public void AdicionarPonto()
    {
        score++;
        scoreText.text = "" + score;
    }

	public void RemoverPonto()
	{
    	score--;
    	if (score < 0) score = 0;
    	scoreText.text = "Score: " + score;
	}

	public void PerderVida()
	{
    	vidas--;
	    audioSource.PlayOneShot(hitSound);
		playerAnimator.Play("FishHit");

    	if (vidas == 2) vida3.SetActive(false);
    	else if (vidas == 1) vida2.SetActive(false);
    	else if (vidas <= 0)
    	{
        	vida1.SetActive(false);
        	jogoAtivo = false;
	        hudPanel.SetActive(false);
	        finalScoreText.text = "Score: " + score.ToString("00");
        	GameController.FinalizarJogo();
    	}
	}

    public float GetTempo() { return tempo; }
}