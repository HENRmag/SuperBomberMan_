using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public GameObject esplosionPrefab;

    public LayerMask levelMask;
    public bool exploded = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Esplosao", 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Esplosao()
    {
        //Instancia um novo prefat,  no caso a explosão;
        Instantiate(esplosionPrefab, transform.position, quaternion.identity);

        //Cria as esplossões
        StartCoroutine(CreateExplosion(Vector3.forward));
        StartCoroutine(CreateExplosion(Vector3.right));
        StartCoroutine(CreateExplosion(Vector3.back));
        StartCoroutine(CreateExplosion(Vector3.left));

        // aciona o componente MeshRenderer,  responsável por renderizar o formato do objeto e torna ele falso;
        GetComponent<MeshRenderer>().enabled = false;
        exploded = true;
        //encontra o colisor do objeto
        /// Erro!!!!!! não está encontrando o colisor,  ____resolver____
        //transform.Find("Collider").gameObject.SetActive(false);
        GetComponent<SphereCollider>().enabled = false;
        // destroi o objeto 
        Destroy(gameObject, .3f);

        

    }
    private IEnumerator CreateExplosion(Vector3 direction)
    {
        // define o tamanho das esplosões
        for (int i = 1; i < 3; i++)
        {
            RaycastHit hit;

            Physics.Raycast(transform.position + new Vector3(0, 5f, 0), direction, out hit, i, levelMask);

            if (!hit.collider)
            {
                Instantiate(esplosionPrefab, transform.position + (i * direction), esplosionPrefab.transform.rotation);

            }
            // quebra o if 
            else
            {
                break;
            }
            yield return new WaitForSeconds(.05f);
        }
        
    }

}
