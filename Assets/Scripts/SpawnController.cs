using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject GhostPrefab;
    public GameObject SkeletonPrefab;
    public GameObject PumpkinPrefab;

    public void Spawn(int ghost, int skeleton, int pumpkin, List<Vector3> positions)
    {
        int i = 0;
        GameObject g;
        for (; i < ghost; i++)
        {
            g = Instantiate(GhostPrefab);
            g.transform.position = positions[i];
        }

        for (; i < ghost + skeleton; i++)
        {
            g = Instantiate(SkeletonPrefab);
            g.transform.position = positions[i];
        }

        for (; i < ghost + skeleton + pumpkin; i++)
        {
            g = Instantiate(PumpkinPrefab);
            g.transform.position = positions[i];
        }
    }
}