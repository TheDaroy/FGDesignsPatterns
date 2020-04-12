
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float speed = 20;
    [SerializeField] float timeUntillDeSpawn = 1;
    protected virtual void Update()
    {
       transform.position += (transform.forward * speed * Time.deltaTime);
        
    }
    private void OnEnable()
    {
        Invoke("DeSpawn", timeUntillDeSpawn);
    }
    void DeSpawn()
    {
        gameObject.SetActive(false);
    }


}
