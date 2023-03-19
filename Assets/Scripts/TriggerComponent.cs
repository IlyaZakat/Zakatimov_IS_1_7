using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerComponent : MonoBehaviour
{
    [SerializeField] private bool _isDaamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BasePlayerController>() == null) return;

        if(_isDaamage)
        {
            GameManager.Self.SetDamage(1);
        }
        else
        {
            GameManager.Self.UpdateLevel();
        }
    }
}
