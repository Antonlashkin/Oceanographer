using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatPerson : MonoBehaviour
{
    [SerializeField] GameObject ender;
    private void OnTriggerEnter(Collider other)
    {
        CharacterController character = other.GetComponent<CharacterController>();
        if (character != null && MoveShark.Atacked)
        {
            MoveShark.Atacked = false;
            ender.GetComponent<EndGame>().EndedGame();
        }
    }
}
