# OneDemo

| Project        | Area(s) to demonstrate |
| -------------- | ---------------------- |
| OneDemo.EfCore | EntityFrameworkCore    |

## OneDemo.EfCore

### Objectives

This project demonstrates using EntityFrameworkCore to load related data using the following approaches:

1. Lazy loading
2. Eager loading
3. Explicit loading

### Getting Started

1. Start SQL Server 2019 on Docker

```
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=myComplexPassword!' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
```

2. Update database from `DbContext`

```
dotnet ef database update
```

3. Run the project

```
dotnet run
```

### LazyLoading

Steps to take to use lazy loading:

1. Install package `Microsoft.EntityFrameworkCore.Proxies`

```
dotnet add package Microsoft.EntityFrameworkCore.Proxies
```

2. Use proxies in `DbContext` class:

```c#
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseLazyLoadingProxies();
	base.OnConfiguring(optionsBuilder);
}
```

3. Mark navigation properties `virtual` because `UseLazyLoadingProxies` requires all entity types to be public, unsealed, have virtual navigation properties, and have a public or protected constructor.
