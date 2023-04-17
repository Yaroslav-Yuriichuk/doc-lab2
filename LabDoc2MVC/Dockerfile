FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LabDoc2MVC/LabDoc2MVC.csproj", "LabDoc2MVC/"]
RUN dotnet restore "LabDoc2MVC/LabDoc2MVC.csproj"
COPY . .
WORKDIR "/src/LabDoc2MVC"
RUN dotnet build "LabDoc2MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LabDoc2MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LabDoc2MVC.dll"]
