public class PlayerController : IPlayerController
{
    private const int _turnDurationTicks = 100000;
    private int _ticksSinceTurnStart;

    public bool IsCurrentTurn { get; set; }

    public int Id { get; private set; }

    public bool IsReady { get; set; }

    public void Initialize(int playerId)
    {
        Id = playerId;
    }

    public void SimulationStep()
    {
        _ticksSinceTurnStart++;

        if (_ticksSinceTurnStart >= _turnDurationTicks)
            CompleteTurn();
    }

    public void MovePlayer()
    {

    }

    public void SetBorder()
    {

    }

    public void StartTurn()
    {
        IsCurrentTurn = true;
        _ticksSinceTurnStart = 0;
    }

    public void CompleteTurn()
    {
        IsCurrentTurn = false;
    }
}
