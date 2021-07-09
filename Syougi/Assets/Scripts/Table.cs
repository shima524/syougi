using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//盤面クラス
public class Table : MonoBehaviour
{
    public Piece[,] table = new Piece[5, 8];
    public GameObject prefab;

    public List<GameObject> playerObject = new List<GameObject>();

    public List<GameObject> enemyObject = new List<GameObject>();

    public GameObject clickedGameObject;
    public int selectX, selectY;

    public GameObject selectObject;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = new List<GameObject>();
        enemyObject = new List<GameObject>();

        for (int i = 0; i < 3; i++)
        {
            //playerObject[i] = Instantiate(prefab, new Vector3(i-1, -2.5f, 0), this.transform.rotation, this.transform);
            GameObject obj;
            obj = Instantiate(prefab, new Vector3(0, 0, 0), this.transform.rotation, this.transform);

            obj.GetComponent<Piece>().Move(i + 1, 1);

            obj.GetComponent<Piece>().player = true;

            playerObject.Add(obj);
            /*
            obj.GetComponent<Piece>().moveArea[0, 0] = true;
            obj.GetComponent<Piece>().moveArea[0, 1] = true;
            obj.GetComponent<Piece>().moveArea[0, 2] = true;
            obj.GetComponent<Piece>().moveArea[1, 0] = true;
            obj.GetComponent<Piece>().moveArea[1, 1] = false;
            obj.GetComponent<Piece>().moveArea[1, 2] = true;
            obj.GetComponent<Piece>().moveArea[2, 0] = true;
            obj.GetComponent<Piece>().moveArea[2, 1] = true;
            obj.GetComponent<Piece>().moveArea[2, 2] = true;
            */
            //Debug.Log("a:" + playerObject[0] + " count:" + playerObject.Count);

            //playerObject.Add(obj);
            //Debug.Log("b:" + playerObject[0] + " count:" + playerObject.Count);

            //playerObject.RemoveAt(0);
            //Debug.Log("c:" + playerObject[0] + " count:" + playerObject.Count);

            //Debug.Log(playerObject[0]);
        }
        
        for (int i = 0; i < 3; i++)
        {
            GameObject obj;
            obj = Instantiate(prefab, new Vector3(0, 0, 0), this.transform.rotation, this.transform);

            obj.GetComponent<Piece>().Move(i + 1, 5);
            obj.GetComponent<Piece>().player = false;

            enemyObject.Add(obj);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        movePiece();
    }

    //(x,y)にある駒を返す
    GameObject searchPiece(int x, int y) {
        GameObject obj = null;
        for (int i = 0; i < playerObject.Count; i++) {
            if (playerObject[i].GetComponent<Piece>().x == x && playerObject[i].GetComponent<Piece>().y == y) {
                obj = playerObject[i];
            }
        }
        for(int i = 0; i < enemyObject.Count; i++) { 
            if (enemyObject[i].GetComponent<Piece>().x == x && enemyObject[i].GetComponent<Piece>().y == y)
            {
                obj = enemyObject[i];

                Debug.Log("enemy選択");
            }
        }

        //obj = enemyObject[0];
        return obj;
    }

    void movePiece() {
        //クリックしたとき
        if (Input.GetMouseButtonDown(0))
        {

            clickedGameObject = null; //クリックされたオブジェクト

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //クリックされた方向にレイを飛ばす
            RaycastHit hit = new RaycastHit();

            //クリックされたものがマス目だったとき
            if (Physics.Raycast(ray, out hit))
            {
                clickedGameObject = hit.collider.gameObject;
                selectX = clickedGameObject.GetComponent<Square>().x;
                selectY = clickedGameObject.GetComponent<Square>().y;


                if (selectObject == null) //駒選択
                {
                    selectObject = searchPiece(selectX, selectY); //そのマス目に載っているコマを取得
                }
                else //駒移動
                {
                    GameObject opponent = searchPiece(selectX, selectY); //先客駒

                    if(opponent == null) //移動先が空
                    {
                        selectObject.GetComponent<Piece>().Move(selectX, selectY);
                        selectObject = null;
                    }
                    else if (selectObject.GetComponent<Piece>().player == opponent.GetComponent<Piece>().player) //移動先に味方
                    {
                        selectObject = null;
                    }
                    else { //移動先が敵

                        removePiece(opponent); //リストからnullを削除
                        
                        
                        selectObject.GetComponent<Piece>().Move(selectX, selectY);
                        selectObject = null;
                    }
                        
                    
                }
            }
            Debug.Log(clickedGameObject);
        }

        
    }

    void removePiece(GameObject opponent) {
        for (int i = 0; i < playerObject.Count; i++) {
                playerObject.Remove(opponent);
                Debug.Log ("remove");
        }
        for (int i = 0; i < enemyObject.Count; i++)
        {
                enemyObject.Remove(opponent);
                Debug.Log("remove");
        }
        Destroy(opponent);
    }

}
