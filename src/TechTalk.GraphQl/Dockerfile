FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["TechTalk.GraphQl/TechTalk.GraphQl.csproj", "TechTalk.GraphQl/"]
RUN dotnet restore "TechTalk.GraphQl/TechTalk.GraphQl.csproj"
COPY . .
WORKDIR "/src/TechTalk.GraphQl"
RUN dotnet build "TechTalk.GraphQl.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TechTalk.GraphQl.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TechTalk.GraphQl.dll"]