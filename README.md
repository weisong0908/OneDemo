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

```bash
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=myComplexPassword!' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
```

2. Update database from `DbContext`

```bash
dotnet ef database update
```

3. Run the project

```bash
dotnet run
```

### Lazy Loading

Steps to take to use lazy loading:

1. Install package `Microsoft.EntityFrameworkCore.Proxies`

```bash
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

### Eager Loading

Steps to use eager loading:

1. Use `Include(blog => blog.Posts)` to return the navigation property. The included properties will be retrieved together with the parent entity in one query.

### Explicit Loading

Steps to use explicit loading:

1.  First load the parent entity

```c#
var blogs = _bloggingContext.Blogs.ToList();
```

2. Load the related entity using `Load()` method. Filter is optional.

```c#
_bloggingContext.Posts.Where(p => !string.IsNullOrWhiteSpace(p.Blog.Title)).Load();
```
