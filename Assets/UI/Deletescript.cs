using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deletescript : MonoBehaviour
{
    public void RemoveObject(GameObject input)
    {
        Destroy(input.gameObject);
    }
}
