using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {
    public GameObject prefabMatchUnit;

    float matchUnitPixelWidth = 100;
    float matchUnitPixelHeight = 100;
    float offSetEvenRows;

    Transform[,] matrixMatchUnits;

    int rows;
    int columns;

    Camera m_camera;

    private void Start()
    {
        offSetEvenRows = matchUnitPixelWidth / 2;

        m_camera = Camera.main;
        Vector2 cameraBoundsPixels = new Vector2(Screen.width, Screen.height);
        offSetEvenRows = 0.5f;

        Vector3 worldDimensions = Camera.main.ScreenToWorldPoint(new Vector3(cameraBoundsPixels.x, cameraBoundsPixels.y, 10));
        Debug.Log("World Dimensions " + worldDimensions);

        rows = (int)worldDimensions.x * 2;
        columns = (int)worldDimensions.y * 2;
        matrixMatchUnits = new Transform[rows, columns];
        generateMatrixGame();
    }

    void generateMatrixGame()
    {
        Vector2 pos = new Vector2(-rows/2, columns/2);
        for(int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                GameObject aux;
                if (i % 2 == 0)
                {
                    aux = Instantiate(prefabMatchUnit, pos + new Vector2((matchUnitPixelWidth * j) / matchUnitPixelWidth, -(matchUnitPixelHeight * i) / matchUnitPixelHeight), Quaternion.identity); aux.SetActive(true);
                    matrixMatchUnits[j, i] = aux.transform;
                }
                else if(i % 2 == 1 && j < rows - 1)
                {
                    aux = Instantiate(prefabMatchUnit, pos + new Vector2(offSetEvenRows + (matchUnitPixelWidth * j) / matchUnitPixelWidth, -(matchUnitPixelHeight * i) / matchUnitPixelHeight), Quaternion.identity); aux.SetActive(true);
                    matrixMatchUnits[j, i] = aux.transform;
                }
               
            }
        }
    }
}
