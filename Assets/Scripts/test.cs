using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Serialization;

public class test : Tool
{
    public string githubUesrName;
    public string year;

    private Vector3 generateLocation=new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        WWWGet($"https://skyline.github.com/{githubUesrName}/{year}.json", (data) =>
        {
            Debug.Log("data:" + data);
            var json = JsonConvert.DeserializeObject<JsonClass.Root>(data.ToString());

            if (json != null)
            {
                foreach (var contributionsItem in json.contributions)
                {
                    foreach (var daysItem in contributionsItem.days)
                    {
                        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        cube.transform.parent = transform;
                        cube.name = $"{contributionsItem.week}-{daysItem.count}";
                        cube.transform.position=generateLocation;
                        Material mat =new Material(Shader.Find("Standard"));
                        
                        if (daysItem.count > json.p90)
                        {
                            mat.color=Color.red;
                        }
                        else if (daysItem.count>json.median)
                        {
                            mat.color=Color.yellow;
                        }
                        else if (daysItem.count>0)
                        {
                            mat.color=Color.green;
                        }
                        else
                        {
                            mat.color = Color.gray;
                        }

                        cube.GetComponent<Renderer>().material=mat;

                        var a = 15 / json.max;//计算比例
                        
                        cube.transform.localScale = new Vector3(1f, daysItem.count*a, 1f);
                        cube.transform.position = new Vector3(cube.transform.position.x, daysItem.count*a/2, cube.transform.position.z);

                        generateLocation.z-=1;
                    }
                    generateLocation.z = 0;
                    generateLocation.x += 1;
                }
            }
        });
    }
}