using MongoDB.Driver;

using System.Collections.Generic;

namespace DBLib
{
    public class MongoService
    {
        public MongoService()
        {
            Client = new MongoClient("mongodb://psAdmin:psAdmin123@maolib.com/pinksleeve");
            db = Client.GetDatabase("pinksleeve");
        }
        public MongoClient Client { get; set; }
        public IMongoDatabase db { get; set; }

        public List<Mission> ListRootMissons(int offset = 0, int limit = 10)
        {
            IMongoCollection<Mission> collection = db.GetCollection<Mission>("Mission");
            return collection.Find(x => x.ParentID == "").Skip(offset).Limit(limit).ToList();
        }
        public Mission GetMission(string id)
        {
            IMongoCollection<Mission> collection = db.GetCollection<Mission>("Mission");
            return collection.Find(x => x.ID.Equals(id)).FirstOrDefault();
        }
        public void AddMission(Mission doc)
        {
            IMongoCollection<Mission> collection = db.GetCollection<Mission>("Mission");
            collection.InsertOne(doc);
        }
        public void UpdateMission(Mission doc)
        {
            IMongoCollection<Mission> collection = db.GetCollection<Mission>("Mission");

            collection.ReplaceOne(x => x.ID.Equals(doc.ID), doc, new ReplaceOptions()
            {
                IsUpsert = true
            });
        }
    }
}