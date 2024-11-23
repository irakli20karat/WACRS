using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Rate of Fire (Rounds Per Minute)
    public float rateOfFire = 1200;

    // Spread (degrees)
    public float spreadAngle = 2.0f;

    private float rateOfFireInterval; // Time between shots
    private float timeElapsed = 0;

    void Start()
    {
        // Convert rate of fire (RPM) to interval between shots in seconds
        rateOfFireInterval = 60f / rateOfFire;
    }

    void FireRound()
    {
        // Generate a random spread angle within the specified range
        float randomX = Random.Range(-spreadAngle, spreadAngle);
        float randomY = Random.Range(-spreadAngle, spreadAngle);

        // Create a new rotation for the bullet with the spread applied
        Quaternion randomRotation = firePoint.rotation * Quaternion.Euler(randomX, randomY, 0);

        // Instantiate the bullet with the randomized rotation
        Instantiate(bulletPrefab, firePoint.position, randomRotation);
    }

    void Update()
    {
        // Increment the elapsed time
        timeElapsed += Time.deltaTime;

        // Check if the mouse button is held down
        if (Input.GetMouseButton(0))
        {
            // If enough time has passed, fire a round and reset the timer
            if (timeElapsed >= rateOfFireInterval)
            {
                FireRound();
                timeElapsed = 0; // Reset the timer
            }
        }
    }
}
