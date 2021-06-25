using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//盤面クラス
public class Table : MonoBehaviour
{
    public Piece[,] table = new Piece[5, 8];
    public GameObject prefab;

    public GameObject[] playerObject = new GameObject[3];
    public GameObject[] enemyObject = new GameObject[3];

    public GameObject clickedGameObject;
    public int selectX, selectY;

    public GameObject selectObject;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            //playerObject[i] = Instantiate(prefab, new Vector3(i-1, -2.5f, 0), this.transform.rotation, this.transform);
            playerObject[i] = Instantiate(prefab, new Vector3(0, 0, 0), this.transform.rotation, this.transform);
            playerObject[i].GetComponent<Piece>().Move(i + 1, 1);

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

        //クリックしたとき
        if (Input.GetMouseButtonDown(0))
        {

            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            //クリックされたものがマス目だったとき
            if (Physics.Raycast(ray, out hit))
            {
                clickedGameObject = hit.collider.gameObject;
                selectX = clickedGameObject.GetComponent<Square>().x;
                selectY = clickedGameObject.GetComponent<Square>().y;


                if (selectObject == null)
                {
                    selectObject = searchPiece(selectX, selectY); //そのマス目に載っているコマを取得
                }
                else {
                    selectObject.GetComponent<Piece>().Move(selectX, selectY);
                    selectObject = null;
                }
            }
            

            Debug.Log(clickedGameObject);
        }
    }

    GameObject searchPiece(int x, int y) {
        GameObject obj = null;
        for (int i = 0; i < 3; i++) {
            if (playerObject[i].GetComponent<Piece>().x == x && playerObject[i].GetComponent<Piece>().y == y) {
                obj = playerObject[i];
            }
        }
        return obj;
    }
}
