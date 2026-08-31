namespace PlateE_learning.Data
{
    public class ToastService
    {
        public event Action? OnChange;

        public List<ToastItem> Messages { get; } = new();

        public void ShowSuccess(string message)
        {
            Messages.Add(new ToastItem("success", message));
            NotifyStateChanged();
        }

        public void ShowError(string message)
        {
            Messages.Add(new ToastItem("danger", message));
            NotifyStateChanged();
        }

        public void ShowInfo(string message)
        {
            Messages.Add(new ToastItem("info", message));
            NotifyStateChanged();
        }

        public void Clear()
        {
            Messages.Clear();
            NotifyStateChanged();
        }

        public void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }

    public class ToastItem
    {
        public ToastItem(string type, string message)
        {
            Type = type;
            Message = message;
        }

        public string Type { get; set; }
        public string Message { get; set; }
    }
}
