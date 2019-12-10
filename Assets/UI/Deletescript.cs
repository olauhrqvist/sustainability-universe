using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deletescript : MonoBehaviour
{
    // Deletes itself
    public void RemoveObject(GameObject input)
    {
        Destroy(input.gameObject);
    }
}
