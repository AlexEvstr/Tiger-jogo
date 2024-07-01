using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _stones;
    private GameObject _tiger;
    public static bool CanSpawnStone;

    private void Start()
    {
        _tiger = GameObject.FindGameObjectWithTag("Tiger");
        CanSpawnStone = true;
        StartCoroutine(SpawnStone());
    }

    private IEnumerator SpawnStone()
    {
        yield return new WaitForSeconds(2.0f);
        while (true)
        {
            if (CanSpawnStone)
            {
                GameObject newStone = Instantiate(_stones[Random.Range(0, _stones.Length)]);
                newStone.transform.position = new Vector2(_tiger.transform.position.x, 6.0f);
                CanSpawnStone = false;
            }

            yield return new WaitForSeconds(3.5f);
        }
    }
}
