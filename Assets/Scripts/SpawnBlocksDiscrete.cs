using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocksDiscrete : MonoBehaviour {

	public List<string> Block_list = new List<string>(new string[] {"1b", "2b_inline_A", "2b_inline_B", "2b_diagonal_A", "2b_diagonal_B", "3b_inline_A", "3b_inline_B", "3b_bent_A", "3b_bent_B", "3b_bent_C", "3b_bent_D" });
	public float Spawn_Stagger = 1.0f;
	public float Start_Delay = 1.0f;
	public bool Round_Robin = true;
	public static int counter = 0;
    public static Vector3 SpawnPosition = new Vector3();
    public GameObject target = new GameObject();

    List<Vector3> GetSpawnAttributes(int SpawnNumber){
		List<Vector3> SpawnAttributes = new List<Vector3>();

		Vector3 SpawnPosition = GameObject.Find(("Spawn" + SpawnNumber.ToString ())).transform.position;
		Vector3 SpawnScale = GameObject.Find (("Spawn" + SpawnNumber.ToString ())).transform.localScale;

		SpawnAttributes.Add (SpawnPosition);
		SpawnAttributes.Add (SpawnScale);

		return(SpawnAttributes);
	}

	Vector3 CreateSpawnData(){
		List<Vector3> temp = new List<Vector3> ();
		Vector3 SpawnPositionVector = new Vector3 ();
		Vector3 SpawnScaleVector = new Vector3 ();
		Vector3 DirectionVector = new Vector3 ();
		Vector3 SpawnPoint;
		SpawnPoint = new Vector3(0.0f, 0.0f, 0.0f);
		int SpawnScaleScalar = 1;

		if (Round_Robin == true){
			switch (counter % 4) {
			case 0:
				temp = GetSpawnAttributes (1);
				SpawnPositionVector = temp [0];
				SpawnScaleScalar = GetLargestComponentAsInt (temp [1]);
				SpawnScaleVector = SetUnscaledComponentsToZero (temp [1]);
				SpawnPoint = SpawnPositionVector + (SpawnScaleVector.normalized * (int)(0.5 * Random.Range (-SpawnScaleScalar, SpawnScaleScalar)));
				DirectionVector.Set(0, -1, 0);
				break;
			case 1:
				temp = GetSpawnAttributes (2);
				SpawnPositionVector = temp[0];
				SpawnScaleScalar = GetLargestComponentAsInt (temp [1]);
				SpawnScaleVector = SetUnscaledComponentsToZero (temp [1]);
				SpawnPoint = SpawnPositionVector + (SpawnScaleVector.normalized * (int)(0.5 * Random.Range (-SpawnScaleScalar, SpawnScaleScalar)));
				DirectionVector.Set(1, 0, 0);
				break;
			case 2:
				temp = GetSpawnAttributes (3);
				SpawnPositionVector = temp[0];
				SpawnScaleScalar = GetLargestComponentAsInt (temp [1]);
				SpawnScaleVector = SetUnscaledComponentsToZero (temp [1]);
				SpawnPoint = SpawnPositionVector + (SpawnScaleVector.normalized * (int)(0.5 * Random.Range (-SpawnScaleScalar, SpawnScaleScalar)));
				DirectionVector.Set(0, 1, 0);
				break;
			case 3:
				temp = GetSpawnAttributes (4);
				SpawnPositionVector = temp[0];
				SpawnScaleScalar = GetLargestComponentAsInt (temp [1]);
				SpawnScaleVector = SetUnscaledComponentsToZero (temp [1]);
				SpawnPoint = SpawnPositionVector + (SpawnScaleVector.normalized * (int)(0.5 * Random.Range (-SpawnScaleScalar, SpawnScaleScalar)));
				DirectionVector.Set(-1, 0, 0);
				break;
			default:
				counter += 1;
				break;
			}
		}
        else
        {
            temp = GetSpawnAttributes(Random.Range(1, 4));
            SpawnPositionVector = temp[0];
            SpawnScaleScalar = GetLargestComponentAsInt(temp[1]);
            SpawnScaleVector = SetUnscaledComponentsToZero(temp[1]);
            SpawnPoint = SpawnPositionVector + (SpawnScaleVector.normalized * (int)(0.5 * Random.Range(-SpawnScaleScalar, SpawnScaleScalar)));
            DirectionVector.Set(0, -1, 0);
        }
		return SpawnPoint;
	}

	int GetLargestComponentAsInt(Vector3 input_vector){
		List<int> components = new List<int>();
		components.Add ((int)input_vector.x);
		components.Add ((int)input_vector.y);
		components.Add ((int)input_vector.z);
		components.Sort ();
		return components[components.Count - 1];
	}

	Vector3 SetUnscaledComponentsToZero(Vector3 input_vector){
		Vector3 output_vector = new Vector3 ();
		output_vector = input_vector;
		if (output_vector.x == 1){
			output_vector.x = 0;
		}
		if (output_vector.y == 1){
			output_vector.y = 0;
		}
		if (output_vector.z == 1){
			output_vector.z = 0;
		}
		return output_vector;
	}

    void SpawnTheBlock() {
        SpawnPosition = CreateSpawnData();
        counter += 1;
        int i = Random.Range(0, Block_list.Count - 1);
        Instantiate(Resources.Load(Block_list[i]), SpawnPosition, Quaternion.identity);
    }

    void Start () {
        InvokeRepeating("SpawnTheBlock", Start_Delay, Spawn_Stagger);
	}

	void Update() {
	}

}