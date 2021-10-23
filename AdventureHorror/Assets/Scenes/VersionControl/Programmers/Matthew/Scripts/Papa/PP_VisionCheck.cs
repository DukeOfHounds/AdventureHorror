using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PP_VisionCheck
{
    private PapaData papaData;
    private Papa papa;    
    private List<GameObject> Objects 
    { 
        get
        {
            objects.RemoveAll(obj => !obj);
            return objects;
        }
    }

    private List<GameObject> objects = new List<GameObject>();
    Collider[] colliders = new Collider[50];
    
    int count;
    float scanInterval;
    float scanTimer;

    public PP_VisionCheck(PapaData papaData, Papa papa)
    {
        this.papaData = papaData;
        this.papa = papa;
    }

    Mesh Mesh;

    void OnEnable()
    {
        scanInterval = 1.0f / papaData.scanFrequency;
    }


    public void HandleScanning()
    {
        scanTimer -= Time.deltaTime;
        if (scanTimer < 0)
        {
            scanTimer += scanInterval;
            Scan();
        }
    }





    private void Scan()
    {
        count = Physics.OverlapSphereNonAlloc(papa.transform.position, papaData.distance, colliders, papaData.layers, QueryTriggerInteraction.Collide);

        objects.Clear();
        for (int i = 0; i < count; ++i)
        {
            GameObject obj = colliders[i].gameObject;
            if(IsInSight(obj))
            {
                objects.Add(obj);
            }
        }
    }

    public bool IsInSight(GameObject obj)
    {
        Vector3 origin = papa.transform.position;
        Vector3 target = obj.transform.position;
        Vector3 direction = target - origin;
        
        direction.y = 0;
        float deltaAngle = Vector3.Angle(direction, papa.transform.forward);
        
        if (direction.y < 0 || direction.y > papaData.height)
        {
            return false;
        }

        origin.y += papaData.height / 2;
        target.y = origin.y;
        if (Physics.Linecast(origin, target, papaData.occlusionLayers))
            return false;
        
        return true;
    }
    Mesh CreateWedgeMesh()
    {
        Mesh mesh = new Mesh();

        int segments = 10;
        int numTriangles = (segments * 4) + 2 +2;
        int numVertices = numTriangles * 3;

        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numVertices];

        Vector3 bottomCenter = Vector3.zero;
        Vector3 bottomLeft = Quaternion.Euler(0, -papaData.angle, 0) * Vector3.forward * papaData.distance;
        Vector3 bottomRight = Quaternion.Euler(0, -papaData.angle, 0) * Vector3.forward * papaData.distance;

        Vector3 topCenter = bottomCenter + Vector3.up * papaData.height;
        Vector3 topRight = bottomRight + Vector3.up * papaData.height;
        Vector3 topLeft = bottomLeft + Vector3.up * papaData.height;

        int vert = 0;

        //left side
        vertices[vert++] = bottomCenter;
        vertices[vert++] = bottomLeft;
        vertices[vert++] = topLeft;

        vertices[vert++] = topLeft;
        vertices[vert++] = topCenter;
        vertices[vert++] = bottomCenter;

        //right side
        vertices[vert++] = bottomCenter;
        vertices[vert++] = topCenter;
        vertices[vert++] = topRight;

        vertices[vert++] = topRight;
        vertices[vert++] = bottomRight;
        vertices[vert++] = bottomCenter;

        float currentAngle = -papaData.angle;
        float deltaAngle = (papaData.angle * 2) / segments;
        
        for(int i = 0; i < segments; ++i)
        {
            bottomLeft = Quaternion.Euler(0, currentAngle, 0) * Vector3.forward * papaData.distance;
            bottomRight = Quaternion.Euler(0, currentAngle + deltaAngle, 0) * Vector3.forward * papaData.distance;

            topRight = bottomRight + Vector3.up * papaData.height;
            topLeft = bottomLeft + Vector3.up * papaData.height;

            //far side
            vertices[vert++] = bottomLeft;
            vertices[vert++] = bottomRight;
            vertices[vert++] = topRight;

            vertices[vert++] = topRight;
            vertices[vert++] = topLeft;
            vertices[vert++] = bottomLeft;

            //top
            vertices[vert++] = topCenter;
            vertices[vert++] = topLeft;
            vertices[vert++] = topRight;

            //bottom
            vertices[vert++] = bottomCenter;
            vertices[vert++] = bottomRight;
            vertices[vert++] = bottomLeft;

            currentAngle += deltaAngle;
        }
        

        for(int i = 0; i < numVertices; i++)
        {
            triangles[i] = i;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }

    private void OnValidate()
    {
        Mesh = CreateWedgeMesh();
        scanInterval = 1.0f / papaData.scanFrequency;
    }

    private void OnDrawGizmos()
    {
        if(Mesh)
        {
            Gizmos.color = papaData.wedgeColor;
            Gizmos.DrawMesh(Mesh, papa.transform.position, papa.transform.rotation);
        }

        Gizmos.DrawSphere(papa.transform.position, papaData.distance);
        for(int i = 0; i < count; ++i)
        {
            Gizmos.DrawSphere(colliders[i].transform.position, 0.2f);
        }

        Gizmos.color = Color.green;
        foreach (var obj in Objects)
        {
            Gizmos.DrawSphere(obj.transform.position, 0.2f);
        }
    }
}
