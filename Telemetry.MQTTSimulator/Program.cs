// See https://aka.ms/new-console-template for more information

using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using System.Text;
using Telemetry.MQTTService;

var mqttFactory = new MqttFactory();
IMqttClient client = mqttFactory.CreateMqttClient();
var options = new MqttClientOptionsBuilder()
    .WithClientId(Guid.NewGuid().ToString())
    .WithTcpServer("test.mosquitto.org", 1883)
    .WithCleanSession()
    .Build();

var eventManager = new EventHandlerManager();

client.ConnectedAsync += eventManager.OnConnectionCompleted;
client.DisconnectedAsync += eventManager.OnDisconnectedSuccessful;

await client.ConnectAsync(options);
if (!client.IsConnected) eventManager.OnConnectionFailed();

while (true)
{
    // compose message
    var id = Random.Shared.Next(100);
    string text = $"[ID = {id}] Message composed to simulate the behaviour of an MQTT message exchange between client and server";
    MqttApplicationMessage message = new MqttApplicationMessage
    {
        Topic = "mqtt.test",
        PayloadFormatIndicator = MqttPayloadFormatIndicator.CharacterData,
        Payload = Encoding.UTF8.GetBytes(text)
    };
    Console.WriteLine("Press a key to publish an MQTT message, or Q to quit!");
    var key = Console.ReadLine();
    if (key != null && key == "q")
    {
        await client.DisconnectAsync();
        Environment.Exit(0);
    }
    else
    {   
        if(client.IsConnected) await client.PublishAsync(message);
        else Console.WriteLine("Error: the client seems to be disconnected.");
    }
}

