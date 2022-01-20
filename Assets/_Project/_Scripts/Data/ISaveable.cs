public interface ISaveable
{
    object CaptureData();
    void RestoreData(object state);
}