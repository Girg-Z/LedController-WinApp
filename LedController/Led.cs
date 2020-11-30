using System;
using System.Drawing;
using uPLibrary.Networking.M2Mqtt;

namespace LedController
{
    class Led
    {
        private MqttClient client;

        public Led()
        {
            // create client instance 
            client = new MqttClient("example.com");
            this.connect();
        }

        private void connect()
        {
            if (!client.IsConnected)
            {
                string clientId = Guid.NewGuid().ToString();
                client.Connect(clientId, "user", "password");
            }
        }

        public void disconnect()
        {
            if (client.IsConnected)
            {
                client.Disconnect();
            }
        }

        public void fillSolid(Color color)
        {
            // TODO: Ricontrolla connessione
            String command = "702:" + color.R.ToString("D3") + "," + color.G.ToString("D3") + "," + color.B.ToString("D3");
            client.Publish("/led_scrivania/commands", System.Text.Encoding.UTF8.GetBytes(command));
        }

        public void turnOff()
        {
            String command = "701:000,000,000";
            client.Publish("/led_scrivania/commands", System.Text.Encoding.UTF8.GetBytes(command));
            // this.disconnect(); Tolto per corretto spegimento a SessionEnded
        }
    }
}
