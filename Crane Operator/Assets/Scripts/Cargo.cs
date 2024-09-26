using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour
{
    [SerializeField] public Transform grabPoint;
    [SerializeField] public bool isGrabbing;
    [SerializeField] public bool canGrab = true;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Renderer[] _renderers;

    public Rigidbody GetRigidbody()
    {
        return _rb;
    }
    public void SetActive()
    {
        foreach (var _renderer in _renderers)
        {
            foreach (var item in _renderer.materials)
            {
                item.EnableKeyword("_EMISSION");  
            }
        }
    }
    public void SetDisable()
    {
        foreach (var _renderer in _renderers)
        {
            foreach (var item in _renderer.materials)
            {
                item.DisableKeyword("_EMISSION");          
            }
        }
    }
}
