using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float launchForce = 10f;
    public AudioSource audioSource;
    private GameObject bullet = null;

    public void SpawnBullet(Vector3 position, Vector3 rotation)
    {
        audioSource.Play();
        bullet = Instantiate(bulletPrefab, position, Quaternion.Euler(rotation));
        bullet.GetComponent<Rigidbody2D>().AddForce(
            new Vector2(launchForce * rotation.x, launchForce * rotation.y), ForceMode2D.Impulse);
    }
}
