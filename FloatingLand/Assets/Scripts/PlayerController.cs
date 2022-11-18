using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{ 
    Rigidbody _player;
    private GameObject FocalPoint;
    public GameObject powerUpIndicator;
    public TextMeshProUGUI gameOverText;
    public float speed = 8f;
    public float powerUpStrength;
    public bool hasPowerUp; 
    public bool gameOver = false;
    private void Start()
    {
        _player = GetComponent<Rigidbody>();
        FocalPoint = GameObject.Find("Focal Point");
    }
    private void Update()
    {
        _player.AddForce(FocalPoint.transform.forward * Input.GetAxis("Vertical") * speed);
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if(transform.position.y<-2f)
        {
            gameOver = true;
            gameOverText.gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("powerUp"))
        {
            Destroy(other.gameObject);
            hasPowerUp = true;
            powerUpIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerUpCountdown());
        }
    }
    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(7f);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayer * powerUpStrength , ForceMode.Impulse);
        }
    }
}
