using UnityEngine;
using System;
    
public class Coin : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private ParticleSystem particle;
    public static event Action OnCoinPickup;

    private void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCoinPickup?.Invoke();
            particle.Play();
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
