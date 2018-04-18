public interface IMissionController
{
    int SuccessMissionCounter { get; }

    int FailedMissionCounter { get; }

    string PerformMission(IMission mission);

    void FailMissionsOnHold();
}