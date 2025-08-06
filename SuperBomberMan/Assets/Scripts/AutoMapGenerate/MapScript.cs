using System;
using UnityEngine;

public class MapScript : MonoBehaviour
{

    public int comprimento = 5;
    public int largura = 5;

    public float tamanhoCelula = 1;
    public GameObject cellprefab;// prefab que representa a celula do grid

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void GridGenerate()
    {
        for (int x = 0; x < comprimento; x++)
        {
            for (int y = 0; y < largura; y++)
            {
                Vector3 posicao = new Vector3(x * tamanhoCelula, 0, y * tamanhoCelula);
                Instantiate(cellprefab, posicao, Quaternion.identity, transform);
            }
        }
    }
}
