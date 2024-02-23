using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
public class LevelGrid
{
    private Vector2Int foodGridPosition;
    private GameObject foodGameObject;
    
    private int width;
    private int height;

    private Snake snake;

    private FoodScriptableObject foodScriptableObject;
    private int foodCount;

    private Vector2Int powerUpShieldGridPosition;
    private GameObject powerUpShieldGameObject;

    public bool powerUpShield;

    private void Start()
    {
        powerUpShield = false;

    }

    public LevelGrid(int w, int h)
    {
        width = w;
        height = h;
    }

    public void Setup(Snake snake)
    {
        this.snake = snake;
        SpawnFood();
    }

    public bool TrySnakeEatFood(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == foodGridPosition)
        {
            //Score.AddScore(Score.POINTS);
            Object.Destroy(foodGameObject);
            SpawnFood();
            if (snake.shieldActivated == false && powerUpShield == false)
            {
                SpawnPowerUpShield();
                powerUpShield = true;

            }
            Score.AddScore(foodScriptableObject.points);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TrySnakePowerUpShield(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == powerUpShieldGridPosition)
        {
            Object.Destroy(powerUpShieldGameObject);
            powerUpShield = true;

            return true;
        }

        else
        {
            return false;
        }
    }

    private void SpawnFood()
    {
        // while (condicion){
        // cosas
        // }
        
        // { cosas }
        // while (condicion)
        
        do
        {
            foodGridPosition = new Vector2Int(
                Random.Range(-width / 2, width / 2),
                Random.Range(-height / 2, height / 2));
        } while (snake.GetFullSnakeBodyGridPosition().IndexOf(foodGridPosition) != -1);
        
        foodGameObject = new GameObject("Food");

        foodCount = Random.Range(0, GameAssets.Instance.foodScriptableObjectsArray.Length);
        foodScriptableObject = GameAssets.Instance.foodScriptableObjectsArray[foodCount];

        SpriteRenderer foodSpriteRenderer = foodGameObject.AddComponent<SpriteRenderer>();
        foodSpriteRenderer.sprite = foodScriptableObject.sprite;
        //foodSpriteRenderer.sprite = GameAssets.Instance.foodSprite;
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y, 0);
        
    }

    private void SpawnPowerUpShield()
    {
        do
        {
            powerUpShieldGridPosition = new Vector2Int(
                Random.Range(-width / 2, width / 2),
                Random.Range(-height / 2, height / 2));
        } while (snake.GetFullSnakeBodyGridPosition().IndexOf(powerUpShieldGridPosition) != -1);

        powerUpShieldGameObject = new GameObject("PowerUpShield");
        SpriteRenderer powerUpShieldSpriteRenderer = powerUpShieldGameObject.AddComponent<SpriteRenderer>();
        powerUpShieldSpriteRenderer.sprite = GameAssets.Instance.powerUpShield;
        powerUpShieldGameObject.transform.position = new Vector3(powerUpShieldGridPosition.x, powerUpShieldGridPosition.y, 0);


    }

    public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
    {
        int w = Half(width);
        int h = Half(height);
        
        // Me salgo por la derecha
        if (gridPosition.x > w)
        {
            gridPosition.x = -w;
        }
        if (gridPosition.x < -w)
        {
            gridPosition.x = w;
        }
        if (gridPosition.y > h)
        {
            gridPosition.y = -h;
        }
        if (gridPosition.y < -h)
        {
            gridPosition.y = h;
        }

        return gridPosition;
    }

    private int Half(int number)
    {
        return number / 2;
    }
}
