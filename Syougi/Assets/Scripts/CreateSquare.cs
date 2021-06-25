using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSquare : MonoBehaviour
{
    public GameObject prefab;
    public GameObject[,] squares = new GameObject[5, 8];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 8; j++)
            {
                squares[i, j] = Instantiate(prefab, new Vector3(i - 2.0f, j - 3.5f, 0), this.transform.rotation, this.transform);
                squares[i, j].GetComponent<Square>().x = i;
                squares[i, j].GetComponent<Square>().y = j;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

   
}
