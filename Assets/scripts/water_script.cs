using UnityEngine;

public class WaterSplashTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem splashPrefab;
    [SerializeField] private string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag))
            return;

        if (splashPrefab == null)
        {
            Debug.LogWarning("Assign the BigSplash prefab!");
            return;
        }

        // Place the splash at the water surface,
        // aligned with the player's horizontal position.
        Vector3 splashPosition = new Vector3(
            other.bounds.center.x,
            transform.position.y,
            other.bounds.center.z
        );

        ParticleSystem splash = Instantiate(
            splashPrefab,
            splashPosition,
            Quaternion.identity
        );

        splash.Play();

        float cleanupTime =
            splash.main.duration +
            splash.main.startLifetime.constantMax + 1f;

        Destroy(splash.gameObject, cleanupTime);
    }
}