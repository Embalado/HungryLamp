
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] GameObject LifePrefab;
    [SerializeField] GameObject noLifePrefab;
    public void DrawLife(int life, int maxLives)
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        for(int i =0; i<maxLives;i++)
        {
            if(i+1<=life)
            {
                GameObject live = Instantiate(LifePrefab,transform.position,Quaternion.identity);
                live.transform.SetParent(transform);

            }
            else
            {
                GameObject live = Instantiate(noLifePrefab, transform.position, Quaternion.identity);
                live.transform.SetParent(transform);
                // live.transform.parent = transform;
            }
        }
    }
}
