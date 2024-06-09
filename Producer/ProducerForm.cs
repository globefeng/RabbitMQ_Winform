using RabbitMQ.Client;
using System;
using System.Text;
using System.Windows.Forms;

namespace Producer
{
    public partial class ProducerForm : Form
    {
        private IConnection connection;
        private IModel channel;

        public ProducerForm()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            channel.QueueDeclare(queue: this.tbxQueue.Text,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(this.tbxMessage.Text);

            channel.BasicPublish(exchange: "",
                                 routingKey: this.tbxQueue.Text,
                                 basicProperties: null,
                                 body: body);
        }

        private void ProducerForm_Load(object sender, EventArgs e)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
        }

        private void ProducerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            channel.Close();
            channel.Dispose();
            connection.Close();
            connection.Dispose();
        }
    }
}
