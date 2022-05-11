using AmgpguBridge.Mapper.Facade;
using AmgpguBridge.Queue.Contracts;
using AmgpguBridge.SuperService.QueueStrategies;
using AmgpguBridge.University.Contracts;

namespace AmgpguBridge.SuperService;

public class Controller {
  private SuperService.Packing.PackerFactory _packerFactory;
  private SuperService.Loading.Loader _loader;

  private SuperService.QueueStrategies.QueueStrategyFactory _queueStrategyFactory;
  private SuperService.Contracts.ISerializer _superserviceSerializer;

  private IUniversityEntitySerializer _universityEntitySerializer;
  private IQueueMessageRepository _queueMessageRepository;
  private IQueueWriter _queueWriter;
  private IQueueMessageCreator _queueMessageCreator;

  public Controller(
    IQueueWriter queueWriter,
    IQueueMessageCreator queueMessageCreator,
    IQueueMessageRepository queueMessageRepository,
    IUniversityEntitySerializer universityEntitySerializer
  ) {
    this._packerFactory = new Packing.PackerFactory("", "");
    this._loader = null;
    // this._containerSerializer = new ContainerSerializer();
    this._queueStrategyFactory = new QueueStrategyFactory();
    this._superserviceSerializer = new JsonSerializer();

    this._universityEntitySerializer = universityEntitySerializer;
    this._queueMessageRepository = queueMessageRepository;
    this._queueWriter = queueWriter;
    this._queueMessageCreator = queueMessageCreator;
  }

  private TSEntity Map<TUEntity, TSEntity>(TUEntity universityEntity)
    where TUEntity : University.Entities.Entity
    where TSEntity : SuperService.Entities.Entity {
    return Mapping.Mapper.Map<TSEntity>(universityEntity);
  }

  private TUEntity UniverstityEntityDeserialize<TUEntity>(Queue.Contracts.IQueueMessage queueMessage)
    where TUEntity : University.Entities.Entity {
    return this._universityEntitySerializer.Deserialize<TUEntity>(queueMessage.Body);
  }

  public async Task NewEntity<TUEntity, TSEntity>(IQueueMessage queueMessage)
    where TSEntity : SuperService.Entities.Entity
    where TUEntity : University.Entities.Entity {
    var action = "api/token/new"; // todo fixme: magic words
    var universityEntity = this.UniverstityEntityDeserialize<TUEntity>(queueMessage);
    var superserviceEntity = this.Map<TUEntity, TSEntity>(universityEntity);
    var serializedSuperserviceEntity = this._superserviceSerializer.Serialize<TSEntity>(superserviceEntity);
    var jwtMessage = this._packerFactory
      .MakePacker(SuperServiceAction.Add, superserviceEntity).Pack();
    var response = await this._loader.Load(action, jwtMessage);
    var queueStrategy =
      this._queueStrategyFactory.MakeStrategy(SuperServiceStage.LoadEntity, response.GetResponseType());

    queueStrategy.MoveQueueMessage(
      serializedSuperserviceEntity,
      jwtMessage,
      response,
      this._superserviceSerializer,
      this._queueMessageCreator,
      this._queueWriter,
      queueMessage);
  }

  public async Task ChangeEntity<TUEntity, TSEntity>(Queue.Contracts.IQueueMessage queueMessage)
    where TUEntity : University.Entities.Entity
    where TSEntity : SuperService.Entities.Entity {
    var action = "api/token/new";
    var universityEntity = this.UniverstityEntityDeserialize<TUEntity>(queueMessage);
    var superserviceEntity = this.Map<TUEntity, TSEntity>(universityEntity);
    var serializedSuperserviceEntity = this._superserviceSerializer.Serialize<TSEntity>(superserviceEntity);
    var jwtMessage = this._packerFactory
      .MakePacker(SuperServiceAction.Edit, superserviceEntity).Pack();
    var response = await this._loader.Load(action, jwtMessage);
    var queueStrategy =
      this._queueStrategyFactory.MakeStrategy(SuperServiceStage.LoadEntity, response.GetResponseType());

    queueStrategy.MoveQueueMessage(
      serializedSuperserviceEntity,
      jwtMessage,
      response,
      this._superserviceSerializer,
      this._queueMessageCreator,
      this._queueWriter,
      queueMessage);
  }

  public async Task ReloadEntity(IQueueMessage queueMessage) {
    var action = "api/token/new";
    var container = this._superserviceSerializer.Deserialize<Container>(queueMessage.Body);
    var response = await this._loader.Load(action, container.JwtMessage);
    var queueStrategy =
      this._queueStrategyFactory.MakeStrategy(SuperServiceStage.LoadEntity, response.GetResponseType());

    queueStrategy.MoveQueueMessage(
      container.Entity,
      container.JwtMessage,
      response,
      this._superserviceSerializer,
      this._queueMessageCreator,
      this._queueWriter,
      queueMessage
    );
  }

  public async Task GetInfo(IQueueMessage queueMessage) {
    var action = "api/token/service/info";
    var container = this._superserviceSerializer.Deserialize<Container>(queueMessage.Body);
    var jwtMessage = this._packerFactory
      .MakePacker(SuperServiceAction.Info, container.IdJwt).Pack();
    var response = await this._loader.Load(action, jwtMessage);
    var queueStrategy =
      this._queueStrategyFactory.MakeStrategy(SuperServiceStage.GetInfo, response.GetResponseType());

    queueStrategy.MoveQueueMessage(
      container.Entity,
      jwtMessage,
      response,
      this._superserviceSerializer,
      this._queueMessageCreator,
      this._queueWriter,
      queueMessage);
  }

  public async Task Confirm(IQueueMessage queueMessage) {
    var action = "api/token/confirm";
    var container = this._superserviceSerializer.Deserialize<Container>(queueMessage.Body);
    var jwtMessage = this._packerFactory
      .MakePacker(SuperServiceAction.Confirm, container.IdJwt).Pack();
    var response = await this._loader.Load(action, jwtMessage);
    var queueStrategy =
      this._queueStrategyFactory.MakeStrategy(SuperServiceStage.Confirm, response.GetResponseType());

    queueStrategy.MoveQueueMessage(
      container.Entity,
      jwtMessage,
      response,
      this._superserviceSerializer,
      this._queueMessageCreator,
      this._queueWriter,
      queueMessage);
  }
}