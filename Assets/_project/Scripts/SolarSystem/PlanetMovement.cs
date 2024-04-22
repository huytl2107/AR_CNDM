using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    [SerializeField] private Transform _sun;

    [Header("Distance To The Sun (AU)")]
    [SerializeField] private float _radius;

    [Header("Roration Speed (Day)")]
    [SerializeField] private float _rorationSpeed;

    [Header("One Cycle Time (Year)")]
    [SerializeField] private float _timeToMoveOneCycle;

    private float theta; // Góc hiện tại trong radians

    private void Awake()
    {
        Vector3 target = new Vector3(_sun.position.x, _sun.position.y, _sun.position.z);
        transform.position = new Vector3(_radius * 10 + target.x, 0 + target.y , 0 + target.z );
        _radius = _radius * 10; //Chuyển từ AU thành đơn vị trong game
    }
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, _rorationSpeed, 0) *Time.fixedDeltaTime);
        Movement();
    }

    private void Movement()
    {
        Transform parent = transform.parent;
        Vector3 target = new Vector3(_sun.position.x, _sun.position.y, _sun.position.z);

        // Tăng góc theo thời gian để tạo chuyển động
        theta += 1 / _timeToMoveOneCycle * Time.fixedDeltaTime;

        // Chuyển đổi từ tọa độ cực sang tọa độ Descartes
        float x = _radius * parent.localScale.x * Mathf.Cos(theta);
        float z = _radius * parent.localScale.x * Mathf.Sin(theta);

        // Áp dụng vị trí mới đến transform của đối tượng
        transform.position = new Vector3(x + target.x, target.y , z + target.z); // Giả sử hành tinh di chuyển trên mặt phẳng XZ
    }    
}
