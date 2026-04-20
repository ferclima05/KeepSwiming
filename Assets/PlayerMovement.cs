using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audio;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);

        float scaleX = Mathf.Abs(transform.localScale.x);
        float scaleY = Mathf.Abs(transform.localScale.y);

        if (moveHorizontal > 0)
            transform.localScale = new Vector3(-scaleX, scaleY, 1);
        else if (moveHorizontal < 0)
            transform.localScale = new Vector3(scaleX, scaleY, 1);

        float direcaoInclinacao = transform.localScale.x > 0 ? 1f : -1f;

        if (moveVertical > 0)
            transform.rotation = Quaternion.Euler(0, 0, -30f * direcaoInclinacao);
        else if (moveVertical < 0)
            transform.rotation = Quaternion.Euler(0, 0, 30f * direcaoInclinacao);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coletavel")
        {
            audio.Play();
            GameManager.Instance.AdicionarPonto();
            Destroy(other.gameObject);                                  
        }
    }
}