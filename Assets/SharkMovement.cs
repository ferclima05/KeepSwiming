using UnityEngine;

public class SharkMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
	public float aceleracaoPorSegundo = 0.05f;
	public float speedMaxima = 4f;
    
    private float cooldownHit = 1f;
    private float ultimoHit = -1f;
    
    public AudioSource audioSource;
    public AudioClip biteSound;
    
    void Start()
    {
        gameObject.SetActive(false);
        Invoke("Aparecer", 8f);
    }

    void Aparecer()
    {
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (!GameController.gameOver && player != null)
        {
			float tempoAtual = GameManager.Instance.GetTempo();
        	float speedAtual = Mathf.Min(speed + (tempoAtual * aceleracaoPorSegundo), speedMaxima);

            Vector2 direcao = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                speedAtual * Time.deltaTime
            );

            // Virar o sprite mantendo o scale original
            float scaleX = Mathf.Abs(transform.localScale.x);
            float scaleY = transform.localScale.y;

            if (direcao.x > 0)
                transform.localScale = new Vector3(scaleX, scaleY, 1);
            else
                transform.localScale = new Vector3(-scaleX, scaleY, 1);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Time.time - ultimoHit >= cooldownHit)
            {
                ultimoHit = Time.time;
                GameManager.Instance.PerderVida();
            }
        }
        else if (other.CompareTag("Coletavel"))
        {
            audioSource.PlayOneShot(biteSound);
            GameManager.Instance.RemoverPonto();
            Destroy(other.gameObject);
        }
    }
}