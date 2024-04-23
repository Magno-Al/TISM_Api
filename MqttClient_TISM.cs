using Microsoft.AspNetCore.Mvc.Formatters;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace TISM_Api
{
    public class MqttClient_TISM
    {
        private MqttClient mqttClient;

        private static Sensors? _sensors;
        public static Sensors Sensors
        {
            get { return _sensors ?? (_sensors = new Sensors(-1)); }
            private set { _sensors = value; }
        }

        public MqttClient_TISM()
        {
            mqttClient = new MqttClient("test.mosquitto.org");

            mqttClient.MqttMsgPublishReceived += Client_MqttCallBack;

            string clientId = Guid.NewGuid().ToString();
            mqttClient.Connect(clientId);
        }

        public void PublishMessage(string topic, string message)
        {
            mqttClient.Publish(topic, System.Text.Encoding.UTF8.GetBytes(message));
        }

        public void SubscribeToTopic(string topic)
        {
            mqttClient.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
        }

        private void Client_MqttCallBack(object sender, MqttMsgPublishEventArgs e)
        {
            string message = System.Text.Encoding.UTF8.GetString(e.Message);
            Console.WriteLine($"Mensagem recebida no tópico '{e.Topic}': {message}");

            Sensors.TemperatureC = Int32.Parse(message);
        }
    }
}
