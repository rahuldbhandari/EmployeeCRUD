### Scaffolding Code Using CLI :
dotnet ef dbcontext scaffold "Name=ConnectionStrings:EmployeeDBConnection" Npgsql.EntityFrameworkCore.PostgreSQL --data-annotations --context EmployeeContext --context-dir DAL\DBContext --output-dir DAL\Entities --force

### Scaffolding Code Using Packange Manager Console :
Scaffold-DbContext 'Name=ConnectionStrings:EmployeeCRUD' Npgsql.EntityFrameworkCore.PostgreSQL -Context EmployeeContext -ContextDir DAL/DBContext -o DAL/Entities -DataAnnotations -force