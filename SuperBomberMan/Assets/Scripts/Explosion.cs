using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Bomb bomb = new Bomb();
    
    // Update is called once per frame
    void Update()
    {


    }

    public void OnTriggerEnter(Collider other)
    {
        if (!bomb.exploded && other.CompareTag("Esplosao"))
        {
            //cancela a instanciação da explosão
            bomb.CancelInvoke("Esplosao");
            

        }
        else if (!bomb.exploded && other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }

    }
}
