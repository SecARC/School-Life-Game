using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuGrid : MonoBehaviour
{
    public int columns = 0;
    public int rows = 0;
    public float square_offset = 0.0f;
    public GameObject grid_square;
    public Vector2 start_position = new Vector2(0.0f, 0.0f);
    public float square_scale = 1.0f;
    public float square_gap = 0.1f;
    public Color line_highlight_color = Color.red;

    private List<GameObject> grid_squares_ = new List<GameObject>();
    private int selected_grid_data = -1;

    void Start()
    {
        if (grid_square.GetComponent<GridSquare>() == null)
            Debug.LogError("This Game Object need to have GridSquare script attached !");

        CreateGrid();     
        SetGridNumber(GameSettings.Instance.GetGameMode());
    }

    private void SetGridNumber(string level)
    {
        selected_grid_data = UnityEngine.Random.Range(0, SudokuData.Instance.sudoku_game[level].Count);
        var data = SudokuData.Instance.sudoku_game[level][selected_grid_data];

        SetGridSquareData(data);

        //foreach (var squares in grid_squares_)
        //{
        //    squares.GetComponent<GridSquare>().SetNumber(UnityEngine.Random.Range(0, 10));
        //}
    }

    private void SetGridSquareData(SudokuData.SudokuBoardData data)
    {
        for(int index = 0; index < grid_squares_.Count; index++)
        {
            grid_squares_[index].GetComponent<GridSquare>().SetNumber(data.unsolved_data[index]);
            grid_squares_[index].GetComponent<GridSquare>().SetCorrectNumber(data.solved_data[index]);
            grid_squares_[index].GetComponent<GridSquare>().SetHasDefaultValue(data.unsolved_data[index] != 0 && data.unsolved_data[index] == data.solved_data[index]);
        }
    }

    private void CreateGrid()
    {
        SpawnGridSquares();
        SetSquaresPosition();
    }

    private void SetSquaresPosition()
    {
        var square_rect = grid_squares_[0].GetComponent<RectTransform>();
        Vector2 offset = new Vector2();
        Vector2 square_gap_number = new Vector2(0.0f, 0.0f);
        bool row_moved = false;

        offset.x = square_rect.rect.width * square_rect.transform.localScale.x + square_offset;
        offset.y = square_rect.rect.height * square_rect.transform.localScale.y + square_offset;

        int column_number = 0;
        int row_number = 0;

        foreach (GameObject square in grid_squares_)
        {
            if(column_number +1 > columns)
            {
                row_number++;
                column_number = 0;
                square_gap_number.x = 0;
                row_moved = false;
            }

            var pos_x_offset = offset.x * column_number + (square_gap_number.x * square_gap);
            var pos_y_offset = offset.y * row_number + (square_gap_number.y * square_gap);

            if(column_number > 0 && column_number % 3 == 0)
            {
                square_gap_number.x++;
                pos_x_offset += square_gap;
            }
            if(row_number >0 && row_number % 3 == 0 && row_moved == false)
            {
                row_moved = true;
                square_gap_number.y++;
                pos_y_offset += square_gap;
            }

            square.GetComponent<RectTransform>().anchoredPosition = new Vector2(start_position.x + pos_x_offset, start_position.y - pos_y_offset);
            column_number++;
        }
    }

    private void SpawnGridSquares()
    {
        //0, 1, 2, 3, 4, 5, 6,
        //7, 8, ...
        int square_index = 0;

        for(int row = 0; row < rows; row++)
        {
            for(int column = 0; column < columns; column++)
            {
                grid_squares_.Add(Instantiate(grid_square) as GameObject);
                grid_squares_[grid_squares_.Count - 1].GetComponent<GridSquare>().SetSquareIndex(square_index);
                grid_squares_[grid_squares_.Count -1].transform.parent = this.transform; //Instantiate this game object as a child of the object holding this script.
                grid_squares_[grid_squares_.Count -1].transform.localScale = new Vector3(square_scale, square_scale, square_scale);

                square_index++;
            }
        }
    }

    private void OnEnable()
    {
        GameEvents.OnSquareSelected += OnSquareSelected;
        GameEvents.OnUpdateSquareNumber += CheckBoardCompleted;
    }

    private void OnDisable()
    {
        GameEvents.OnSquareSelected -= OnSquareSelected;
        GameEvents.OnUpdateSquareNumber -= CheckBoardCompleted;
    }

    private void SetSquaresColor(int[] data, Color col)
    {
        foreach (var index in data)
        {
            var comp = grid_squares_[index].GetComponent<GridSquare>();
            if(comp.HasWrongValue() == false && comp.IsSelected() == false)
            {
                comp.SetSquareColor(col);
            }
        }
    }

    public void OnSquareSelected(int square_index)
    {
        var horizontal_line = LineIndicator.Instance.GetHorizontalLine(square_index);
        var vertical_line = LineIndicator.Instance.GetVerticalLine(square_index);
        var square = LineIndicator.Instance.GetSquare(square_index);

        SetSquaresColor(LineIndicator.Instance.GetAllSquaresIndexes(), Color.white);

        SetSquaresColor(horizontal_line, line_highlight_color);
        SetSquaresColor(vertical_line, line_highlight_color);
        SetSquaresColor(square, line_highlight_color);
    }

    public void CheckBoardCompleted(int number)
    {
        foreach (var square in grid_squares_)
        {
            var comp = square.GetComponent<GridSquare>();
            if (comp.IsCorrectNumberSet() == false)
                return;
        }
        GameEvents.OnBoardCompletedMethod();
    }

    public void SolveSudoku()
    {
        foreach (var square in grid_squares_)
        {
            var comp = square.GetComponent<GridSquare>();
            comp.SetCorrectNumber();
        }
        CheckBoardCompleted(0);
    }
}
