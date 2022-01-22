using UnityEngine;

namespace MathTools
{
    class Mover : MonoBehaviour
    {
        [SerializeField] Vector3 target;
        [SerializeField] float speed;

        void FixedUpdate()
        {
            if (Vector3.Distance(transform.position, target) > 1.0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime );
            }
        }
    }

}