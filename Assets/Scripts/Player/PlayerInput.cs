using UnityEngine;

public sealed class PlayerInput : MonoBehaviour
{
    private float _deceleration = 30f;

    private readonly float _directionMultiplier = 1f;
    private Vector2 _touchStartPosition;

    public float GetInputDirection()
    {
        float inputDirection = Input.touchCount > 0
            ? Mathf.Clamp((Input.GetTouch(0).position.x - _touchStartPosition.x) / Screen.width, -_directionMultiplier, _directionMultiplier)
            : (Input.GetKey(KeyCode.A) ? -_directionMultiplier : Input.GetKey(KeyCode.D) ? _directionMultiplier : 0f);

        return Mathf.MoveTowards(inputDirection, 0f, _deceleration * Time.deltaTime);
    }
}