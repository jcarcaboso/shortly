```
dotnet tool install --global dotnet-ef

dotnet ef dbcontext scaffold "Server=localhost:5432;Database=swapbuzz;User Id=postgres;Password=postgres" Npgsql.EntityFrameworkCore.PostgreSQL -o Models -c SwapBuzzContext
```
