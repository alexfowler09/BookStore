namespace BookStore.Application.Notifications
{
    public class ServiceNotification
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public ServiceNotification(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
