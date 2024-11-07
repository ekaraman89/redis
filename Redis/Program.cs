using StackExchange.Redis;

Console.WriteLine("Hello, World!");

var redis = await ConnectionMultiplexer.ConnectAsync("localhost");
var db = redis.GetDatabase();
var subscriber = redis.GetSubscriber();

await subscriber.SubscribeAsync("__keyspace@0__:test", async (channel, key) =>
{
    Console.WriteLine($"channel: {channel}, Anahtar değişti: {key}");
    
    // var value = await db.StringGetAsync(new RedisKey(key));
    // Console.WriteLine($"Anahtarın değeri: {value}");
});

Console.WriteLine("Redis değişikliklerini dinliyorum...");
Console.ReadLine(); 