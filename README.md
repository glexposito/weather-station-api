# WeatherStation.Api

This is a PoC ASP.NET Core Web API project demonstrating automatic generation of OpenAPI specifications in both JSON and YAML formats. The generated OpenAPI files are written to the `openapi/` directory after each build.

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Swashbuckle.AspNetCore CLI tool](https://www.nuget.org/packages/Swashbuckle.AspNetCore.Cli) (restored automatically)

## Features

- ASP.NET Core Web API with sample weather endpoints.
- OpenAPI (Swagger) documentation generated automatically.
- OpenAPI specs output as both `openapi.json` and `openapi.yaml` files.

## How It Works

- The project uses [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) for Swagger/OpenAPI generation.
- The `.csproj` file defines a custom MSBuild target (`GenerateOpenApiSpec`) that runs after each build.
- This target uses the [Swashbuckle CLI tool](https://www.nuget.org/packages/Swashbuckle.AspNetCore.Cli) to generate the OpenAPI specs in both JSON and YAML formats and writes them to the `openapi/` directory.

## Usage

1. **Restore tools and dependencies:**
   ```sh
   dotnet tool restore
   dotnet restore
   ```

2. **Build the project:**
   ```sh
   dotnet build
   ```

3. **Find the generated OpenAPI specs:**
   - `WeatherStation.Api/openapi/openapi.json`
   - `WeatherStation.Api/openapi/openapi.yaml`

4. **Run the API (optional):**
   ```sh
   dotnet run --project WeatherStation.Api
   ```
   The Swagger UI will be available at the `/swagger` endpoint.

## Project Structure

- `Controllers/WeatherReadingsController.cs` - Sample API endpoints.
- `Models/WeatherReading.cs` - Data model for weather readings.
- `openapi/` - Output directory for generated OpenAPI specs.
- `WeatherStation.Api.csproj` - Project file with OpenAPI generation logic.

---

This project is for demonstration purposes only.