using UnityEngine;

public class colectSphers : MonoBehaviour
{
    public int coinValue = 1;
    public AudioClip collectSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ColectibleManager.instance.AddCoins(coinValue);

            AudioSource.PlayClipAtPoint(collectSound, transform.position);


            Destroy(gameObject);
        }
    }
}