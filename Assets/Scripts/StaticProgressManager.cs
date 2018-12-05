using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public static class StaticProgressManager {

    // Global value for collected parts percentage, going from 0 to 100
    private static float TotalCompletionPercentage = 0f;
    // Amount of levels for updating total completion rate
    private static readonly int LevelQuantity = 3;

    // Event for progress-based changes
    public static UnityEvent onUpdate = new UnityEvent();

	public static float GetCompletion () {
        return TotalCompletionPercentage * 100f;
	}

    public static void SetCompletion (float NewValue) {
        TotalCompletionPercentage = NewValue;
        onUpdate.Invoke();
    }
    
    public static void UpdateCompletion (float IncrementValue) {
        TotalCompletionPercentage += (IncrementValue / LevelQuantity);
        Debug.Log("Completion updated to " + TotalCompletionPercentage * 100f + "%");
        onUpdate.Invoke();
    }
}
