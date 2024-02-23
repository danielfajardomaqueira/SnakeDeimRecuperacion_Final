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
    /// Hace aparecer una fruta, y una vez comida la fruta aparece el powerUp
    /// </summary>
    /// <param name="snakeGridPosition">Guarda la posicion en la que se encuentra la cabeza de la serpiente</param>
    /// <returns>True; como fruta y aparece escudo. False; para que escudo no aparezca otra vez si ya lo tengo activado</returns>
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
    /// Comprueba si la serpiente se ha comido el PowerUP. Si la posicion de la cabeza es igual al del PowerUp.
    /// </summary>
    /// <param name="snakeGridPosition">Posicion en la que esta la cabeza de la serpiente</param>
    /// <returns>true para activar el powerup, false si no lo tiene</returns>
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
    /// Codigo para hacer aparecer el powerUp.
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
