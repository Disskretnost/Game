using UnityEngine;

public class Aiming : MonoBehaviour
{
    private Animator animator;
    public bool aiming;
    private bool isAimingActivated;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // ������ ��� ���������/���������� ���������� aiming � ����������� �� ����� ������������
        if (Input.GetMouseButtonDown(1))
        {
            if (!isAimingActivated)
            {
                aiming = true;
                isAimingActivated = true;
            }
        }
        else if (Input.GetMouseButtonUp(1))
        {
            aiming = false;
            isAimingActivated = false;
        }

        // ��������� �������� ���������� aiming � ���������
        animator.SetBool("aiming", aiming);
    }
}
