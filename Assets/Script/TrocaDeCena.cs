using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaDeCena : MonoBehaviour
{
    public string cena = "";

    public void TrocarACena(string cena)
    {
        SceneManager.LoadScene(cena);
    }
}
