// See https://aka.ms/new-console-template for more information

using MQTTnet.Client;
using MQTTnet;
using Telemetry.MQTTService;

var mqttFactory = new MqttFactory();
IMqttClient client = mqttFactory.CreateMqttClient();
var options = new MqttClientOptionsBuilder()
    .WithClientId(Guid.NewGuid().ToString())
    .WithTcpServer("test.mosquitto.org", 1883)
    .WithCleanSession()
    .Build();

var topicFilter = new MqttTopicFilterBuilder()
    .WithTopic("mqtt.test")
    .Build();

var eventManager = new EventHandlerManager();
client.ConnectedAsync += eventManager.OnConnectionCompleted;
client.DisconnectedAsync += eventManager.OnDisconnectedSuccessful;
client.ApplicationMessageReceivedAsync += eventManager.OnMessageReceived;

await client.ConnectAsync(options);
if (!client.IsConnected) eventManager.OnConnectionFailed();

await client.SubscribeAsync(topicFilter);

var startTimeSpan = TimeSpan.Zero;
var periodTimeSpan = TimeSpan.FromSeconds(15);
var timer = new Timer((e) =>
{
    Console.WriteLine("Waiting for published messages...");
}, null, startTimeSpan, periodTimeSpan);

while (true)
{ }


