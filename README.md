# WeatherStation.Api

This is a PoC ASP.NET Core Web API project demonstrating automatic generation of OpenAPI specifications in both JSON and YAML formats. The generated OpenAPI files are written to the `openapi/` directory after each build.

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [NSwag CLI tool (NSwag.ConsoleCore)](https://www.nuget.org/packages/NSwag.ConsoleCore) — installed via `dotnet tool restore`

## Features

- ASP.NET Core Web API with sample weather endpoints.
- OpenAPI documentation generated automatically using [NSwag](https://github.com/RicoSuter/NSwag).
- OpenAPI specs output as both `openapi.json` and `openapi.yaml`.

## How It Works

- The project uses [NSwag.ConsoleCore](https://www.nuget.org/packages/NSwag.ConsoleCore) to generate OpenAPI documents from the ASP.NET Core project.
- The `WeatherStation.Api.csproj` defines a custom MSBuild target (`GenerateOpenApi`) that runs after each build.
- This target runs `dotnet nswag` twice—once to produce `openapi.json`, and once to produce `openapi.yaml`—based on a shared `nswag.json` configuration file.

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