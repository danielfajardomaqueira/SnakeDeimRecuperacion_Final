using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class LevelGrid2
{
    private Vector2Int foodGridPosition;
    private GameObject foodGameObject;

    private Vector2Int powerUpShieldGridPosition;
    private GameObject powerUpShieldGameObject;

    public bool powerUpShield;

    private int width;
    private int height;

    private Snake2 snake;
    


    private void Start()
    {
        powerUpShield = false;
        
    }

    public LevelGrid2(int w, int h)
    {
        width = w;
        height = h;
    }

   
    public void Setup(Snake2 snake)
    {
        this.snake = snake;
        SpawnFood();
        

    }
    /// <summary>
    /// It makes a fruit appear, and once the fruit is eaten the powerUp appears
    /// </summary>
    /// <param name="snakeGridPosition">Saves the position of the snake's head</param>
    /// <returns>True; like fruit and shield appears. False; so that the shield does not appear again if I already have it activated</returns>
    public bool TrySnakeEatFood(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == foodGridPosition)
        {

            Object.Destroy(foodGameObject);
            SpawnFood();
            if(snake.shieldActivated == false && powerUpShield == false)
            {
                SpawnPowerUpShield();
                powerUpShield = true;

            }
            Score.AddScore(Score.POINTS);
            //Debug.Log(GameManager.Instance.GetScore());
            return true;
        }
        else
        {
            return false;
        }


    }

    /// <summary>
    /// Check if the snake has eaten the PowerUP. If the position of the head is the same as that of the PowerUp.
    /// </summary>
    /// <param name="snakeGridPosition">Position of the snake's head</param>
    /// <returns>true to activate the powerup, false if it does not have it</returns>
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
        SpriteRenderer foodSpriteRenderer = foodGameObject.AddComponent<SpriteRenderer>();
        foodSpriteRenderer.sprite = GameAssets2.Instance.foodSprite;
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y, 0);

    }

    /// <summary>
    /// Code to make the powerUp appear.
    /// </summary>
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
        powerUpShieldSpriteRenderer.sprite = GameAssets2.Instance.powerUpShield;
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
