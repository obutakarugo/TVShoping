using UnityEngine;
using System.Collections;

public class ChangeCamera : MonoBehaviour {

	[SerializeField]
	Camera[] SubCamera;
	int _camera_number;

	// Use this for initialization
	void Start () {
	
		_camera_number = 0;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {

			if (_camera_number < SubCamera.Length - 1) {
				_camera_number++;
			} else {
				_camera_number = 0;
			}

			SetCamera(_camera_number);
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
		
			CameraTarget ();

		}


	}

	//Target
	void CameraTarget(){
	
		SubCamera [_camera_number].transform.LookAt(GameObject.FindGameObjectWithTag("MainGoods").transform);

	}

	//カメラをチェンジ
	void SetCamera(int set_camera_number = 0){
	
		SubCamera [_camera_number].enabled = false;

		SubCamera [set_camera_number].enabled = true;

	}
}
