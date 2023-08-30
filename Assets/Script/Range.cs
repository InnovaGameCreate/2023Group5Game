using UnityEngine;
public class Range : MonoBehaviour
{
    [SerializeField] private Transform _LeftEdge;
    [SerializeField] private Transform _RightEdge;
    private float MoveSpeed = 3.0f;
    private int direction = 1;
    void FixedUpdate()
    {
        if (transform.position.z >= _RightEdge.position.z)
            direction = -1;
        if (transform.position.z <= _LeftEdge.position.z)
            direction = 1;
        transform.position = new Vector3(transform.position.z + MoveSpeed * Time.fixedDeltaTime * direction, 0, 0);
    }
}