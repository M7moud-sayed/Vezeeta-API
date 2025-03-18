# استخدم صورة رسمية لـ .NET 9
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# إنشاء مرحلة البناء
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["VezeetaAPI.csproj", "./"]
RUN dotnet restore "./VezeetaAPI.csproj"

COPY . .
RUN dotnet publish -c Release -o /app/publish
COPY images /app/images


# إنشاء المرحلة النهائية
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "VezeetaAPI.dll"]
