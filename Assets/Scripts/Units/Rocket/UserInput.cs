using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public event Action ButtonAttackPressed;
    public event Action ButtonJumpPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ButtonJumpPressed?.Invoke();

        if (Input.GetKeyDown(KeyCode.Mouse0))
            ButtonAttackPressed?.Invoke();
    }
}