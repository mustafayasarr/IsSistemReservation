#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["IsSistemReservation.App.ReservationAPI/IsSistemReservation.App.ReservationAPI.csproj", "IsSistemReservation.App.ReservationAPI/"]
COPY ["IsSistemReservation.App.Core/IsSistemReservation.App.Core.csproj", "IsSistemReservation.App.Core/"]
COPY ["IsSistemReservation.App.Domain/IsSistemReservation.App.Domain.csproj", "IsSistemReservation.App.Domain/"]
COPY ["IsSistemReservation.App.Infrastructure/IsSistemReservation.App.Infrastructure.csproj", "IsSistemReservation.App.Infrastructure/"]
RUN dotnet restore "IsSistemReservation.App.ReservationAPI/IsSistemReservation.App.ReservationAPI.csproj"
COPY . .
WORKDIR "/src/IsSistemReservation.App.ReservationAPI"
RUN dotnet build "IsSistemReservation.App.ReservationAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IsSistemReservation.App.ReservationAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IsSistemReservation.App.ReservationAPI.dll"]