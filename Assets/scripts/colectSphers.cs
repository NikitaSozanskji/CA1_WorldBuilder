using UnityEngine;

public class colectSphers : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ColectibleManager.instance.AddCoins(coinValue);
            Destroy(gameObject);
        }
    }
}