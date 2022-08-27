using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGrid
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;


    public MyGrid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                CreateWorldText(null, gridArray[x,y].ToString(), 
                GetworldPosition(x,y)+ new Vector3(cellSize,0,cellSize)*.5f,20,Color.white, TextAnchor.MiddleCenter,
                TextAlignment.Left,5000);
                Debug.DrawLine(GetworldPosition(x, y), GetworldPosition(x, y + 1),Color.white,100f);
                Debug.DrawLine(GetworldPosition(x, y), GetworldPosition(x+1, y),Color.white, 100f);
            }
        }

        Debug.DrawLine(GetworldPosition(0, height), GetworldPosition(width,height), Color.white, 100f);
        Debug.DrawLine(GetworldPosition(width, 0), GetworldPosition(width,height), Color.white, 100f);

    }

    private Vector3 GetworldPosition(int x, int y)
    {
        return new Vector3(x,0,y) * cellSize;
    }

    public void setValue(int x, int y, int f)
    {
        if (x >= 0 && y>=0 && x < width && y < height)
        {
            gridArray[x, y]= f;
        }
    }


     public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        transform.localEulerAngles = new Vector3(90, 0, 0);
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }
 

}
