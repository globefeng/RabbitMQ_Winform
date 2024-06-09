using RabbitMQ.Client;
using System;
using System.Text;
using System.Windows.Forms;

namespace Publisher
{
    public partial class PublisherForm : Form
    {
        private IConnection connection;
        private IModel channel;

        public PublisherForm()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            channel.ExchangeDeclare(exchange: this.tbxExchange.Text, type: ExchangeType.Fanout);

            var body = Encoding.UTF8.GetBytes(this.tbxMessage.Text);

            channel.BasicPublish(exchange: this.tbxExchange.Text,
                                 routingKey: string.Empty,
                                 basicProperties: null,
                                 body: body);
        }

        private void PublisherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            channel.Close();
            channel.Dispose();
            connection.Close();
            connection.Dispose();
        }

        private void PublisherForm_Load(object sender, EventArgs e)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
        }
    }
}
