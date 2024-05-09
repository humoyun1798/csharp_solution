using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://blog.csdn.net/weixin_45767204/article/details/130124737


            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("test");
            var collection = database.GetCollection<BsonDocument>("A");

            var document = new BsonDocument
                            {
                                { "name", "John Doe" },
                                { "age", 30 },
                                { "city", "New York" }
                            };

            collection.InsertOne(document);

            var filter = Builders<BsonDocument>.Filter.Eq("name", "John Doe");
            var result = collection.Find(filter).FirstOrDefault();

            Console.WriteLine(result.ToJson());

        }
    }
}