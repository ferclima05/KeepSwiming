using UnityEngine;

public class JellyfishMove : MonoBehaviour
{
    public float speed = 2f;
    public float destroyY = 6f;

	void Update()
	{
    	if (this == null || gameObject == null) return;
    
    	float tempoAtual = GameManager.Instance.GetTempo();
    	float speedAtual = speed + (tempoAtual * 0.02f);
    
    	transform.Translate(Vector2.up * speedAtual * Time.deltaTime);
    	if (transform.position.y > destroyY)
	        Destroy(gameObject);
	}
}