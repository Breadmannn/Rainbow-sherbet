using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public MapEditManager mapEditManager;
    
    //���콺 Ŀ���� ���� �� ���� �ٲ� ���׸���
    public Material cursoredMat;

    //ī�޶� �̵��ӵ�
    public float moveSpeed = 5.0f;

    //�����Ǵ� ���� X, Z �������� �ִ� ��
    float mapXMaxValue;
    float mapZMaxValue;
    float mapHeightMax;
    float mapHeightMin;

    // Start is called before the first frame update
    void Start()
    {
        //ī�޶� ������ ���� ���� ���ڼ���
        mapXMaxValue = mapEditManager.blockSize * mapEditManager.mapSize.x;
        mapZMaxValue = mapEditManager.blockSize * mapEditManager.mapSize.y;

        mapHeightMax = mapEditManager.blockSize * mapEditManager.mapSize.y;
        mapHeightMin = 3.0f + mapEditManager.blockSize;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
        MouseInput();
        
    }

    //�� �����Ϳ��� �÷��̾� �̵�
    //�յڿ� �̶� ���� ����
    void CameraMove()
    {
        //ī�޶� �����¿� �̵�
        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.z >= mapZMaxValue)
            {
                transform.position.Set(transform.position.x, transform.position.y, mapZMaxValue);
            }
            else transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.z <= 0)
            {
                transform.position.Set(transform.position.x, transform.position.y, 0);
            }
            else transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x >= mapXMaxValue)
            {
                transform.position.Set(mapXMaxValue, transform.position.y, transform.position.z);
            }
            else transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x <= 0)
            {
                transform.position.Set(0, transform.position.y, transform.position.z);
            }
            else transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        //ī�޶� ������ �̵�
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (transform.position.y >= mapHeightMax)
            {
                transform.position.Set(transform.position.x, mapHeightMax, transform.position.z);
            }
            else { transform.Translate(Vector3.up); }
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            if (transform.position.y <= mapHeightMin)
            {
                transform.position.Set(transform.position.x, mapHeightMin, transform.position.z);
            }
            else { transform.Translate(Vector3.down); }
        }
    }

    //���콺 Ŭ�� �κ�
    //Ŀ���� �� �� Ȯ��
    //Ŭ���� ���� �� ��ġ �� ����
    void MouseInput()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            Debug.Log(hit.transform.gameObject);

            //���콺 Ŀ�� ���� �� ť�� ���׸��� ����
            Material[] mat = hit.transform.gameObject.GetComponent<MeshRenderer>().materials;
            if (mat[0].name != "CursoredBlock")
            {
                mat[0] = cursoredMat;
                hit.transform.gameObject.GetComponent<MeshRenderer>().materials = mat;
            }

            //���콺 ��Ŭ��(�� ����)
            if(Input.GetMouseButtonDown(0))
            {

            }

            //���콺 ��Ŭ��(�� ����: Noneblock���� ����)
            else if(Input.GetMouseButtonDown(1))
            {

            }
        }
    }
}
