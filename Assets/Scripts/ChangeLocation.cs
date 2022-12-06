using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeLocation : MonoBehaviour
{
    public void FlatLocation()
    {
        SceneManager.LoadScene(1);
    }

    public void ShopLocation()
    {
        SceneManager.LoadScene(2);
    }
    public void UniversityLocation()
    {
        SceneManager.LoadScene(3);
    }

    public void WorkLocation()
    {
        SceneManager.LoadScene(4);
    }

    public void Map()
    {
        SceneManager.LoadScene(5);
    }
}
