using MongoDB.Bson.Serialization.Attributes;

namespace DBLib
{
    public class Mission
    {
        [BsonId]
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string ParentID { get; set; } = "";
        public List<string> SubID { get; set; } = new List<string>();
        public string Title { get; set; } = "空任务";
        public string Description { get; set; } = "";
        public string Brief { get; set; } = "";
        public string Comment { get; set; } = "";
        public DateTime StartTime { get; set; }
        public DateTime DeadlineTime { get; set; }
        public DateTime FinishTime { get; set; }
    }
}