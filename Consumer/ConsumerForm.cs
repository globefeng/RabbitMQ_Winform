using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Consumer
{
    public delegate void MyDelegate(string myString);

    public partial class ConsumerForm : Form
    {
        private IConnection connection;
        private IModel channel;
        private EventingBasicConsumer consumer;
        private bool initialized = false;

        public ConsumerForm()
        {
            InitializeComponent();
        }

        public void DelegateMethod(string myString)
        {
            if (string.IsNullOrEmpty(this.tbxMessage.Text))
            {
                this.tbxMessage.Text = myString;
            }
            else
            {
                this.tbxMessage.Text += "\r\n" + myString;
            }
        }

        private void ConsumerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (initialized)
            {
                channel.Close();
                channel.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!initialized)
            {
                var factory = new ConnectionFactory { HostName = "localhost" };
                connection = factory.CreateConnection();
                channel = connection.CreateModel();
                consumer = new EventingBasicConsumer(channel);
                channel.QueueDeclare(queue: "queue1",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);
                channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                consumer.Received += OnNewMessageReceived;
                channel.BasicConsume(queue: "queue1",
                                     autoAck: false,
                                     consumer: consumer);

                initialized = true;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (initialized)
            {
                channel.Close();
                channel.Dispose();
                connection.Close();
                connection.Dispose();

                consumer.Received -= OnNewMessageReceived;
                this.tbxMessage.Text = "";
                initialized = false;
            }
        }
   
        private void OnNewMessageReceived(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            this.tbxMessage.BeginInvoke(new MyDelegate(DelegateMethod), new object[] { message });
            Thread.Sleep(5000);

            channel.BasicAck(deliveryTag: e.DeliveryTag, multiple: false);
        }    
    }
}
