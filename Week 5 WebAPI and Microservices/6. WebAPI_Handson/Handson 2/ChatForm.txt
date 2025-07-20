using System;
using System.Windows.Forms;
using Confluent.Kafka;
using System.Threading;
using System.Threading.Tasks;

namespace kafkaChatWinApp
{
    public partial class ChatForm : Form
    {
        private readonly string topic = "chat-topic";
        private readonly string bootstrapServers = "localhost:9092";
        private IConsumer<Ignore, string> consumer;
        private CancellationTokenSource cts;

        public ChatForm()
        {
            InitializeComponent();
            StartConsumer(); 
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var user = txtUser.Text.Trim();
            var msg = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(msg)) return;

            Task.Run(() =>
            {
                var config = new ProducerConfig { BootstrapServers = bootstrapServers };

                using (var producer = new ProducerBuilder<Null, string>(config).Build())
                {
                    producer.Produce(topic, new Message<Null, string> { Value = $"[{user}]: {msg}" });

                    Invoke(new Action(() =>
                    {
                        lstChat.Items.Add($"You: {msg}");
                        txtMessage.Clear();
                    }));
                }
            });
        }

        private void StartConsumer()
        {
            Task.Run(() =>
            {
                var config = new ConsumerConfig
                {
                    GroupId = Guid.NewGuid().ToString(), 
                    BootstrapServers = bootstrapServers,
                    AutoOffsetReset = AutoOffsetReset.Earliest
                };

                consumer = new ConsumerBuilder<Ignore, string>(config).Build();
                consumer.Subscribe(topic);

                cts = new CancellationTokenSource();

                try
                {
                    while (!cts.Token.IsCancellationRequested)
                    {
                        var cr = consumer.Consume(cts.Token);
                        Invoke(new Action(() =>
                        {
                            lstChat.Items.Add(cr.Message.Value);
                        }));
                    }
                }
                catch (OperationCanceledException)
                {
                    consumer.Close();
                }
            });
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (cts != null)
            {
                cts.Cancel();
            }
        }
    }
}
