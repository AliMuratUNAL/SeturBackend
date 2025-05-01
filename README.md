/ContactService ( CRUD Transactions )
    -Controllers
    -ContactController/
    -Models
    -Data/
    -Entities/
    -Contact.cs/
    -Program.cs/
/DataAccess ( Migration Structure and Data Access )
        -Properties/
        -Migrations/ ( Add-Migration ContactReportServiceMg - Update-Database )
        -Models
        -Data
        -EntityFramework
        -AppDbContext/
        -RabbitMq/
        -Entities/
        -Contact
        -Report/
        -appsettings.json/ ( ConnectionStrings - DbConnection )
        -Program.cs/
/ReportService ( Creating and Viewing Reports )
    -Controllers/ ReportController
    -Models
    -Data/
    -Entities
    -Report/
    -Program.cs/
    
/Shared
    - Events/
    - DTOs/
    -Kafka/
    -Rabbit Message Queue/
    
/docker-compose.yml
/README.md
