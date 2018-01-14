using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFieldOfView : MonoBehaviour {

    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask obstacleMask;
    public float meshResolution;

    public float maskCutawayDst = 0.2f;

    public MeshFilter viewMeshFilter;
    public MeshRenderer viewMeshRenderer;
    Mesh viewMesh;

    void Start() {
        viewMesh = new Mesh();
        viewMesh.name = "ViewMesh";
        viewMeshFilter.mesh = viewMesh;
        viewMeshRenderer.sortingLayerName = "FieldOfView";
        viewMeshRenderer.sortingOrder = 0;
    }

    public void DrawFieldOfView() {
        int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);
        float stepAngleSize = viewAngle / stepCount;
        List<Vector3> viewPoints = new List<Vector3>();

        for (int i = 0; i <= stepCount; ++i) {
            float angle  = GetComponent<Rigidbody2D>().rotation - viewAngle/2f + stepAngleSize * i;
            var newViewCast = ViewCast(angle);
            viewPoints.Add(newViewCast.point);
        }

        int vertexCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount-2) * 3];

        vertices[0] = Vector3.zero;
        for (int i = 0; i < vertexCount - 1; ++i) {
            vertices[i+1] = transform.InverseTransformPoint(viewPoints[i]) + Vector3.right * maskCutawayDst;
            if (i < vertexCount - 2) {
                triangles[i*3] = 0;
                triangles[i*3 + 1] = i + 1;
                triangles[i*3 + 2] = i + 2;
            }
        }
        viewMesh.Clear();
        viewMesh.vertices = vertices;
        viewMesh.triangles = triangles;
        viewMesh.RecalculateNormals();
    }

    ViewCastInfo ViewCast(float globalAngle) {
        Vector2 dir = DirFromAngle(globalAngle, globalAngle:true);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, viewRadius, obstacleMask);
        if (hit)
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
        return new ViewCastInfo(false, (Vector2)transform.position + dir * viewRadius, viewRadius, globalAngle);
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool globalAngle=false) {
        if (!globalAngle)
            angleInDegrees += transform.eulerAngles.z;
        return new Vector3(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Sin(angleInDegrees*Mathf.Deg2Rad), 0);
    }

    public struct ViewCastInfo {
        public bool hit;
        public Vector3 point;
        public float distance;
        public float angle;

        public ViewCastInfo(bool hit, Vector3 point, float distance, float angle) {
            this.hit = hit;
            this.point = point;
            this.distance = distance;
            this.angle = angle;
        }
    }
}
