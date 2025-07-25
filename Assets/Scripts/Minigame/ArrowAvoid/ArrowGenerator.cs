using ArrowAvoid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    [SerializeField] float arrowSpeed = 2f;
    [SerializeField] float genCoolTime = 1f;
    [SerializeField] float spawnY = 6f;

    public Arrow arrowPrefab;

    public void StartGenerateArrow()
    {
        StartCoroutine(GenerateArrow());
    }

    public void StopGenerateArrow()
    {
        StopAllCoroutines();
    }

    IEnumerator GenerateArrow()
    {
        while (true)
        {
            float spawnX = Random.Range(-4.5f, 4.5f);

            Arrow arrow = Instantiate(arrowPrefab, new Vector3(spawnX, spawnY, 0), Quaternion.identity);
            arrow.Init(arrowSpeed + Random.Range(0, 2f));

            yield return new WaitForSeconds(genCoolTime - Random.Range(0, 0.5f));
        }
    }
}
