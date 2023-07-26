using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyHealthComponent : MonoBehaviour
{
    [SerializeField] private int _changeHPValue;

    public void ChangeHealth(GameObject target)
    {
        var healthComponent = target.GetComponent<HealthComponent>();
        if (healthComponent != null)
        {
            healthComponent.ChangeHealth(_changeHPValue);
        }
    }
}
