namespace AppSemTemplate.Services
{
    public class OperacaoService {
    public OperacaoService(

        IOperacaoTransient transient,
        IOperacaoScoped scoped,
        IOperacaoSingleton singleton,
        IOpoeracaoSingletonInstance singletonInstance)
    {
        Trasnient = transient;
        Scoped = scoped;
        Singleton = singleton;
        SingletonInstance = singletonInstance;
    }

    public IOperacaoTransient Trasnient { get; }
    public IOperacaoScoped Scoped { get; }
    public IOperacaoSingleton Singleton { get; }
    public IOpoeracaoSingletonInstance SingletonInstance { get; }

    }


    public class Operacao : IOperacao,
                            IOperacaoScoped,
            IOperacaoSingleton,
            IOperacaoTransient,
                            IOpoeracaoSingletonInstance
    {
        public Operacao() : this(Guid.NewGuid())
        {
        }

        public Guid OperacaoId  { get; private set; }
        public Operacao(Guid id)
        {
            OperacaoId =id;
        }
    }

    public interface IOperacao
    {
      Guid OperacaoId { get;  }
    }

    public interface IOperacaoScoped : IOperacao
    {
    }

    public interface IOperacaoSingleton : IOperacao
    {
    }

    public interface IOperacaoTransient : IOperacao
    {
    }

    public interface IOpoeracaoSingletonInstance : IOperacao
    {
    }
}
