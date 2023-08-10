#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["IsSistemReservation.Notification.NotificationAPI/IsSistemReservation.Notification.NotificationAPI.csproj", "IsSistemReservation.Notification.NotificationAPI/"]
COPY ["IsSistemReservation.Notification.Core/IsSistemReservation.Notification.Core.csproj", "IsSistemReservation.Notification.Core/"]
COPY ["IsSistemReservation.Notification.Domain/IsSistemReservation.Notification.Domain.csproj", "IsSistemReservation.Notification.Domain/"]
RUN dotnet restore "IsSistemReservation.Notification.NotificationAPI/IsSistemReservation.Notification.NotificationAPI.csproj"
COPY . .
WORKDIR "/src/IsSistemReservation.Notification.NotificationAPI"
RUN dotnet build "IsSistemReservation.Notification.NotificationAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IsSistemReservation.Notification.NotificationAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IsSistemReservation.Notification.NotificationAPI.dll"]