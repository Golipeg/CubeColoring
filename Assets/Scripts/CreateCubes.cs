using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCubes : MonoBehaviour
{
    [SerializeField]
    private GameObject _cubePrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            InitCube();
        }
    }

    private void InitCube()
    {
        GameObject cubePrefab = Instantiate(_cubePrefab);
        cubePrefab.transform.position = new Vector3(Random.Range(-15f, 15f), 30, Random.Range(-15,15));
        cubePrefab.transform.rotation=Quaternion.identity;
        cubePrefab.transform.parent = transform;
    }
}
