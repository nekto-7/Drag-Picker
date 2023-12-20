using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScoreSpawner : MonoBehaviour
{
    //���������� �� ���� �� ������� �������� ����������� ������
    [SerializeField] private float lAndRight = 10f;
    [SerializeField] private float chanceTo = 0.1f;
    [SerializeField] private float speed = 1f;

    [SerializeField] private GameObject[] PrefabMassive;
    [SerializeField] private float timeSpawner = 1f;
    
    private Transform tr;
    private int indax;
    void Update()
    {
        //��������� ���������� ��� �������� ������� ������� AppleTree
        Vector3 pos = transform.position;
        //��������� x ������������� �� ������������ �������� � ���������� ���������
        pos.x += speed * Time.deltaTime;
        //��������� ���������� pos ������������ ������� � transform.position
        transform.position = pos;

        /* ���� �������� pos.x ��������� ������ �������� leftAndRightEdge
         * - ���������� speed  ������������� �� ������������� ��������
         * � ��� ����� �������������� �������� ������ � ��������� �����*/
        if (pos.x < -lAndRight)
        {
            speed = Mathf.Abs(speed);
            /* ����� ���� �������� pos.x ��������� ������ �������� leftAndRightEdge -
             * ���������� speed  ������������� �� ������������� �������� � ��� �����
             * �������������� �������� ����� � ��������� �����*/
        }
        else if (pos.x > lAndRight)
        {
            speed = -Mathf.Abs(speed);
        }
    }
    private void FixedUpdate()
    {
        if (Random.value < chanceTo)
        {
            speed *= -1;
        }
    }
    private void Start()
    {
        StartCoroutine(SpawnObject());
    }
    private IEnumerator SpawnObject()
    {
        while (true)
        {
            indax = Random.Range(0, PrefabMassive.Length);
            tr = this.GetComponent<Transform>();
            GameObject clone = Instantiate(PrefabMassive[indax], tr.position, Quaternion.identity);
            Destroy(clone,4f);
            yield return new WaitForSeconds(timeSpawner);
        }
    }
}
