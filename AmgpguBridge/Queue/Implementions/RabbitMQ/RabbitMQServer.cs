using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace AmgpguBridge.Queue.Implementions;
public class RabbitMQServer : IDisposable
{
  private ConnectionFactory _connectionFactory;
  private IConnection _connection;
  private IModel _channel;
  private string[] _queuesName;

  public RabbitMQServer(string host, string[] queuesName)
  {
    this._connectionFactory = new ConnectionFactory() { HostName = host };
    this._queuesName = queuesName;

    this.EstablishConnection();
    this.OpenChanel();
    this.QueuesDeclare();
  }

  private void EstablishConnection()
  {
    this._connection = this._connectionFactory.CreateConnection();
  }
  private void OpenChanel()
  {
    this._channel = this._connection.CreateModel();
  }

  private void QueuesDeclare()
  {
    foreach (var queueName in this._queuesName)
    {
      this._channel.QueueDeclare(
        queueName,
        true,
        false,
        false,
        null
      );
    }
  }

  private EventingBasicConsumer ConsumerDeclare()
  {
    throw new System.NotImplementedException();
    // this.CheckConnection();
    // var consumer = new EventingBasicConsumer(this._channel);
    // consumer.Received += (sender, ea) => {
    //   var body = ea.Body.ToArray();
    //   var message = Encoding.UTF8.GetString(body);
    //   
    // }
  }

  private bool IsConnectionOpened()
  {
    return this._connection.IsOpen;
  }

  private bool IsChannelOpened()
  {
    return this._channel.IsOpen;
  }

  public void CheckConnection()
  {
    if (!this.IsConnectionOpened())
    {
      this.EstablishConnection();
    }

    if (!this.IsChannelOpened())
    {
      this.OpenChanel();
      this.QueuesDeclare();
    }
  }

  public void SendMessage()
  {

  }


  public void Dispose()
  {
    if (this.IsChannelOpened())
    {
      this._channel.Close();
    }

    if (this.IsConnectionOpened())
    {
      this._connection.Close();
    }
  }

  ~RabbitMQServer()
  {
    this.Dispose();
  }
}
