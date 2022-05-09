using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEditManager : MonoBehaviour
{
    public int blockSize = 1;   //���簢�� ���� �Ѻ� ����
    public Vector2 mapSize = new Vector2(10, 25);   //���� ũ��

    public GameObject parentObject;
    public PrefabsManager prefabsManager;

    public string[] mapBlocks;  //��ġ�� ���� �ڵ带 ���� �迭

    // Start is called before the first frame update
    void Start()
    {
        //������ ���� �迭 ����
        int stringSize = (int)mapSize.x * (int)mapSize.y;
        mapBlocks = new string[stringSize];
        InitMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateBlock()
    {
        for(int i = 0; i < mapBlocks.Length; i++)
        {
            int x = (i % 10);
            int y = (i / 10);
            Vector3 pos = new Vector3(x * blockSize, 0, y * blockSize);

            //�� ����
            //���ڿ� �迭�� stringSize�� ����ִ� ���ڵ带 ����
            //�׿� �´� �� �������� ����
            GameObject go = Instantiate(
                prefabsManager.GetBlockObject(mapBlocks[i]),
                pos,
                Quaternion.identity
                ) as GameObject;
            go.transform.parent = parentObject.transform;
        }
    }

    public void InitMap()
    {
        for(int i = 0; i < mapBlocks.Length; i++)
        {
            mapBlocks[i] = "NULL";
        }
    }
}
