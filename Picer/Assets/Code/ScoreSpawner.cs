using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScoreSpawner : MonoBehaviour
{
    //Расстояние от края на котором меняется направление яблони
    [SerializeField] private float lAndRight = 10f;
    [SerializeField] private float chanceTo = 0.1f;
    [SerializeField] private float speed = 1f;

    [SerializeField] private GameObject[] PrefabMassive;
    [SerializeField] private float timeSpawner = 1f;
    
    private Transform tr;
    private int indax;
    void Update()
    {
        //локальная переменная для хранения текущий позиции AppleTree
        Vector3 pos = transform.position;
        //компонент x увеличивается на произведение скорости и временного интервала
        pos.x += speed * Time.deltaTime;
        //изменение переменной pos записывается обратно в transform.position
        transform.position = pos;

        /* если значение pos.x оказалось меньше значения leftAndRightEdge
         * - переменной speed  присваивается ее положительное значение
         * и тем самым обеспечивается движение вправо в следующем кадре*/
        if (pos.x < -lAndRight)
        {
            speed = Mathf.Abs(speed);
            /* иначе если значение pos.x оказалось больше значения leftAndRightEdge -
             * переменной speed  присваивается ее отрицательное значение и тем самым
             * обеспечивается движение влево в следующем кадре*/
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
