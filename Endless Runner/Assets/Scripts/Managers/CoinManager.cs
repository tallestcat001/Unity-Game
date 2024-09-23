using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    [SerializeField] float offset = 2.5f;
    [SerializeField] int creatcount = 16;

    private void Awake()
    {
        Create();
    }

    public void Create()
    {
        for(int i = 0; i < creatcount; i++)
        {
            GameObject clone = Instantiate(prefab);

            clone.transform.SetParent(gameObject.transform);

            clone.transform.localPosition = new Vector3(0, prefab.transform.position.y, offset * i);
        }
    }

    public void InitializePosition()
    {
        
    }
}
