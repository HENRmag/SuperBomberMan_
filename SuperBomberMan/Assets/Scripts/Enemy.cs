using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public float radius = 2f;
    public LayerMask playerLayer;
    public LayerMask wallLayer;
    public LayerMask obstacleLayer;
    // Update is called once per frame
    void Update()
    {
        //Detecta as colisões dos layers definidos,  des-de que estejam dentro da esfera
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, playerLayer);


        foreach (Collider collider in hitColliders)
        {
            Debug.Log("Player colidido" + collider.name);

            //Escrever o que vai acontecer com a colisão detectada 
            transform.position = Vector3.MoveTowards(transform.position, collider.transform.position, speed * Time.deltaTime);

        }
    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
