using Dummiesman;
//using System.IO;
using UnityEngine;
using SFB;
using System.IO;

public class ObjFromFile : MonoBehaviour
{
    //void Start()
    //{
    //    Cursor.lockState = CursorLockMode.Locked;
    //}
    string objPath = string.Empty;
    GameObject loadedObject;
    //public GameObject cube;

    private string OpenFiledialog()
    {
        // Open file       
        var extensions = new[]{
            new ExtensionFilter("3D Files", "obj"),
            new ExtensionFilter("Texture Files", "png", "jpg", "jpeg" ),
            new ExtensionFilter("All Files", "*" ),
        };
        return StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, true)[0];
    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(256, 32, 64, 32), "Load File"))
        {
            var sw = new StreamWriter("D:\\log.txt");
            var path = OpenFiledialog();
            objPath = GUI.TextField(new Rect(0, 0, 256, 32), path);
            Destroy(loadedObject);
            sw.WriteLine("log ONe");
            sw.Close();
            loadedObject = new OBJLoader().Load(objPath);
        }
    }

}