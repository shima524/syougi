using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//”Õ–ÊƒNƒ‰ƒX
public class Table : MonoBehaviour
{
    public Piece[,] table = new Piece[5, 8];
    public GameObject prefab;

    public GameObject[] playerObject = new GameObject[3];
    public GameObject[] enemyObject = new GameObject[3];


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            playerObject[i] = Instantiate(prefab, new Vector3(i-1, -2.5f, 0), this.transform.rotation, this.transform);
            playerObject[i].GetComponent<Piece>().player = true;

            playerObject[i].GetComponent<Piece>().moveArea[0, 0] = true;
            playerObject[i].GetComponent<Piece>().moveArea[0, 1] = true;
            playerObject[i].GetComponent<Piece>().moveArea[0, 2] = true;
            playerObject[i].GetComponent<Piece>().moveArea[1, 0] = true;
            playerObject[i].GetComponent<Piece>().moveArea[1, 1] = false;
            playerObject[i].GetComponent<Piece>().moveArea[1, 2] = true;
            playerObject[i].GetComponent<Piece>().moveArea[2, 0] = true;
            playerObject[i].GetComponent<Piece>().moveArea[2, 1] = true;
            playerObject[i].GetComponent<Piece>().moveArea[2, 2] = true;
        }

        for (int i = 0; i < 3; i++)
        {
            enemyObject[i] = Instantiate(prefab, new Vector3(i-1, 2.5f, 0), this.transform.rotation, this.transform);
            enemyObject[i].GetComponent<Piece>().player = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
