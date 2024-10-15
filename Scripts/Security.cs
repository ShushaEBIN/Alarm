using System;
using UnityEngine;

public class Security : MonoBehaviour
{
    public event Action Entered;
    public event Action CameOut;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<Thief>(out Thief _))
        {
            Entered?.Invoke();
        }       
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<Thief>(out Thief _))
        {
            CameOut?.Invoke();
        }
    }
}