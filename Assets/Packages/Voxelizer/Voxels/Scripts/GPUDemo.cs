//using SFB;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace VoxelSystem.Demo {

	[RequireComponent(typeof(MeshFilter))]
	public class GPUDemo : MonoBehaviour {

		enum MeshType {
			Volume, Surface
		};

		[SerializeField] MeshType type = MeshType.Volume;
		[SerializeField] protected Mesh mesh;
		[SerializeField] protected ComputeShader voxelizer;
		[SerializeField] protected int resolution = 32;
		[SerializeField] protected bool useUV = false;

		void Start() {

            

            Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();

			
			var data = GPUVoxelizer.Voxelize(voxelizer, mesh, resolution, (type == MeshType.Volume));
			GetComponent<MeshFilter>().sharedMesh = VoxelMesh.Build(data.GetData(), data.UnitLength, useUV);
			data.Dispose();
			
			stopWatch.Stop();
			Calc.TimeLib.Add("Block_File", stopWatch.ElapsedMilliseconds.ToString());
			foreach (var Time in Calc.TimeLib){
				UnityEngine.Debug.Log($"{Time.Key}-{Time.Value}");
			}
            Cursor.lockState = CursorLockMode.Locked;
        }

	}

    internal class Create_Objact
    {
        public Create_Objact()
        {
        }
    }

    public static class Calc
		{

		public static Dictionary<string, string> TimeLib = new Dictionary<string, string>();	

		}

}
