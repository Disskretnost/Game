using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float speed = 3f;
    private Animator animator;
    public float rotationSpeed = 20f;

    private bool isFirstClick = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 directionVector = new Vector3(h, 0, v);
        if (directionVector.magnitude > 0.05f)
        {
            if (isFirstClick)
            {
                isFirstClick = false;
                directionVector *= 0.5f; // Уменьшение скорости перемещения
            }

            Quaternion targetRotation = Quaternion.LookRotation(directionVector);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            isFirstClick = true; // Сброс флага при отсутствии ввода
        }

        animator.SetFloat("speed", Mathf.Clamp(directionVector.magnitude, 0, 1));
        rigidbody.velocity = directionVector.normalized * speed* 2;
    }
}




