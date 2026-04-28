using UnityEngine;

/// <summary>
/// Renders a visual rope line between two players using a LineRenderer.
/// The rope color changes from green to red as the distance approaches the maximum.
/// </summary>
public class RopeRenderer : MonoBehaviour
{
    public CharacterController player1;
    public CharacterController player2;
    public int maxDist = 20;
    public Color colorNear = new Color(0.5f, 0f, 0f, 1f);
    public Color colorFar = new Color(0f, 0.5f, 0f, 1f);
    public Color colorTaut = new Color(0f, 0.5f, 0f, 1f);

    private Vector3[] _characterPositions = { new Vector3(), new Vector3() };
    private LineRenderer _ropeRenderer;

    private void Start()
    {
        _ropeRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        _characterPositions[0] = player1.transform.position;
        _characterPositions[1] = player2.transform.position;
        _ropeRenderer.SetPositions(_characterPositions);

        float distance = Vector3.Distance(player1.transform.position, player2.transform.position);
        float alpha = distance / maxDist;

        Color ropeColor = (maxDist - distance < 0.1f)
            ? colorTaut
            : Color.Lerp(colorNear, colorFar, alpha);

        _ropeRenderer.material.color = ropeColor;
    }
}
