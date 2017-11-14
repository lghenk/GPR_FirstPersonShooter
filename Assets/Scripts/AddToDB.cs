// Created by Timo Heijne

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToDB : MonoBehaviour {

    public static AddToDB instance;

    // Use this for initialization
    void Start() {
        if (AddToDB.instance != null) {
            Destroy(this);
        } else {
            instance = this;
        }
    }

    // Update is called once per frame
    public void AddShotLog(Vector3 pos) {
        StartCoroutine(DoQuery(pos.x, pos.y, pos.z));
    }

    IEnumerator DoQuery(float x, float y, float z) {        
        WWW request = new WWW(string.Format("http://22279.hosts.ma-cloud.nl/GPR_DB.php?t_x={0}&t_y={1}&t_z={2}&p_id=99", x, y ,z));
        yield return request;
    }
}
