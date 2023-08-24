namespace DemoLibrary.Interface;

public interface IInjectableService { }
public interface ITransientService : IInjectableService { }
public interface IScopedService : IInjectableService { }
public interface ISingletonService : IInjectableService { }