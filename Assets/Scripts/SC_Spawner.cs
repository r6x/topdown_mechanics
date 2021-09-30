using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;


    public class SC_Spawner : MonoBehaviour
{
    public List<GameObject> arrayOfObj = new List<GameObject>();
    public bool xml = true;
    float RandX, RandZ;
    public GameObject downLeft, upRight;
    private Vector3 whereToSpawn;
    public TextAsset xmlRawFile;
    // Start is called before the first frame update
    void Start()
    {
        if (xml)
        {
            string data = xmlRawFile.text;
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(new StringReader(data));

            string xmlPathPattern = "//spawner/object";
            XmlNodeList myNodeList = xmldoc.SelectNodes(xmlPathPattern);
            foreach (XmlNode node in myNodeList)
            {
                XmlNode id = node.FirstChild;
                XmlNode name = id.NextSibling;
                XmlNode x = name.NextSibling;
                XmlNode y = x.NextSibling;
                XmlNode z = y.NextSibling;

                whereToSpawn.x = float.Parse(x.InnerXml);
                whereToSpawn.y = float.Parse(y.InnerXml);
                whereToSpawn.z = float.Parse(z.InnerXml);

                Instantiate(arrayOfObj[int.Parse(id.InnerXml)], whereToSpawn, Quaternion.identity);
            }
        }
        else
        {
            for (int i = 0; i < arrayOfObj.Count; i++)
            {

                RandX = Random.Range(downLeft.transform.position.x, upRight.transform.position.x);
                RandZ = Random.Range(downLeft.transform.position.z, upRight.transform.position.z);
                whereToSpawn.x = RandX;
                whereToSpawn.y = 0.5f;
                whereToSpawn.z = RandZ;
                Instantiate(arrayOfObj[i], whereToSpawn, Quaternion.identity);
            }
        }
    }
}
