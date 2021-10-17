using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float steerSpeed;
    [SerializeField] private Animator anim; 
    [SerializeField] private float maxPosition;
    [SerializeField] float smoothTime;
    private Vector3 velocity = Vector3.zero;
    private bool finish = false;

    public static event Action onReachFinish;

    private void Update()
    {
        if (Mathf.Abs(transform.position.x) > maxPosition)
        {
            transform.position = new Vector3(Mathf.Sign(transform.position.x) * maxPosition, transform.position.y, transform.position.z); 
        }
    }

    public void Move(float dif)
    {
        if (finish) 
            return;

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        Vector3 targetPosition = new Vector3(transform.position.x - dif * steerSpeed, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
    public void StartMove()
    {
        anim.SetBool("Moving", true);
    }

    public void FinishMove()
    {
        anim.SetBool("Moving", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            onReachFinish?.Invoke();
            finish = true;
            FinishMove();
        }    
    }
}
