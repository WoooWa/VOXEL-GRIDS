using UnityEngine;
using UnityEngine.SceneManagement;
public class EscapeSimulate : MonoBehaviour
{void Update(){if (Input.GetKey("escape")) SceneManager.LoadScene(0);}}