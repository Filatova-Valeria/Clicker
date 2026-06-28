using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTrans : MonoBehaviour
{
    public int SceneNumber;
    public void Transition()
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
