using System;
using UnityEngine;

namespace DefaultNamespace.Seção_14___Extras_Esclarecendo_dúvidas
{
    public class Updates : MonoBehaviour
    {
        private void FixedUpdate()
        {
            print("Update: " + Time.deltaTime);
        }
    }
}