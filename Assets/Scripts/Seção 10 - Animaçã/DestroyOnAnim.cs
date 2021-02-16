using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAnim : MonoBehaviour
{
    [SerializeField] private Animation partFumaca;

    
    
    private Animator _anim;

    // Start is called before the first frame update
    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
             
    }
}
