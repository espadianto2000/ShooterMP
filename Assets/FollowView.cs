using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowView : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private bool rotacion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position;
        if (rotacion)
        {
            transform.rotation = target.transform.rotation;
        }
    }
}
