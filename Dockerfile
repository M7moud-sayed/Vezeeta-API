# استخدم صورة رسمية لـ .NET 9
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# إنشاء مرحلة البناء
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# نسخ ملفات المشروع واستعادة الحزم
COPY ["VezeetaAPI.csproj", "./"]
RUN dotnet restore "./VezeetaAPI.csproj"

# نسخ باقي الملفات (بما في ذلك مجلد images)
COPY . .

# نسخ مجلد الصور إلى مسار الحاوية الصحيح
RUN mkdir -p /app/images
COPY images /app/images

# نشر التطبيق
RUN dotnet publish -c Release -o /app/publish

# إنشاء المرحلة النهائية
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# تشغيل التطبيق
ENTRYPOINT ["dotnet", "VezeetaAPI.dll"]
