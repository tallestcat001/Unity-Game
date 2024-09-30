using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] List<GameObject> coins;

    [SerializeField] float offset = 2.5f;
    [SerializeField] int creatcount = 16;

    private void Awake()
    {
        coins.Capacity = 20;

        Create();
    }

    public void Create()
    {
        for(int i = 0; i < creatcount; i++)
        {
            GameObject clone = ResourcesManager.Instance.Instantiate("Coin", gameObject.transform);

            clone.transform.localPosition = new Vector3(0, 0.0825f, offset * i);

            coins.Add(clone);
        }
    }

    public void InitializePosition()
    {
        transform.localPosition = new Vector3(positionX * Random.Range(-1, 2), 0, 0);

        foreach(GameObject clone in coins) 
        {
            clone.SetActive(true);
        }
    }
}
