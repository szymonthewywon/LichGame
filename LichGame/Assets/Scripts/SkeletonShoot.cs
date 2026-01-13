using System.Collections;
using UnityEngine;

public class SkeletonShoot : MonoBehaviour
{
    [SerializeField]GameObject Arrow;
    [SerializeField]float firingDelay;

    private void Start()
    {
        StartCoroutine(shoot());
    }

    IEnumerator shoot()
    {
        while (true)
        {
            Instantiate(Arrow, transform.position, Quaternion.Euler(0,0,-90));
            yield return new WaitForSeconds(firingDelay);
        }
    }
}
