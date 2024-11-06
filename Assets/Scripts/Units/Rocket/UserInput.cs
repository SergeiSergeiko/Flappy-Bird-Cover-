using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField] private Attacker _attacker;
    [SerializeField] private RocketMover _mover;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _mover.OnButtonJumpPressed();

        if (Input.GetKeyDown(KeyCode.Mouse0))
            _attacker.Attack();
    }
}